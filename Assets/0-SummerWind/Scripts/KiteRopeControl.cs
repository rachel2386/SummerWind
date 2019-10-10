using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class KiteRopeControl : MonoBehaviour
{
    public ObiRope m_rope;

    private ObiRopeCursor _cursor;

    private KitePhysics _kitePhysicsProperties;

    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _cursor = m_rope.GetComponent<ObiRopeCursor>();
        m_rope.RestLength = KitePhysics.CurrentStringLength;
        _kitePhysicsProperties = GetComponent<KitePhysics>();
    }

    // Update is called once per frame
    void Update()
    {
       // m_rope.RestLength = KitePhysics.CurrentStringLength;
        
    }

    public void ExtendRope()
    {
        _cursor.ChangeLength(m_rope.RestLength + Time.deltaTime * speed);
        print("currentLength" + m_rope.RestLength); 
    }
    
    public void ReelInRope()
    {
        print("currentLength" + m_rope.RestLength);
        _cursor.ChangeLength(m_rope.RestLength - Time.deltaTime *speed);
    }
}
