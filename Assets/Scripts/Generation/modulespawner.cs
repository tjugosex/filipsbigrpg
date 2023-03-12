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

    public Dictionary<Vector2, TileInfo> Tiles = new Dictionary<Vector2, TileInfo>();

    public Transform player;
    public Vector2 currentPos;

    public Vector2 Test;

    List<GameObject> tempModules;
    private void Start()
    {
        tempModules = modules;
    }
    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            if (Tiles.TryGetValue(Test, out TileInfo _info))
            {
                Debug.Log("hm");
                for (int i = 0; i < _info.objs.Count; i++)
                {
                    Debug.Log(_info.objs[i]);

                }
            }
            
        }
        Generation();
    }
    void Generation()
    {

        currentPos = new Vector2Int(Mathf.FloorToInt(player.position.x / 10f + 1), Mathf.FloorToInt(player.position.y / 10f + 1));

        for (int x = (int)currentPos.x - RenderDistance; x <= (int)currentPos.x + RenderDistance; x++)
        {
            for (int y = (int)currentPos.y - RenderDistance; y <= (int)currentPos.y + RenderDistance; y++)
            {

                
                if (!TilesSet.TryGetValue(new Vector2(x, y), out bool bol))
                {
                    tempModules = modules;

                    if (Tiles.TryGetValue(new Vector2(x, y), out TileInfo _info))
                    {

                        for (int i = 0; i < tempModules.Count; i++)
                        {

                            for (int k = 0; k < _info.objs.Count; k++)
                            {

                                Debug.Log(_info.objs[k]);

                                if (tempModules[i].GetComponent<ModuleInfo>().id == _info.objs[k])
                                {
                                    tempModules.RemoveAt(i);
                                    i--;
                                    break;
                                }
                            }
                        }
                    }
                    GameObject mod = Instantiate(tempModules[Random.Range(0, tempModules.Count)]);
                    mod.transform.position = new Vector3(x * 10, y * 10, 0f);
                    mod.transform.parent = this.transform;
                    TilesSet.Add(new Vector2(x, y), true);

                    ChangeTileInfo(mod.GetComponent<ModuleInfo>(), new Vector2(x, y));
                }
            }
        }
    }
    void ChangeTileInfo(ModuleInfo info, Vector2 position)
    {
        List<int> objcts = info.Unwanted;
        List<Vector2> pos = info.Positions;
        for (int i = 0; i < objcts.Count; i++)
        {
            for (int k = 0; k < pos.Count; k++)
            {
                TilesSet.TryGetValue(pos[k] + position, out bool bol);
                if (!bol)
                {
                    Debug.Log(pos[k] + position);

                    if (Tiles.TryGetValue(pos[k] + position, out TileInfo _info))
                    {
                        _info.objs.Add(objcts[i]);
                        //if (_info.objs[j] != objcts[i])
                        //{
                            
                        //}
                        //for (int j = 0; j < _info.objs.Count; j++)
                        //{
                            

                        //}
                        Tiles.Remove(pos[k] + position);
                        Tiles.Add(pos[k] + position, _info);
                    }
                    else
                    {

                        TileInfo _tileInfo = new TileInfo();
                        _tileInfo.objs.Add(objcts[i]);
                        Tiles.Add(pos[k] + position, _tileInfo);
                    }
                }
            }
        }

    }
    public class TileInfo
    {
        public List<int> objs = new List<int>();
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
