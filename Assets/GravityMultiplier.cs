using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityMultiplier : MonoBehaviour
{
    private Rigidbody _myRb;
    public bool useCustomGravity = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (useCustomGravity)
        {
            _myRb.AddForce(Physics.clothGravity * _myRb.mass);
        }
    }
}
