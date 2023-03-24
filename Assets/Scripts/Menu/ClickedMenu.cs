using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickedMenu : MonoBehaviour, IPointerClickHandler
{
    public GameObject characterScreen;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        string objectName = clickedObject.name;

        switch (objectName)
        {
            case "start":
            case "Start":
                StartGame();
                break;
            case "quit":
            case "Quit":
                Quit();
                break;
            case "Dwarf":
                Dwarf();
                break;
            case "Knight":
                Knight();
                break;
            case "Wizard":
                Wizard();
                break;
            case "Mechanic":
                Mechanic();
                break;
            case "Return":
                Return();
                break;

            default:
                Debug.Log("Object name not recognized");
                break;
        }
    }

    private void StartGame()
    {
        characterScreen.SetActive(true);
    }

    private void Quit()
    {
        Debug.Log(":)");
    }

    private void Dwarf()
    {
        Debug.Log("Dwarf");
        DataManager.Instance.player = 1;
        SceneManager.LoadScene("Generation");
    }

    private void Knight()
    {
        Debug.Log("Knight");
        DataManager.Instance.player = 2;
        SceneManager.LoadScene("Generation");
    }

    private void Wizard()
    {
        Debug.Log("Wizard");
        DataManager.Instance.player = 3;
        SceneManager.LoadScene("Generation");
    }

    private void Mechanic()
    {
        Debug.Log("Mechanic");
        DataManager.Instance.player = 4;
        SceneManager.LoadScene("Generation");
    }

    private void Return()
    {
        characterScreen.SetActive(false);
    }
}