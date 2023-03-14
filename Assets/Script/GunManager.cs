using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public BulletManager bullet;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }

    public void Shooting()
    {
        GameObject startBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        BulletManager goBullet = startBullet.GetComponent<BulletManager>();
        goBullet.direction = direction;
    }
}
