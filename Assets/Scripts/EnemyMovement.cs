using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float range;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].tag == "player")
            {

            }
        }
    }
}
