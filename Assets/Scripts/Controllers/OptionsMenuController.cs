using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class OptionsMenuController : MonoBehaviour
{
    //  Takes in options Menu Game Object
    public GameObject OptionsMenu;

    //  Handles Back button on options menu
    public void OptionsBack_OnClick()
    {
        // if player is dead
        if (PlayerController.playerIsDead() == true)
        {
            SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU, LoadSceneMode.Single);
            // set player dead so pause button works on starting new level
            PlayerController.setPlayerDead(false);
        }
        // if player is not dead
        else
        {
            SceneManager.UnloadSceneAsync(SceneNames.OPTIONS_MENU);
            Time.timeScale = 1;
        }
        SceneController.isPaused = false;
    }

    //  Directs player to main menu
    public void GoToMainMenu()
    {
        SceneController.isPaused = false;
        SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
    }

}

//   Removed, found pause button to be better
/*  
public void Update()
{
    if (isPaused)
    {
        OptionsMenu.SetActive(true);
        Time.timeScale = 0f;
    } else if (!isPaused && PlayerController.playerIsDead() == false)
    {
        OptionsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    if (Input.GetKeyDown (KeyCode.Escape))
    {
        isPaused = !isPaused;
    }
} 
*/
