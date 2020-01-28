using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    private Rigidbody rb;
    private int speed;
    public int gravScale;
    private Animator animator;
    private bool alive;
    private bool started;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        alive = true;
        started = false;
        speed = 5;
    }

    public void kill() {
        alive = false;
    }

    public void StartUp() { started = true; }

    public bool GetAlive() { return alive; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "red") { kill(); }
    }

    private void FixedUpdate()
    {
        if (alive && started) { 

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                speed = 10;

            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) {
                speed = 5;
                animator.SetBool("running", false);


            }

            Vector3 movement = new Vector3(-moveHorizontal, 0f, -moveVertical);

            if (movement != Vector3.zero)
            {
                rb.velocity += movement*speed;
                if (speed == 5)
                {
                    animator.SetBool("moving", true);
                }
                if (speed == 10)
                {
                    animator.SetBool("moving", true);
                    animator.SetBool("running", true);

                }
                transform.forward = movement;
            }
            else {
                animator.SetBool("moving", false);
                animator.SetBool("running", false);

            }
        }
    }
}
