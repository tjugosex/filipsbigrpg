using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D body;

    public float range;
    public float speed;

    Vector2 direction;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].tag == "Player")
            {
                direction = (col[i].transform.position - transform.position).normalized;

            }
        }
    }
    void FixedUpdate()
    {
        body.velocity = direction * speed;
    }
}
