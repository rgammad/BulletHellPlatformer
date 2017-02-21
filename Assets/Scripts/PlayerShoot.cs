using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float burstFireRate = .1f;
    public float fireRate = .5f;
    public int burstClipCount = 3;

    private float lastFireTime = 0;

    private Vector3 offset;
    void Start()
    {
        float height = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        offset = new Vector3(0,0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > lastFireTime)
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
            yield return new WaitForSeconds(burstFireRate);
        }
    }
}
