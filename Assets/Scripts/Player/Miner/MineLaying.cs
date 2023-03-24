using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLaying : MonoBehaviour
{
    GameObject mineTT;
    public GameObject RRpref;
    public GameObject clickedObject;
    bool active = false;

    void Start()
    {
        // Find the game object with name "mineTT"
        mineTT = transform.Find("mineTT").gameObject;

    }

    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the active state of the game object
            mineTT.SetActive(!mineTT.activeSelf);
            active = !active;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if the ray hits a game object with the GridObject tag
            if (hit.collider == null)
            {
                // If there is no collider with the GridObject tag, instantiate the object
                GameObject Railroadpref = Instantiate(RRpref, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
            }

        }
        if (Input.GetMouseButtonUp(1) && active)
        {
            mineTT.SetActive(true);
        }
        if (Input.GetMouseButton(1) && active)
        {
            mineTT.SetActive(false);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit.collider != null && hit.collider.CompareTag("GridObject"))
            {
                clickedObject = hit.collider.gameObject;

                if (clickedObject.GetComponent<GridSnap>().nr == 1)
                {
                    GameObject[] gridObjects = GameObject.FindGameObjectsWithTag("GridObject");

                    foreach (GameObject rr in gridObjects)
                    {
                        rr.GetComponent<GridSnap>().nr--;
                    }
                    Destroy(clickedObject);
                }

            }
        }
    }
}
