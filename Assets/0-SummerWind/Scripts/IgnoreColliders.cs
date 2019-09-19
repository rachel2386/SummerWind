using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    public List<CapsuleCollider> CapsuleCollidersToIgnore;
    public List<BoxCollider> BoxCollidersToIgnore;

    private Collider MyCol;

    public bool ignoreColliders = false;
    public bool ignoreLayer = false;

    public List<int> LayersToIgnore;
    // Start is called before the first frame update
    void Start()
    {
        MyCol = GetComponent<Collider>();
        if (ignoreColliders)
        {
            foreach (BoxCollider col in BoxCollidersToIgnore)
            {
                Physics.IgnoreCollision(MyCol, col);
            }
            foreach (CapsuleCollider col in CapsuleCollidersToIgnore)
            {
                Physics.IgnoreCollision(MyCol, col);
            }
        }
        else if (ignoreLayer)
        {
            foreach ( int layer in LayersToIgnore)
            {
                Physics.IgnoreLayerCollision(gameObject.layer, layer);
            }
            
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
