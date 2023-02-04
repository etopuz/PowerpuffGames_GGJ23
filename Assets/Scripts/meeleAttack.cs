using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleAttack : MonoBehaviour
{
  private float timeBtwAttack;
  public float startTimeBtwAttack;
  public int damage;
  public float attackRangeX;
  public float attackRangeY;
  public float radius;
  public Vector2 point;



  public Transform attackPos;
  public LayerMask whatIsEnemies;
  public float attackRange;

  void Update(){

    if(timeBtwAttack <= 0){
        if(Input.GetKey(KeyCode.Space)){
            //camAnim.SetTrigger("shake");
            //playerAnim.SetTrigger("attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(point, radius, whatIsEnemies);
            //attackRange,enemyLayers
            for(int i = 0; i < enemiesToDamage.Length; i++){
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);

            }
        }
        timeBtwAttack = startTimeBtwAttack;
    }else{
        timeBtwAttack -= Time.deltaTime;
    }

  }

}

