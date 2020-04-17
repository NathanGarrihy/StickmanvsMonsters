using UnityEngine;
using Utilities;    // scene names

// sceneManageent library - load, unload scenes
using UnityEngine.SceneManagement;

//  Class used in level select scene
public class LevelSelect : MonoBehaviour
{
    //  static variable for current level player is on 
    //  Used with restart button
    public static string currentLevel = SceneNames.GAME_LEVEL;

    //  Self explainitary private methods
    private void LevelOne_OnClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.LEVEL_SELECT);
        currentLevel = SceneNames.GAME_LEVEL;
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void LevelTwo_OnClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.LEVEL_SELECT);
        currentLevel = SceneNames.GAME_LEVEL2;
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL2, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void LevelThree_OnClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.LEVEL_SELECT);
        currentLevel = SceneNames.GAME_LEVEL3;
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL3, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void LevelFour_OnClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.LEVEL_SELECT);
        currentLevel = SceneNames.GAME_LEVEL4;
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL4, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void LevelFive_OnClick()
    {
        SceneManager.UnloadSceneAsync(SceneNames.LEVEL_SELECT);
        currentLevel = SceneNames.GAME_LEVEL5;
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL5, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void Restart_OnClick()
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadSceneAsync(currentLevel, LoadSceneMode.Single);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU, LoadSceneMode.Single);
    }

}
