using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePlayer : BaseUnit
{

    public int maxHealth;
    
    public Transform weaponPoint;

    public float radius;

    public float attackCooldownTime;

    public float cooldownCounter;

    public LayerMask enemyLayer;

    public AudioClip attackSound;

    public AudioClip damageTakenSound;

    public Slider slider;

    public Animator anim;



    

    public void Start()
    {
        base.Start();
        slider.maxValue = maxHealth;
        anim = GetComponent<Animator>();
        SetHealthOnStart();
        slider.value = health;
    }


    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if(health <= 0)
        {
            Die();
        }
        slider.value = health;
        AudioSource.PlayClipAtPoint(damageTakenSound, Vector2.zero);
    }

    public override void Die()
    {
        GameManager.instance.LoseGame();
    }


    private void AttackMelee(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(weaponPoint.position, radius, enemyLayer);
        AudioSource.PlayClipAtPoint(attackSound, Vector2.zero);

        anim.SetTrigger("Attack");

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.TryGetComponent(out Enemy enemyScript))
            {
                enemyScript.TakeDamage(damage);
            }
        }

    }

    private void Update()
    {
        if (cooldownCounter > 0)
        {
            cooldownCounter -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (cooldownCounter <= 0)
            {
                AttackMelee();
                cooldownCounter = attackCooldownTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(weaponPoint.position, radius);
    }

    public void IncreaseHealth(int amount)
    {
       health += amount;
        if (health > slider.maxValue)
        {
           health = (int)slider.maxValue;
        }
        slider.value = health;
    }


    private void SetHealthOnStart(){

        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            health = PlayerPrefs.GetInt("PlayerHealth");
        }

        else
        {
            health = maxHealth; 
        }
    }

}
