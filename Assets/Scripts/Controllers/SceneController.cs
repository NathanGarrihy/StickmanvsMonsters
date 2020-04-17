using UnityEngine;
using Utilities;    // scene names
// sceneManageent library - load, unload scenes
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool isPaused = false;

    //  Method for start button
    public void Start_OnClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.MAIN_MENU);
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
    
    // Method for restart button, works for every game scene
    public void Restart_OnClick()
    {
        SceneManager.UnloadSceneAsync(LevelSelect.currentLevel);
        SceneManager.LoadSceneAsync(LevelSelect.currentLevel, LoadSceneMode.Single);
    }

    // Method to direct user to main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU, LoadSceneMode.Single);
    }

    //  Method for pause button
    public void Options_OnClick()
    {
        if (isPaused == false)
        {
            SceneManager.LoadSceneAsync(SceneNames.OPTIONS_MENU,
                                            LoadSceneMode.Additive);
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            isPaused = false;
            Options_offClick();
        }
    }

    //  Method used with Options_OnClick()
    public void Options_offClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.OPTIONS_MENU);
        isPaused = false;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    private void Start()
    {
        //  Fix for time scale glitch
        //  https://answers.unity.com/questions/802253/how-to-restart-scene-properly.html
        if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
