using UnityEngine;
using UnityEngine.EventSystems;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int player;


    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    
}