using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawKiteString : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform Kite;
    public Transform Handle;
    public Material StringMat;
    private LineRenderer myLine;
    
   
    void Start()
    {
        myLine = gameObject.AddComponent<LineRenderer>();
        myLine.material = StringMat;
        myLine.startWidth = 0.003f;
        print(myLine.startWidth);
        


    }

    // Update is called once per frame
    void Update()
    {
        myLine.SetPosition(0, Kite.position);
        myLine.SetPosition(1, Handle.position);
    }
}
