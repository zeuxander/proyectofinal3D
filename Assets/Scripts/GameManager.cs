using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance;

    private Vector3 respawnPosition;

    public GameObject deathEffect;

    

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        StartCoroutine("RespawnWaiter");
    }

    public IEnumerator RespawnWaiter()
    {
        PlayerController.instance.gameObject.SetActive(false);

        CameraController.instance.cmBrain.enabled = false;

        UIManager.Instance.fadeToBlack = true;

        Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);   

        yield return new WaitForSeconds(2f);

        UIManager.Instance.fadeFromBlack = true;

        

        PlayerController.instance.transform.position = respawnPosition;

        CameraController.instance.cmBrain.enabled = true;

        PlayerController.instance.gameObject.SetActive(true);

        HealtManager.instance.ResetHealth();
    }


    public void SetSpawnerPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("spawnset");
    }
}
