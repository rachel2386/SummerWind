using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 10f;
    public KitePhysics KitePhysicsControl;

    private Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        myRB.velocity = Vector3.right * Input.GetAxis("Horizontal") * speed 
                             + Vector3.forward * Input.GetAxis("Vertical")* speed;
        
        KitePhysicsControl.runForce(myRB);
    }
}
