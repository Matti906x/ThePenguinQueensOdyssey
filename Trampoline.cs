using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    Animator myAnimator;
    
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        myAnimator.SetBool("isJumping", true);
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        myAnimator.SetBool("isJumping", false);
    }
}
