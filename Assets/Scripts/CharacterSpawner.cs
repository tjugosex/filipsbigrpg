using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    private void Awake()
    {
        int playerIndex = DataManager.Instance.player;

        // Check if the playerIndex is within the bounds of the characterPrefabs array
        if (playerIndex >= 1 && playerIndex <= characterPrefabs.Length)
        {
            // Instantiate the prefab at the position and rotation of the spawner
            GameObject character = Instantiate(
                characterPrefabs[playerIndex - 1],
                transform.position,
                transform.rotation);

            // You can add more logic here, like parenting the character to another object, etc.
        }
        else
        {
            Debug.LogError("Invalid player index");
        }
    }
}
