using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : BaseUnit
{

    public Transform weaponPoint;

    public float radius;

    public float attackCooldownTime;

    public float cooldownCounter;

    public LayerMask enemyLayer;


    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        //GameManager.instance.LoseGame();
    }


    private void AttackMelee(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(weaponPoint.position, radius, enemyLayer);

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
