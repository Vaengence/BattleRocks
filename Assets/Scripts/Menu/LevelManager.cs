using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEditor;

public class LevelManager : MonoBehaviour
{

    static LevelManager SceneController;

    public enum SceneOptions
    {
        SPLASH_SCREEN = 0,
        MAIN_MENU = 1,
        OPTIONS = 2,
        STORE = 3,
        INVENTORY = 4,
        BATTLE = 5,
        EXIT = 6
    };

    private SceneOptions CurrentScene; // Initial On load indication of which screen we are on

    Dictionary<int, string> SceneIndexArray;

    // Use this for initialization
    void Start()
    {

        if (SceneController == null)
        {
            DontDestroyOnLoad(gameObject);
            SceneController = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CurrentScene = (SceneOptions)SceneManager.GetActiveScene().buildIndex;
        for (int i = 0; i < Enum.GetNames(typeof(SceneOptions)).Length; i++)
        {
            SceneIndexArray.Add(i, "Loading Screen");
            SceneIndexArray.Add(i, "MainMenu");
            SceneIndexArray.Add(i, "OptionsMenu");
            SceneIndexArray.Add(i, "Store");
            SceneIndexArray.Add(i, "Battle Scene");
            SceneIndexArray.Add(i, "Exit Scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentScene)
        {
            case SceneOptions.SPLASH_SCREEN:
                if (SceneManager.GetActiveScene().buildIndex != (int)SceneOptions.SPLASH_SCREEN)
                    SceneManager.LoadScene((int)SceneOptions.SPLASH_SCREEN);
                break;
            case SceneOptions.MAIN_MENU:
                if (SceneManager.GetActiveScene().buildIndex != (int)SceneOptions.MAIN_MENU)
                    SceneManager.LoadScene((int)SceneOptions.MAIN_MENU);
                break;
            case SceneOptions.OPTIONS:
                if (SceneManager.GetActiveScene().buildIndex != (int)SceneOptions.OPTIONS)
                    SceneManager.LoadScene((int)SceneOptions.OPTIONS);
                break;
            case SceneOptions.STORE:
                if (SceneManager.GetActiveScene().buildIndex != (int)SceneOptions.STORE)
                    SceneManager.LoadScene((int)SceneOptions.STORE);
                break;
            case SceneOptions.BATTLE:
                if (SceneManager.GetActiveScene().buildIndex != (int)SceneOptions.BATTLE)
                    SceneManager.LoadScene((int)SceneOptions.BATTLE);
                break;
            case SceneOptions.EXIT:
                if (SceneManager.GetActiveScene().buildIndex != (int)SceneOptions.EXIT)
                    SceneManager.LoadScene((int)SceneOptions.EXIT);
                break;
        }

    }

    public void SetCurrentScene(string NewScene)
    {
        CurrentScene = (SceneOptions)Enum.Parse(typeof(SceneOptions), NewScene);
    }

    public void LoadScene(string NewScene)
    {
        /* EditorBuildSettingsScene[] allScenes = EditorBuildSettings.scenes;
         Debug.Log("All Scenes : Length : " + allScenes.Length);
         string path;
         for (int i = 0; i < allScenes.Length; i++)
         {
             Debug.Log("All Path : Scene : " + allScenes[i].path);
             path = Path.GetFileNameWithoutExtension(allScenes[i].path);
             Debug.Log("Clear Path : Scene : " + path);
         }
         */
        SceneManager.UnloadScene((int)CurrentScene);
        CurrentScene = (SceneOptions)Enum.Parse(typeof(SceneOptions), NewScene);
        //SceneManager.LoadScene((int)CurrentScene);
        //SceneManager.LoadScene(SceneIndexArray[(int)CurrentScene]);
        //Scene NextScene = SceneManager.GetActiveScene();
        //Scene TestScene = SceneManager.GetSceneByPath(allScenes[(int)CurrentScene].path);
        //SceneManager.SetActiveScene(NextScene);
        if ((int)CurrentScene != 1)
        {
            SceneManager.LoadScene((int)CurrentScene, LoadSceneMode.Additive);
        }
    }
}