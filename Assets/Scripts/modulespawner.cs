using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modulespawner : MonoBehaviour
{
    public float modulesnmbr = 5;
    public GameObject moduleprefab;
    // Start is called before the first frame update
    void Start()
    {
        float spawncord = (modulesnmbr - 1) * -50;
        float spawnx = spawncord;
        float spawny = spawncord;

        for (int i = 0; i < modulesnmbr; i++)
        {
            for (int k = 0; k < modulesnmbr; k++)
            {

                GameObject module = Instantiate(moduleprefab, new Vector3(spawnx, spawny, 20), Quaternion.identity);
                module.transform.parent = this.transform;
                spawnx += 100;
            }
            spawnx = spawncord;
            spawny += 100;
        }
    }

    // Update is called once per frame

}
