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
    private bool finished;
    private int ammo;

    public GameObject shot;

    private void Start()
    {
        finished = false;
        ammo = 0;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        alive = true;
        started = false;
        speed = 5;
    }

    public void kill() {
        if(!finished)
            alive = false;
    }

    public void win() { finished = true; }
    public void AddAmmo() { ammo++; }
    private void shoot() {
        ammo--;
        Debug.Log("shoot");

        Vector3 spawnPos=transform.position + transform.forward * .5f;
        spawnPos = new Vector3(spawnPos.x, 2, spawnPos.z);
        GameObject bulletClone=Instantiate(shot, spawnPos, transform.rotation);

        bulletClone.transform.GetComponent<Rigidbody>().velocity = transform.forward * 12;

    }

    public void StartUp() { started = true; }

    public bool GetAlive() { return alive; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "red")
            kill(); 
    }

    private void FixedUpdate()
    {
        if (alive && started &&!finished) {
            //shoot
            if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
                shoot();
            //movment
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
                speed = 10;
            else  {
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
