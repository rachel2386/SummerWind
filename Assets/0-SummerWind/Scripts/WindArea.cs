using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
   public static float WindSpeed;
   public static float HighWindSpeed;
   
   public static Vector3 WindDirection;
   public static Vector3 HighWindDirection;

   private float highWindThreshold = 20f;

   public bool InWindZone = false;
   
   public List<Rigidbody>AffectedRBs = new List<Rigidbody>();
   private List<Cloth> AffectedCloth = new List<Cloth>();
   
   
    // Start is called before the first frame update
    void Start()
    {
        WindDirection = new Vector3(Random.Range(-1f,1f),Random.Range(-0.1f,0.1f),Random.Range(-1f,1f));
        HighWindDirection = WindDirection;
        WindSpeed = Random.Range(5f,20f);
        HighWindSpeed = 50f;
       
        AffectedCloth.AddRange(GameObject.FindObjectsOfType<Cloth>());
        
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
        ClothEffect();
    }

    public void WindEffect()
    {
        if (AffectedRBs.Count <= 0) return;
        foreach (Rigidbody rb in AffectedRBs)
        {
            if (!(rb.velocity.magnitude <= 0.01f)) continue;
            if (rb.transform.position.y <= highWindThreshold) //if rigidbody y position is lower than 30m, affected by low wind, otherwise affected by high wind 
            {
                rb.AddForce(WindSpeed * WindDirection, ForceMode.Force);
            }
            else
            {
                rb.AddForce(HighWindSpeed * HighWindDirection, ForceMode.Force);
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
        if(InWindZone)
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
