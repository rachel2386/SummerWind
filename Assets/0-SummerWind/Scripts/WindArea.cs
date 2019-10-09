using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
   public static float WindSpeed;
   public static float HighWindSpeed;
   
   public static Vector3 WindDirection;
   public static Vector3 HighWindDirection;

   private static float highWindThreshold = 30f;

   public bool InWindZone = false;
   
   public List<Rigidbody>AffectedRBs = new List<Rigidbody>();
   private List<Cloth> AffectedCloth = new List<Cloth>();

   private Transform m_character;
   
    // Start is called before the first frame update
    void Start()
    {
        WindDirection = new Vector3(Random.Range(-1f,1f),0.1f,Random.Range(-1f,1f)).normalized;
        HighWindDirection = WindDirection;
       
        WindSpeed = Random.Range(20f,40f);
        HighWindSpeed = 50f;
       
        print("windDIr = " + WindDirection * WindSpeed);
        
        AffectedCloth.AddRange(GameObject.FindObjectsOfType<Cloth>());

        m_character = GameObject.FindWithTag("Player").transform;
        
        foreach (Cloth cloth in AffectedCloth)
        {
            if(cloth.transform.position.y<=highWindThreshold)
            cloth.externalAcceleration = WindDirection * WindSpeed;
            else
              cloth.externalAcceleration = HighWindDirection * HighWindSpeed;
        }

    }

    private void FixedUpdate()
    {
        if (!InWindZone) return;
        WindEffect();
        
        
        
    }

    public void WindEffect()
    {
        if (AffectedRBs.Count <= 0) return;
        
        foreach (Rigidbody rb in AffectedRBs)
        {
            //if (!(rb.velocity.magnitude <= 0.01f)) continue;
            var disToPlayer = Vector3.Distance(m_character.position, rb.position);
            
                //if rigidbody y position is lower than 30m, affected by low wind, otherwise affected by high wind 
                if (rb.position.y <= highWindThreshold ) 
                {
//                    if(rb.position.y > 20)
//                    rb.drag = Mathf.Lerp(rb.drag, rb.position.y/2, Time.deltaTime * 10f);
//                    else
//                    {
                        rb.drag = Mathf.Lerp(rb.drag, 2f, Time.deltaTime);
                   // }
                    if (disToPlayer <= KitePhysics.maxStringLength)
                    rb.AddForce(WindSpeed * WindDirection, ForceMode.Force);
                   // rb.transform.forward = Vector3.Lerp(rb.transform.forward, WindDirection, Time.deltaTime * 5f); 
                }
                else
                {
                    
                    rb.drag = Mathf.Lerp(rb.drag, rb.position.y, Time.deltaTime);
                    
                    if (disToPlayer <= KitePhysics.maxStringLength)
                    rb.AddForce(HighWindSpeed * HighWindDirection, ForceMode.Force);
                    
                    rb.AddForce(Vector3.up * 50f,  ForceMode.Force);
                    rb.transform.forward = Vector3.Lerp(rb.transform.forward, HighWindDirection, Time.deltaTime * 5f);


                } 
            
            

           

        }


    }

    public void ClothEffect()
    {
        if (WaitForWindChange) return;
        foreach (Cloth cloth in AffectedCloth)
        {
            if(cloth.transform.position.y<=highWindThreshold)
            cloth.externalAcceleration = WindDirection * WindSpeed;
            else
                cloth.externalAcceleration = HighWindDirection * HighWindSpeed;
        }
    }

    private void Update()
    {
        if (!InWindZone) return;
        ClothEffect();
        if(!WaitForWindChange)
            StartCoroutine(RandomizeWind());


    }

    void OnTriggerEnter(Collider other)
    {
        InWindZone = true;
        
        if (other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody RB = other.GetComponent<Rigidbody>();
            AffectedRBs.Add(RB);
        }

       
       
    }
    
    void OnTriggerStay(Collider other)
    {
        
            if (other.GetComponent<Rigidbody>() != null)
            {
                Rigidbody RB = other.GetComponent<Rigidbody>();
                
                if(!AffectedRBs.Contains(RB))
                AffectedRBs.Add(RB);
            }
           
  
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody RB = other.GetComponent<Rigidbody>();
            AffectedRBs.Remove(RB);
        }
    }

   [HideInInspector] public bool WaitForWindChange = false;
    IEnumerator RandomizeWind()
    {
        WaitForWindChange = true;
        yield return new WaitForSeconds(Random.Range(60, 180));
        WaitForWindChange = false;
        WindSpeed = Random.Range(3f, 8f);
        WindDirection = new Vector3(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
        print(WindDirection);
    }
}
