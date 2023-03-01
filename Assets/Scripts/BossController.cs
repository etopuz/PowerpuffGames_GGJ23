using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
   
    public float speed = 2.0f;
    public float attackRadius = 2.0f;

    private Animator animator;
    private Transform target;
    private bool isAttacking = false;
    private bool facingRight = false;

    public Transform[] patrolPoints;
    public int patrolDestination;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking)
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(6, 6, 1);
                    patrolDestination = 1;
                    Flip();
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-6, 6, -1);
                    patrolDestination = 0;
                    Flip();
                }
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
