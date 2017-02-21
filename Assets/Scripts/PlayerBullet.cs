using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, ISpawnable
{
    [SerializeField]
    protected float speed = 20.0f;
    [SerializeField]
    protected float damage = 5f;


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Despawner"))
        {
            Health targetHealth = other.transform.root.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.Damage(damage);
            }
            BetterPool.Despawn(this.gameObject);
        }
    }

    void ISpawnable.Spawn()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
}
