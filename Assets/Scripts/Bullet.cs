using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;

    public Vector2 direction;
    public void Fire(Vector2 _direction, float _speed)
    {
        direction = _direction;
        speed = _speed;
    }

    private void FixedUpdate() {
        rb.velocity = direction * speed;
        Debug.Log(rb.velocity);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BasePlayer basePlayer= hitInfo.GetComponent<BasePlayer>();

        if (basePlayer != null)
        {
            basePlayer.TakeDamage(damage);
            Debug.Log("Hit");
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }


}
