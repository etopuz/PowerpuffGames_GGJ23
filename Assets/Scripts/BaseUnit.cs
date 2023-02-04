using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public int health;
    public int damage;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            health = 0;
        }
    }

    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
