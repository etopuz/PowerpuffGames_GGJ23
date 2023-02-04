// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     public float health = 100f;
//     public float damage = 10f;

//     public void TakeDamage(float amount)
//     {
//         health -= amount;
//         if (health <= 0f)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         GetComponent<Animator>().SetTrigger("Die");
//         GetComponent<AudioSource>().Play();
//         Destroy(gameObject);
//     }
// }







// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Enemy : MonoBehaviour{
//     public int  health;
//     public float speed;
//     private float dazedTime;
//     public float startDazedTime;
//     public playerAttack;

//     private Animator anim;
//     public GameObject bloodEffect;

//     void Start(){
//         //anim = GetComponent<Animator>();
//         //anim.SetBool("isRunning",true);
//     }
//     void Update(){
//         if(dazedTime <= 0){
//             speed = 5;
//         }
//         else{
//             speed = 0;
//             dazedTime -= Time.deltaTime;
//         }

//         if(health <= 0){
//             Destroy(gameObject);
//         }
//         transform.Translate(Vector2.left * speed * Time.deltaTime);

//     }
//     public void TakeDamage(int damage){
//         Instantiate(bloodEffect,transform.position,Quaternion.identity);
//         health -= damage;
//         Debug.Log("damage TAKEN !");
//     }

//     public void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
//             if (playerAttack != null)
//             {
//                 TakeDamage(playerAttack.damage);
//             }
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;
    //public playerAttack;

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

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MeeleAttack meeleAttack = other.GetComponent<MeeleAttack>();
            if (meeleAttack != null)
            {
                TakeDamage(meeleAttack.damage);
            }
        }
    }
}
