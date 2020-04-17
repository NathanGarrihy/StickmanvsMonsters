using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class MainMenuController : MonoBehaviour
{
    // Takes in main & options menu Game Object
    public GameObject mainMenu;
    public GameObject optionsMenu;

    //  Plays game on default game scene
    public void playGame()
    {
        GameController.playerScore = 0;
        SceneManager.LoadScene(SceneNames.GAME_LEVEL);
        Time.timeScale = 1;
    }

    // Directs player to level select scene
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene(SceneNames.LEVEL_SELECT);
    }

    // Directs player to tutorial scene
    public void GoToTutorial()
    {
        SceneManager.LoadScene(SceneNames.TUTORIAL);
    }

    // Sets options menu as active menu
    public void options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    
    // Sets main menu as active menu
    public void back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    //  Closes the application
    public void exitGame()
    {
        Application.Quit();
    }
}
