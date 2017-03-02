using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBulletBehavior : MonoBehaviour, ISpawnable
{
    public float speed = 4.5f;
    public float damage = 5.0f;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerBullet"))
        {
            Health targetHealth = other.transform.root.GetComponent<Health>();
            if (targetHealth != null)
                targetHealth.Damage(damage);
            BetterPool.Despawn(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            BetterPool.Despawn(this.gameObject);
        }
    }

    void ISpawnable.Spawn()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }
}
