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
    public float detectionRadius = 10.0f; // The radius within which to detect goblins
    public string targetTagName = "Player"; // The tag of the target object
    public float pointOffset = 0.5f; // The distance between the goblin and the target point

    private GameObject[] goblins; // An array to hold all goblin objects
    private Transform targetTransform; // The transform of the target object

    Vector2 direction;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        // Find all gameobjects with the "goblin" tag and add them to the array
        goblins = GameObject.FindGameObjectsWithTag("gobline");

        // Find the gameobject with the "Player" tag and get its transform
        targetTransform = GameObject.FindGameObjectWithTag(targetTagName).transform;
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

                if (this.CompareTag("goblineking"))
                {
                    if (distance > 2f)
                    {
                        direction = (col[i].transform.position - transform.position).normalized;
                    }

                    foreach (GameObject goblin in goblins)
                    {
                        if (goblin != null)
                        {
                            EnemyMovement enemyMovement = goblin.GetComponent<EnemyMovement>();
                            // Check if the goblin is within the detection radius
                            if (Vector3.Distance(goblin.transform.position, transform.position) <= detectionRadius)
                            {
                                // Get the EnemyMovement script attached to the goblin object


                                // Calculate the point between the goblin and the target object
                                Vector2 targetPoint = new Vector2(transform.position.x, transform.position.y) + ((Vector2)(targetTransform.position - transform.position).normalized * pointOffset);

                                // Set the goblin's direction to point towards the target point
                                enemyMovement.direction = (targetPoint - (Vector2)goblin.transform.position).normalized;
                            }
                            else
                            {
                                enemyMovement.direction = Vector2.zero;
                            }
                        }

                    }

                }


                if (distance < 2f)
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
