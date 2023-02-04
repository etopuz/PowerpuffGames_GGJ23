using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public int health;
    public int damage;
    public SpriteRenderer spriteRenderer;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
        if (health <= 0)
        {
            Die();
            health = 0;
        }
    }

    public void FlashOnDamage(){

    }

    public virtual void Die(){}
}
