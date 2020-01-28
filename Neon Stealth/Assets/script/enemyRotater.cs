using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRotater : MonoBehaviour
{
    public float TurnTime=3f;
    private float timer;
    private Animator animator;
    Coroutine turn;


    // Start is called before the first frame update
    void Start()
    {
        timer = Time.fixedTime;
        animator = GetComponent<Animator>();

    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        animator.SetBool("moving", false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime == (timer + TurnTime))
        {
            Debug.Log("turn");
            animator.SetBool("moving", true);
            turn = StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
            timer = Time.fixedTime;
        }
       

    }
}
