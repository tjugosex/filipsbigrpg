using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour
{
    PlayerAnimator anim;
    public float radius;
    public float range;
    float count;
    public float time;
    public bool isDigging;
    [HideInInspector] public Vector2 lastDirection;
    private void Start()
    {
        anim = gameObject.GetComponent<PlayerAnimator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Direction();
        }
        else
        {
            count = time;
        }
    }
    void Direction()
    {
        lastDirection = anim.lastDirection;

        if (lastDirection.x != 0f && Mathf.Abs(lastDirection.x) > Mathf.Abs(lastDirection.y))
        {
            if (lastDirection.x < 0f)
            {
                Dig(new Vector2(-range, 0));
                return;
            }
            else
            {
                Dig(new Vector2(range, 0));
                return;
            }
        }
        else if (lastDirection.y > 0f)
        {
            Dig(new Vector2(0, range));
            return;
        }
        else
        {
            Dig(new Vector2(0, -range));
        }
    }
    void Dig(Vector2 point)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y) + point, radius);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].tag == "diggable")
            {
                if (count < 0)
                {
                    Destroy(cols[i].gameObject);
                    count = time;
                }
                count -= Time.deltaTime;
            }
        }
    }
}
