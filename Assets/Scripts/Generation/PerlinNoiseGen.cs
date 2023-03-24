using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseGen : MonoBehaviour
{
    [SerializeField] private int width;

    [SerializeField] private int height;

    public Dictionary<Vector2, bool> TilesSet = new Dictionary<Vector2, bool>();

    public float scale;
    public float Multiplier;

    public List<GameObject> blocks = new List<GameObject>();

    public Transform player;

    Vector2 currentPos;
    public int RenderDistance;
    public bool generating = true;

    Vector2 randPos;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                TilesSet.Add(new Vector2(i, j), true);

            }
        }
        randPos = new Vector2(Random.Range(1000, 100000), Random.Range(1000, 100000)); ;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object with tag 'Player' not found");
        }
    }

    private void Update()
    {
        RenderGeneration();

    }
    void RenderGeneration()
    {
        currentPos = new Vector2Int(Mathf.FloorToInt(player.position.x + 1), Mathf.FloorToInt(player.position.y + 1));

        for (int y = (int)currentPos.y - RenderDistance; y <= (int)currentPos.y + RenderDistance; y++)
        {
            for (int x = (int)currentPos.x - RenderDistance; x <= (int)currentPos.x + RenderDistance; x++)
            {
                if (!TilesSet.TryGetValue(new Vector2(x, y), out bool bol))
                {
                    PlaceBlock(new Vector2(x, y));
                    TilesSet.Add(new Vector2(x, y), true);
                }
            }
        }
    }

    void Generate()
    {
        for (float y = 0; y < height; y++)
        {
            for (float x = 0; x < width; x++)
            {


                PlaceBlock(new Vector2(x, y));
            }
        }
    }
    void PlaceBlock(Vector2 pos)
    {
        float value = Mathf.PerlinNoise((pos.x + randPos.x) / width * scale, (pos.y + randPos.y) / height * scale) * Multiplier;
        GameObject blocc;
        if (value > 0.5f)
        {
            blocc = Instantiate(blocks[0], pos, new Quaternion(0f, 0f, 0f, 0f));
            blocc.transform.parent = gameObject.transform;

        }
        else if (value < 0.2f)
        {

        }
        else
        {
            blocc = Instantiate(blocks[1], pos, new Quaternion(0f, 0f, 0f, 0f));
            blocc.transform.parent = gameObject.transform;

        }
    }
}
