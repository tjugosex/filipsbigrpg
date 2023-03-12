using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject treeprefab; // the prefab to be instantiated
    public int id;
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f)); 
            GameObject tre = Instantiate(treeprefab, new Vector3 (transform.position.x, transform.position.y, 0) + new Vector3(randomPosition.x, randomPosition.y, randomPosition.y), Quaternion.identity); // instantiates the prefab at the random position
            tre.transform.parent = this.transform;
            tre.GetComponent<SpriteRenderer>().sortingOrder = -(id -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
