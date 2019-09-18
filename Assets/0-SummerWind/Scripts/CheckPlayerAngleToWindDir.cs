using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerAngleToWindDir : MonoBehaviour
{
   
   [HideInInspector] public float angle;



    void Update()
    {
        Vector3 forward = transform.forward;
        angle = Vector3.Angle(Vector3.zero-WindArea.WindDirection, forward);
        
       
        
    }
}
