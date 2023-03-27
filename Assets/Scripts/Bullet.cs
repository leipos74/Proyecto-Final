using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 inputBullet;
    [SerializeField] float bulletSpeed = 1;

    void FixedUpdate()
    {
        Vector3 random = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));

        rb.AddForce((transform.right + random)  * bulletSpeed );

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided");
            Destroy(this.gameObject);
            EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();
            enemy.TakeDamagePlayer();

        }
    }
}

