using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOneEnemy : MonoBehaviour
{
    public float moveSpeed = 5;
    bool canDestroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 8f)
        {
            canDestroyed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        if (pos.x < -20)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canDestroyed)
        {
            return;
        }

        BulletManager bullet = collision.GetComponent<BulletManager>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }
}
