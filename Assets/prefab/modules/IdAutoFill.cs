using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdAutoFill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ModuleInfo info = gameObject.GetComponent<ModuleInfo>();
        if (info)
        {
            for (int x = -2; x < 2; x++)
            {
                for (int y = -2; y < 2; y++)
                {
                    info.Positions.Add(new Vector2(x,y));
                }
            }
        }
    }
}
