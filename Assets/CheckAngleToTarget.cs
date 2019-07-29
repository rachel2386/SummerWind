using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAngleToTarget : MonoBehaviour
{
    public Transform Target;

    [HideInInspector] public float Angle;
    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward;
        Angle = Vector3.Angle(Target.forward, forward);
       

    }
}
