using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 2.0f;
    public float attackRadius = 2.0f;

    private Animator animator;
    private Transform target;
    private bool isAttacking = false;
    private bool facingRight = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking)
        {
            transform.position = new Vector2(Mathf.Lerp(startPoint.x, endPoint.x, Mathf.PingPong(Time.time * speed, 1.0f)), transform.position.y);

            if (transform.position.x > 6 && facingRight)
            {
                Flip();          
            }
            else if (transform.position.x < -7 && !facingRight)
            {
                Flip();
            }
        }

        float distance = Vector3.Distance(transform.position, target.position);
        
        if (distance < attackRadius)
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);
        }
        else
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale =transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
}
