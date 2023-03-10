using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modulespawner : MonoBehaviour
{
    public bool generating = true;
    public int RenderDistance;

    public GameObject moduleprefab;

    public List<GameObject> modules = new List<GameObject>();

    public Dictionary<Vector2, bool> TilesSet = new Dictionary<Vector2, bool>();

    public Transform player;
    public Vector2 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        Generation();
    }
    void Generation()
    {
        
        currentPos = new Vector2Int(Mathf.FloorToInt(player.position.x / 5 + 1), Mathf.FloorToInt(player.position.y / 5 + 1));

        for (int x = (int)currentPos.x - RenderDistance; x <= (int)currentPos.x + RenderDistance; x++)
        {
            for (int y = (int)currentPos.y - RenderDistance; y <= (int)currentPos.y + RenderDistance; y++)
            {
                TilesSet.TryGetValue(new Vector2(x, y), out bool bol);
                if (!bol)
                {
                    GameObject mod = Instantiate(modules[Random.Range(0, modules.Count)]);
                    mod.transform.position = new Vector3(x * 10, y * 10, 0f);
                    mod.transform.parent = this.transform;
                    TilesSet.Add(new Vector2(x, y), true);
                }
            }
        }
    }

    void MiklGeneration()
    {
        float modulesnmbr = 20;
        float spawncord = (modulesnmbr - 1) * -50;
        float spawnx = spawncord;
        float spawny = spawncord;

        for (int i = 0; i < modulesnmbr; i++)
        {
            for (int k = 0; k < modulesnmbr; k++)
            {

                GameObject module = Instantiate(moduleprefab, new Vector3(spawnx, spawny, 20), Quaternion.identity);
                module.transform.parent = this.transform;
                module.GetComponent<spawner>().id = i;
                spawnx += 100;
            }
            spawnx = spawncord;
            spawny += 100;
        }
    }
}
