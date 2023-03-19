using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class movement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    bool railriding = false;
    Vector3 direction;
    public float speed = 10f;
    public float runSpeed = 20.0f;
    bool RailInRange = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision was with the player object
        if (collision.CompareTag("GridObject") && collision.GetComponent<GridSnap>().nr == 1)
        {
            // Set playerInRange to true
            RailInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision was with the player object
        if (collision.CompareTag("GridObject") && collision.GetComponent<GridSnap>().nr == 1)
        {
            // Set playerInRange to true
            RailInRange = false;
        }
    }

    void Update()
    {
        // Gives a value between -1 and 1
        if (railriding == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            railriding = !railriding;
            body.velocity = new Vector2(0, 0);
            if (RailInRange && railriding)
            {

                StartCoroutine(cartriding());

            }

        }
    }

    void FixedUpdate()
    {
        if (railriding == false)
        {
            body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }



    IEnumerator cartriding()
    {
        GameObject[] gridObjects = GameObject.FindGameObjectsWithTag("GridObject");


        Array.Sort(gridObjects, (x, y) => x.GetComponent<GridSnap>().nr.CompareTo(y.GetComponent<GridSnap>().nr));


        foreach (GameObject rr in gridObjects)
        {


            direction = (rr.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;


            while ((Vector3.Distance(transform.position, rr.transform.position) > 0.1f) && (railriding))
            {
                Debug.Log(rr.GetComponent<GridSnap>().nr);
                yield return null;
            }


            direction = Vector3.zero;

        }

    }
}
