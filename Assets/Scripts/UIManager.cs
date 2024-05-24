using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    public Image blackScreen;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    public TextMeshProUGUI healthText;
    public Image healthImage;

    public TextMeshProUGUI coinText;


    public GameObject pauseScreen, optionsScreen;

    public Slider musicVolSlider, sfxVolSlider;
    private void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f)
            {

                fadeToBlack = false;
                fadeFromBlack = true;
            }


        }
        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }


        }

    }

    public void Resume()
    {
        GameManager.Instance.PauseUnpause();
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void LevelSelect()
    {

    }

    public void MainManu()
    {

    }

    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();

    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }
}