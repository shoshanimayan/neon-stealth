using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    public enum TypeWalk { walk,run}
    public GameObject[] waypoint;
    public TypeWalk setting;
    private float speed;
    private Animator animator;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in waypoint)
        {
            i.transform.position = new Vector3(i.transform.position.x, transform.position.y, i.transform.position.z);
        }

        animator = GetComponent<Animator>();
        if (setting == TypeWalk.walk)
        {
            speed = 5;
            animator.SetBool("moving", true);

        }
        else {
            speed = 12;
            animator.SetBool("moving", true);
            animator.SetBool("running", true);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "yellow")
        {

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, waypoint[index].transform.position);
        if (distance > .3)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[index].transform.position, speed * Time.deltaTime);
            Vector3 targetDirection = waypoint[index].transform.position - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);



        }
        else {
            if (index + 1 < waypoint.Length)
                index++;
            else
                index = 0;
        }

    }
}
