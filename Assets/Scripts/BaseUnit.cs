using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public int health;
    public int damage;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        BlinkOnDamage();
    }

    public void BlinkOnDamage(){
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.1f);
    }

    public void ResetColor(){
        spriteRenderer.color = Color.white;
    }

    public virtual void Die(){}
}
