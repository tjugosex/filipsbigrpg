using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject spjutPrefab;
    public float range;
    public float speed;
    public float projectileSpeed;
    public float projectileCooldown;
    private float projectileCooldownTimer = 0.0f;
    public float projectileDestroyTimer;

    Vector2 direction;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileCooldownTimer > 0.0f)
        {
            projectileCooldownTimer -= Time.deltaTime;
        }
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].tag == "Player")
            {
                float distance = Vector2.Distance(col[i].transform.position, transform.position);
                if (distance > 2f)
                {
                    direction = (col[i].transform.position - transform.position).normalized;
                }
                else
                {
                    if (projectileCooldownTimer <= 0)
                    {
                        GameObject projectile = Instantiate(spjutPrefab, transform.position, Quaternion.identity);
                        direction = (col[i].transform.position - transform.position).normalized;
                        projectile.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
                        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                        rb.velocity = direction * projectileSpeed;
                        projectileCooldownTimer = projectileCooldown;
                        Destroy(projectile, projectileDestroyTimer);
                    }

                    direction = Vector2.zero;

                }
            }
        }
    }
    void FixedUpdate()
    {
        body.velocity = direction * speed;
    }
}
