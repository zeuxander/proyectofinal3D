
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSLevelEntry : MonoBehaviour
{

    public string levelName, levelToCheck;
    public bool canLoadLevel;

    public GameObject mapPointActive, mapPointInactive;

    private bool _levelUnlocked;

    private bool levelLoading;

    private void Start()
    {
        if(PlayerPrefs.GetInt(levelToCheck + "_unloked") == 1 || levelToCheck == "")
        {
            mapPointActive.SetActive(true);
            mapPointInactive.SetActive(false);
            _levelUnlocked = true;
        }
        else
        {
            mapPointActive.SetActive(false);
            mapPointInactive.SetActive(true);
            _levelUnlocked=false;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && canLoadLevel && _levelUnlocked && !levelLoading) 
        {
            StartCoroutine("LevelLoadWaiter");
            levelLoading = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            canLoadLevel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = false;
        }
    }
    
    public IEnumerator LevelLoadWaiter()
    {
        PlayerController.instance.stopMove = true;
        UIManager.Instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelName);
    }
}
