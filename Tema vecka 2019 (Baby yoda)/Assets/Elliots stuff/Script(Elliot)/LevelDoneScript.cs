using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDoneScript : MonoBehaviour
{
    public Button Level02Button, Level03Button;
    int levelPassed;
        
    private void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Level02Button.interactable = false;
        Level03Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                {
                    Level02Button.interactable = true;
                    break;
                }
            case 2:
                {
                    Level02Button.interactable = true;
                    Level03Button.interactable = true;
                    break;
                }
        }
    }

    public void LevelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Relode()
    {

        Level02Button.interactable = false;
        Level03Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
