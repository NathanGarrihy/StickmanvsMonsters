using UnityEngine.SceneManagement;
using Utilities;
using UnityEngine;

public class TutorialMenuController : MonoBehaviour
{
    public GameObject screen1menu, screen2menu, screen3menu;
    private short screenMenu = 1;

    // Called when player clicks next page button
    public void nextPage()
    {
        if (screenMenu == 1)
        {
            screen1menu.SetActive(false);
            screen2menu.SetActive(true);
            screenMenu = 2;
        }
        else if (screenMenu == 2)
        {
            screen2menu.SetActive(false);
            screen3menu.SetActive(true);
            screenMenu = 3;
        }
        else if (screenMenu == 3)
        {
            screen3menu.SetActive(false);
            screen1menu.SetActive(true);
            screenMenu = 1;
        }
    }

    // Called when player clicks previous page button
    public void prevPage()
    {
        if (screenMenu == 2)
        {
            screen2menu.SetActive(false);
            screen1menu.SetActive(true);
            screenMenu = 1;
        }
        else if (screenMenu == 3)
        {
            screen3menu.SetActive(false);
            screen2menu.SetActive(true);
            screenMenu = 2;
        }
        else if (screenMenu == 1)
        {
            screen1menu.SetActive(false);
            screen3menu.SetActive(true);
            screenMenu = 3;
        }
    }

    //  Directs player back to main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU, LoadSceneMode.Single);
    }

}




