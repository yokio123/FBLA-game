using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D Controller;
    public float Speed = 40f;
    float XMove = 0f;
    bool Jumps = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      XMove =  Input.GetAxisRaw("Horizontal")* Speed;

        animator.SetFloat("Speed", Mathf.Abs(XMove));

        if (Input.GetButtonDown("Jump"))
        {
        Jumps = true;
        animator.SetBool("Jumping",true);
        }


        
    }
      void FixedUpdate()
    {
        Controller.Move(XMove * Time.fixedDeltaTime, false, Jumps);
        animator.SetBool("Jumping", false);
        Jumps = false;

    }
}
