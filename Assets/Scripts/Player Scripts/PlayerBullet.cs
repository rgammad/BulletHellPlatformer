using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, ISpawnable
{
    [SerializeField]
    protected float speed = 20.0f;
    [SerializeField]
    protected float damage = 5f;

    private int facing = 1;
    
    void OnCollisionEnter2D(Collision2D other)
    {

        Health targetHealth = other.transform.root.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Damage(damage);
        }
        BetterPool.Despawn(this.gameObject);
        PlayerShoot.bulletsOnScreen--;

    }

    void ISpawnable.Spawn()
    {
        if (PlayerMovement.sprite.flipX)
            facing = -1;
        else
            facing = 1;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed * facing;
    }
}
