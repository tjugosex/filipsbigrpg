using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLaying : MonoBehaviour
{
    GameObject mineTT;
    public GameObject RRpref;

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
        if (Input.GetMouseButtonDown(0) && active)
        {
            GameObject Railroadpref = Instantiate(RRpref, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);

            
        }
    }
}
