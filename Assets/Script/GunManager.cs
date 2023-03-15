using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public BulletManager bullet;
    Vector2 direction;

    public bool autoShoot = false;
    float shootIntervalSeconds = 2f;
    float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shooting();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shooting()
    {
        GameObject startBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        BulletManager goBullet = startBullet.GetComponent<BulletManager>();
        goBullet.direction = direction;
    }
}
