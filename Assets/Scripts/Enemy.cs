using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;
    private Animator anim;
    public GameObject bloodEffect;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning",true);
    }

    private void Update()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MeleeAttack meleeAttack = other.GetComponent<MeleeAttack>();
            if (meleeAttack != null)
            {
                TakeDamage(meleeAttack.damage);
            }
        }
    }
}
