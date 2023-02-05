using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
  public float timeBtwAttack = 0;
  public float startTimeBtwAttack;
  public int damage;
  public float radius;
  public Vector2 point;

  public Transform attackPos;
  public LayerMask whatIsEnemies;

  void Update(){

    if(timeBtwAttack <= 0){
        bool isAttacked = false;
        
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(point, radius, whatIsEnemies);
            //attackRange,enemyLayers
            for(int i = 0; i < enemiesToDamage.Length; i++){

              if (enemiesToDamage[i].GetComponent<Enemy>() != null){
                  enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
              }

              else if(enemiesToDamage[i].GetComponent<BasePlayer>() != null) {
                  enemiesToDamage[i].GetComponent<BasePlayer>().TakeDamage(damage);
              }

              isAttacked = true;
                
            }
            if (isAttacked){
                timeBtwAttack = startTimeBtwAttack;
            }
            else{
                timeBtwAttack -= Time.deltaTime;
            }
        
    }
    
    else{
        timeBtwAttack -= Time.deltaTime;
    }

  }

}

