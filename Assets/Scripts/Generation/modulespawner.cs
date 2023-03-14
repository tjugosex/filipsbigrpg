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
    public GameObject modul;


    public Vector2 Test;

    public GameObject path;

    List<GameObject> tempModules;
    private void Start()
    {
        //ChangeTileInfoToPoint(path, new Vector2(100, 100));

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

        for (int y = (int)currentPos.y - RenderDistance; y <= (int)currentPos.y + RenderDistance; y++)
        {
            for (int x = (int)currentPos.x - RenderDistance; x <= (int)currentPos.x + RenderDistance; x++)
            {
                TilesSet.TryGetValue(new Vector2(x, y), out bool bol);


                if (!bol)
                {
                    tempModules = new List<GameObject>(modules);

                    if (Tiles.TryGetValue(new Vector2(x, y), out TileInfo _info))
                    {
                        //Filtrerar ut de moduler some inte ska vara.
                        for (int i = 0; i < tempModules.Count; i++)
                        {
                            for (int k = 0; k < _info.objs.Count; k++)
                            {
                                if (tempModules[i].GetComponent<ModuleInfo>().id == _info.objs[k])
                                {
                                    tempModules.RemoveAt(i);
                                    i--;
                                    break;
                                }
                            }
                        }
                    }
                    if (tempModules.Count == 0)
                    {
                        Debug.Log("shit");
                        tempModules = new List<GameObject>{modul};
                    }



                    //Gör modulen och sätter position
                    GameObject mod = Instantiate(tempModules[Random.Range(0, tempModules.Count)]);

                    SetTile(mod, new Vector3(x,y,0f));
                }
            }
        }
    }
    void SetTile(GameObject mod, Vector3 pos)
    {
        mod.transform.position = new Vector3(pos.x * 10, pos.y * 10, 0f);
        mod.transform.parent = this.transform;
        TilesSet.Add(new Vector2(pos.x, pos.y), true);
        //Ändrar nästkommande information om tiles
        ChangeTileInfo(mod.GetComponent<ModuleInfo>(), new Vector2(pos.x, pos.y));
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
                    if (Tiles.TryGetValue(pos[k] + position, out TileInfo _info))
                    {
                        _info.objs.Add(objcts[i]);
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

    void ChangeTileInfoInArea(List<int> UnWantedIds, Vector2 from, Vector2 to)
    {
        for (int y = (int)from.y; y < to.y; y++)
        {
            for (int x = (int)from.x; x < to.x; x++)
            {
                for (int i = 0; i < UnWantedIds.Count; i++)
                {
                    Vector2 pos = new Vector2(x, y);
                    TilesSet.TryGetValue(pos, out bool bol);

                    if (!bol)
                    {
                        if (Tiles.TryGetValue(pos, out TileInfo _info))
                        {
                            _info.objs.Add(UnWantedIds[i]);
                            Tiles.Remove(pos);
                            Tiles.Add(pos, _info);
                        }
                        else
                        {

                            TileInfo _tileInfo = new TileInfo();
                            _tileInfo.objs.Add(UnWantedIds[i]);
                            Tiles.Add(pos, _tileInfo);
                        }
                    }
                }
            }
        }
    }



    void ChangeTileInfoToPoint(GameObject mod, Vector2 to)
    {
        ModuleInfo info = mod.GetComponent<ModuleInfo>();
        //List<int> UnWantedIds = new List<int>(info.Unwanted);
        float k = to.y / to.x;
        float y;
        for (int x = 0; x < Mathf.Abs(to.x); x++)
        {

            y = x * k * Mathf.Sign(to.x);
            y = (int)y;
            Vector2 pos = new Vector2((int)(x * Mathf.Sign(to.x)), y);
            TilesSet.TryGetValue(pos, out bool bol);

            if (!bol)
            {
                GameObject dule = Instantiate(mod);
                ChangeTileInfo(info, pos);
                SetTile(dule, pos);
                //for (int i = 0; i < UnWantedIds.Count; i++)
                //{
                //    //if (Tiles.TryGetValue(pos, out TileInfo _info))
                //    //{
                //    //    _info.objs.Add(UnWantedIds[i]);
                //    //    Tiles.Remove(pos);
                //    //    Tiles.Add(pos, _info);
                //    //}
                //    //else
                //    //{

                //    //    TileInfo _tileInfo = new TileInfo();
                //    //    _tileInfo.objs.Add(UnWantedIds[i]);
                //    //    Tiles.Add(pos, _tileInfo);
                //    //}

                //}
            }
        }
    }
    void ChangeTileInfoFunction(GameObject mod)
    {
        ModuleInfo info = mod.GetComponent<ModuleInfo>();
        float y;
        for (int x = 0; x < 100; x++)
        {

            y = Mathf.Sin(x) * 3f;
            y = (int)y;
            Vector2 pos = new Vector2(x, y);
            TilesSet.TryGetValue(pos, out bool bol);

            if (!bol)
            {
                GameObject dule = Instantiate(mod);
                ChangeTileInfo(info, pos);
                SetTile(dule, pos);
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
