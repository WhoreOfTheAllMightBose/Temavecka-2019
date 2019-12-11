using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControllerScript : MonoBehaviour
{

    public static LevelControllerScript instance = null;


    int sceneIndex, levelPassed;


    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
            instance = this;
     //   else if (instance != null)
       //     Destroy(gameObject);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }


    public void YouWin()
    {
        if (sceneIndex == 3)
            print("you win");
        else
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            Invoke("loadNextLevel", 1f);
        }
    }

    public void GoBack()
    {
        Invoke("loadNextLevel", 1f);
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);

    }

    void loadLevelMenue()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    void YouLose()
    {

        Invoke("LoadNextLevel", 1f);
    }
}
