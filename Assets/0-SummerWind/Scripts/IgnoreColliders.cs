using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    public List<CapsuleCollider> CapsuleCollidersToIgnore;
    public List<BoxCollider> BoxCollidersToIgnore;

    private Collider MyCol;
    // Start is called before the first frame update
    void Start()
    {
        MyCol = GetComponent<Collider>();
        foreach (BoxCollider col in BoxCollidersToIgnore)
        {
            Physics.IgnoreCollision(MyCol, col);
        }
        foreach (CapsuleCollider col in CapsuleCollidersToIgnore)
        {
            Physics.IgnoreCollision(MyCol, col);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
