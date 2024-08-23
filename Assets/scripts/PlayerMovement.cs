using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 6f;
    //for smooth rotation
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;

    //gravity
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpHeight = 2f;
    public GameObject gm;
    Animator anim;
    private void Start()
    {
        anim = gm.GetComponent<Animator>();
    }
    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir * speed * Time.deltaTime);
            anim.SetBool("Walk", true);

        }

        else
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetButtonDown("Jump") && (controller.isGrounded))
        {
            Debug.Log("not grounded");

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
           


            anim.SetTrigger("Jump");

        }




    }
}

