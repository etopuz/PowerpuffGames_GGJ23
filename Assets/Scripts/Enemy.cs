using System;
using UnityEngine;

public class Enemy : BaseUnit
{
    public float speed;
    private float dazedTime;
    public float startDazedTime;
    private Animator anim;
    public GameObject bloodEffect;
    public GameObject floatingTextPrefab;
    public GameObject DoorPrefab; // Reference to the prefab for the door to the next level
    public Vector3 DoorPosition; // The position where the door should be instantiated

    private int numEnemiesRemaining; // The number of enemies remaining in the scene

    private void Start()
    {
       
        numEnemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
            numEnemiesRemaining--;
            Destroy(gameObject);
        }

        if (numEnemiesRemaining == 0)
        {
            // Instantiate the door for the next level
            Instantiate(DoorPrefab, DoorPosition, Quaternion.identity);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ShowDamage(damage.ToString());

        if (health <= 0)
        {
            Die();
            health = 0;
        }
    }

    public override void Die()
    {
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        numEnemiesRemaining--;
        Destroy(gameObject);
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


    private void ShowDamage(string text)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        floatingText.GetComponentInChildren<TextMesh>().text = text;
    }
}
