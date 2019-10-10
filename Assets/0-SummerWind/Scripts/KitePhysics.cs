using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KitePhysics : MonoBehaviour
{
    private Rigidbody myRB;
    
   private Transform playerTransform;
   private Rigidbody playerRB;
   public float pullForce = 3f;
    public float liftForce = 10f;

    private bool holdingKey = false;
    float forceTimer = 0;

    public static float CurrentStringLength = 10f;//10f;
    public static float maxStringLength = 80;//300f;
    public static float minStringLength = 1f;//8f;

    public float changeRopeLengthSpeed = 5f;
    private KiteRopeControl ropeControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        //playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        myRB = GetComponent<Rigidbody>();
        ropeControlScript = GetComponent<KiteRopeControl>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, WindArea.WindDirection * 10f, Color.yellow);
       
       //wind lift
        LiftCalculation(WindArea.WindDirection * WindArea.WindSpeed);
       
        //run lift
       
        
        
        //AutoAdjustKiteDis();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            PullString();
        }
        
        if (Input.GetKey(KeyCode.I))
        {
            ManualExtendString();
           
        }
        else if (Input.GetKey(KeyCode.K))
        {
            ManualTightenString();
           
        }


//        if (Input.GetKeyUp(KeyCode.E))
//            holdingKey = false;


        // DebugFunctions();
    }

    void Update()
    {
//        if (holdingKey)
//            forceTimer += Time.deltaTime;
//        else
//            forceTimer = 0;
        CurrentStringLength = ropeControlScript.m_rope.RestLength;


    }

   

    void LiftCalculation(Vector3 force)
    {
        //if (Vector3.Distance(transform.position, playerTransform.position) <= CurrentStringLength)
       // {
            //Project wind force to lift force
            //Vector3 extraForce = myRB.velocity;
            //Vector3 projectedWindForce = Vector3.Project(WindArea.WindDirection * WindArea.WindSpeed, -transform.up);
            Vector3 projectedForce =Vector3.Project(force, transform.up);
            // overallForce = projectedWindForce + projectedExtraForce;
            projectedForce.y = Mathf.Abs(projectedForce.y);
            myRB.AddForce(projectedForce * liftForce,ForceMode.Force);
        
            
       // }

        
       
    }

    private void PullString()
    {
        //holdingKey = true;
        //pullForce = forceTimer;
       
        
        var forceDir = playerTransform.position - transform.position;
       //pull force
        myRB.AddForce(forceDir * pullForce, ForceMode.Impulse);
        //lift force
        
        //var attackAngle = Vector3.Angle(-transform.forward, -WindArea.WindDirection);
        //liftForce = Mathf.Lerp(liftForce, Mathf.Abs(WindArea.WindSpeed) * Mathf.Tan(attackAngle *  Mathf.Deg2Rad),Time.deltaTime * 5);
        
       // myRB.AddForce(Vector3.up * liftForce, ForceMode.VelocityChange);
       //transform.up = forceDir.normalized;
      transform.up = Vector3.Slerp(transform.up, (forceDir.normalized),Time.deltaTime * 10f);
    }
    
    public void runForce(Rigidbody playerRB)
    {
        var RBvel = Mathf.Abs(playerRB.velocity.x + playerRB.velocity.z);
        Vector3 force = Vector3.zero;
        if (RBvel> 0.1f)
        {
            var runDir = playerRB.position - myRB.position;
            force = runDir.normalized * RBvel;
            myRB.AddForce(force, ForceMode.Acceleration);
            LiftCalculation(force);
        }
        
    }
    private void ManualExtendString()
    {
        if (CurrentStringLength < maxStringLength)
        {
            //CurrentStringLength += Time.deltaTime * changeRopeLengthSpeed;
            ropeControlScript.ExtendRope();
        }

       
        //print("MaxdistanceToPlayer" + maxStringLength);
    }

    private void ManualTightenString()
    {
        if (Vector3.Distance(playerTransform.position, myRB.position) >= minStringLength)
        {
           //CurrentStringLength -= Time.deltaTime * changeRopeLengthSpeed;
            ropeControlScript.ReelInRope();
            //print("MaxdistanceToPlayer" + maxStringLength);
            
        }
        else
            CurrentStringLength = minStringLength;
    }

    void AutoAdjustKiteDis()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) > ropeControlScript.m_rope.RestLength)
        {
            var forceDir = playerTransform.position - transform.position;
          // myRB.AddForce(forceDir.normalized * 30,ForceMode.Acceleration);
           myRB.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * 10f);
//            myRB.transform.forward = Vector3.Lerp(transform.forward, -(playerTransform.position - transform.position),
//                Time.deltaTime * changeRopeLengthSpeed);
        }
    }
    
    private void DebugFunctions()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            myRB.AddForce(Vector3.up * 10f, ForceMode.VelocityChange);
        }
    }

    private void OnDrawGizmos()
    {
//        Gizmos.color = Color.cyan;
//        Gizmos.DrawRay(transform.position, transform.forward * 5f);

        var color = Color.white;
        color.a = 0.3f;
        Gizmos.color = color;
       
        if(playerTransform != null)
        Gizmos.DrawSphere(playerTransform.position,CurrentStringLength);
    }

    
}