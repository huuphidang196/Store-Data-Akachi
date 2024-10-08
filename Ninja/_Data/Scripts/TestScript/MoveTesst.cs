using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTesst : SurMonoBehaviour
{
    public Rigidbody2D _Rigidbody2D;
    public float _JumpingPower = 16f;
    protected override void Reset()
    {
        base.Reset();

        this._Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this._Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, this._JumpingPower);
            Debug.Log("jump");
        }    
    }
}
