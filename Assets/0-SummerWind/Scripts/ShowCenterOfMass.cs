using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ShowCenterOfMass : MonoBehaviour
{
    private Rigidbody myRB;

    public Vector3 CenterOfMass;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        myRB.centerOfMass = CenterOfMass;
        myRB.WakeUp();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * CenterOfMass,0.3f);
    }


}
