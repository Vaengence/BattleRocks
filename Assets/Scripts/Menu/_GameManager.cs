// Author: Michael Stojsic 2016.
// NOTE: Attach this script tot the 'Game Manager' Object and remember to set execution order,
//       (edit > Project Settings > Script Execution Order > Set GameManger to -100)
//       so GameManager runs a little earlier than all other scripts in the game, 
//       otherwise values taken from _GameManager.instance may not be initialised yet and result in incorrect values used.
// - This script will manage any variables used between multiple scenes like scores, timers and current level loaded.
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    // ---------------------------- VARIABLES ----------------------------
    private static _GameManager _instance;               // - Internal GameManager reference.
    public static _GameManager instance                  // - External GameManager reference for all other scenes.
    #region GameManager instance.       
    {
        get
        {
            if(_instance != null)                       // - If _instance not null.
            {
                return _instance;                       // - Return current _instance.
            }
            else                                        // - Else if _instance not null.
            {
                GameObject gameManager = new GameObject("GameManager");     // - Set gameMnager as a new GO called GameManager.
                _instance = gameManager.AddComponent<_GameManager>();        // - Add GameManager script to that new GO _instance.
                return _instance;                                           // - Return than new instance of GameManager as _instance.
            }
        }
    }
    #endregion
    // GLOBAL VARIABLES.

    public bool soundOn = true;
    public bool musicOn = true;

    // LEVEL VARIABLES. 
    public int[] unlockedLevels = new int[]                     // - Stores which levels are currently unlocked. 1 = unlocked, 0 = locked. used ints rathen than bool as easier to save and load imo.
    {
        0,  // [0] Currently unused to keep code readable and understandable.
        1,  // [1] level 1
        0,  // [2] level 2
        0,  // [3] level 3
        0,  // [4] level 4
        0,  // [5] level 5

        // NOTE: ADD NEW ELEMENTS AS WE ADD LEVELS.
    };
    public int currentLevel = 1;                                // - Stores current level played.
    public bool levelFinished = false;                          // - Stores whether player has finished current level or not.
    public string lastLevelPlayed;                              // - Stores the last level played, set each time a level is loaded and is then used by the Continue button in the Main menu
    // ---------------------------- START ----------------------------
    void Start () 
    {
        // Set _instance as this script.
        if(_instance != this)                                   // - If _instance isnt this GameManager.
        {
            if(_instance == null)                               // - If no _instance of GameManager.
            {
                _instance = this;                               // - Set _instance to this GameManager.
            }
            else                                                // - If one already exists.
            {
                Destroy(gameObject);                            // - Destory this extra one.
            }
        }
        LoadGame();                                             // - Call LoadGame to Load Save Data.
        DontDestroyOnLoad(gameObject);                          // - Prevents this object being destoried between scenes.
    }
    // ---------------------------- UPDATE ----------------------------
    void Update () 
    {
    // NOTE: TEMP WAY TO SAVE GAME FOR NOW! 
    //       DELETE THIS FUNCTION LATER!
        if(Input.GetKeyDown(KeyCode.S))                         // - If 'S' key is pressed down.
        {
            SaveGame();                                         // - Call SaveGame to save data.
        }
    }
    // ---------------------------- SAVE GAME ----------------------------
    // - Saves all important variables to playerPrefs.  Not accesable directly by outside scripts.
    void SaveGame()
    {
        // Saves Unlocked Levels.
        for (int i = 0; i < unlockedLevels.Length; i++)                                             // - For loop through unlockedLevels.
        {
            PlayerPrefs.SetInt("Unlocked Levels" + i.ToString(), unlockedLevels[i]);                // - Set playerPrefs UnlockedLevel 'i' as unlockedLevels index 'i'.
        }
        PlayerPrefs.SetString("Last Level Played", lastLevelPlayed);                                // - Set playerPrefs Last Level Played to lastLevelplayed as string .
    }
    // ---------------------------- LOAD GAME ----------------------------
    // - Loads all important variables from playerPrefs. Not accesable directly by outside scripts.
    void LoadGame()
    {
        // Loads Unlocked Levels.
        for (int i = 0; i < unlockedLevels.Length; i++)                                             // - For loop through unlockedLevels.
        {
            unlockedLevels[i] = PlayerPrefs.GetInt("Unlocked Levels" + i.ToString());               // - Set unlockedLevels 'i' as playerPrefs Unlocked Levels index 'i'.
        }
        lastLevelPlayed = PlayerPrefs.GetString("Last Level Played");                               // - Set lastLevelplayed to playerPrefs Last Level Played as string.
    }
    // ---------------------------- DELETE SAVE DATA ----------------------------
    // - Deletes all important variables from playerPrefs and sets the variables values to defaults 
    //   then saves over them again is playerPrefs.
    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();                                    // - Deletes all playerPrefs.
        for(int i = 0; i < unlockedLevels.Length; i++)              // - For loop through unlockedLevels.
        {
            unlockedLevels[i]=0;                                    // - Reset each index of unlocked levels to 0 to re-lock them all.
        }      
        unlockedLevels[1] = 1;                                      // - Set index 1 of unlockedlevels to 1, so first level of game is unlocked when we clear our save.

        // lastLevelPlayed = "first level";                          // - Set lastlevelPlayed to 1st level in the game so new game button runs correct level on new game.
        SaveGame();                                                 // - Call SaveGame to save new values as the saved values.
        SceneManager.LoadScene("MenuMain");                         // - Load up Main_Menu scene.
    }   
    // ---------------------------- RESET GAME ----------------------------
    // - This will be called when the level is reset to reset all the values
    //   for each level back to a clean default for the next run of it.
    public void ResetGame()
    {
        // NOTE: ADD - add any variable that need to be reset at end of level
        levelFinished = false;              // - Set levelFinished to true to tell all scripts the current level was finished.
    }
    // ---------------------------- START GAME LEVEL ----------------------------
    public void StartGameLevel()
    // - This is called at the start of each level - 
    // NOTE: This can be merged with RESET GAME if nt needed
    {
        levelFinished = false;              // - Set LevelFinished to false as level has just started.
    }
}
