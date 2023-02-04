using UnityEngine;

public class Enemy : BaseUnit
{
    public float speed;
    private float dazedTime;
    public float startDazedTime;
    private Animator anim;
    public GameObject bloodEffect;
    public GameObject floatingTextPrefab;

    private void Start()
    {
        base.Start();
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


    private void ShowDamage(string text){
        GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        floatingText.GetComponent<TextMesh>().text = text;
    }
}
