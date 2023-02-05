using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePlayer : BaseUnit
{

    public Transform weaponPoint;

    public float radius;

    public float attackCooldownTime;

    public float cooldownCounter;

    public LayerMask enemyLayer;

    public AudioClip attackSound;

    public AudioClip damageTakenSound;

    public Slider slider;

    public void Start()
    {
        base.Start();
        slider.maxValue = health;
        slider.value = health;
    }


    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        slider.value = health;
        AudioSource.PlayClipAtPoint(damageTakenSound, Vector2.zero);
    }

    public override void Die()
    {
        //GameManager.instance.LoseGame();
    }


    private void AttackMelee(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(weaponPoint.position, radius, enemyLayer);
        AudioSource.PlayClipAtPoint(attackSound, Vector2.zero);
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
}
