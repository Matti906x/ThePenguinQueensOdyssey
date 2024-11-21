using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [SerializeField] float waterGravityScale = 0.5f;

    Rigidbody2D myRigidBody;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)        
        {
            if(other.tag == "Water")
            {
                myRigidBody.gravityScale = waterGravityScale;
            }
        }
}
