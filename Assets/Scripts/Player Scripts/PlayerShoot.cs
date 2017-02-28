using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float burstFireRate = .1f;
    public float fireRate = .5f;
    public int burstClipCount = 3;
    static public int bulletsOnScreen = 0;
    static public int maxBulletsOnScreen = 4;

    private float lastFireTime = 0;
    private Vector3 offset;
    private Vector3 initOffset;
    private SpriteRenderer sprite;

    void Start()
    {
        float height = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        sprite = PlayerMovement.sprite;
        offset = new Vector3(sprite.bounds.size.x / 2 + 0.2f, -0.075f);
        initOffset = offset;
    }


    void Update()
    {
        if (sprite.flipX == true)
            offset.x = -(sprite.bounds.size.x / 2 + 0.2f);
        else
            offset = initOffset;
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > lastFireTime && bulletsOnScreen < maxBulletsOnScreen)
            {
                lastFireTime = Time.time + fireRate;
                StartCoroutine(_ShootBullet());
            }
        }
    }

    private IEnumerator _ShootBullet()
    {
        for (int i = 0; i < burstClipCount; i++)
        {
            BetterPool.Spawn(bulletPrefab, transform.position + offset);
            bulletsOnScreen++;
            yield return new WaitForSeconds(burstFireRate);
        }
    }
}
