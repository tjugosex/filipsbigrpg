using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    Transform player;


    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = player.position + new Vector3(0, 0, -10f);
        }
        else
        {
            FindPlayer();
        }
    }
    void FindPlayer()
    {
        PlayerMovement pm = PlayerMovement.Instance;
        if (pm)
        {
            player = pm.transform;
        }
    }
}
