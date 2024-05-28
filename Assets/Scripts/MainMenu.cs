using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

   
{

    public string firstLevel;

    public string levelSelect;

    public GameObject continueButton;

    public string[] levelName;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            ResetProgress();
        }
    }


    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetInt("Continue", 0); 
        PlayerPrefs.SetString("CurentLevel", firstLevel);

        ResetProgress();
    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetProgress()
    {
        for (int i = 0; i < levelName.Length; i++)
        {
            PlayerPrefs.SetInt(levelName[i] + "_unlocked", 0);
        }
    }

}
