using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform target;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 3f;
    public float bulletDamage = 1f;


    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Vector2 direction = (target.position - transform.position);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Fire(direction.normalized, bulletSpeed);            
            Destroy(bullet, bulletLifeTime);
        }
    }
}
