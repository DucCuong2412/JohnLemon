using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoment : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float speed = 0.9f;
    public float speedRotate = 20f;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Move();


    }



    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);       

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            animator.SetTrigger("Run");

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotate * Time.deltaTime);

        }else if (horizontal == 0 && vertical == 0)
        {
            animator.SetTrigger("Idle");
        }
        

    }
    

}
