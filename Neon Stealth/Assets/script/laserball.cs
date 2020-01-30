using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserball : MonoBehaviour
{

    public enum Direction { x, y,z };

    public Direction dir;
    public float speed = 10f;
    private Vector3 movement = new Vector3(0,0,0);
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (dir == Direction.x)
            movement = new Vector3(1,0,0);
        else if(dir==Direction.y)
            movement = new Vector3(0, 1, 0);
        else
            movement = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "box" || collision.gameObject.tag == "yellow")
            {

                Destroy(gameObject);
            }
            else
            {
                movement = movement * -1;
            }
        }
        else
        {
            collision.gameObject.GetComponent<ControllerPlayer>().kill();
            Destroy(gameObject);
        }
    }
}
