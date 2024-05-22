using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //print other.gameObject.tag = other.gameObject.tag;  
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.Respawn();
            print("muerte");
        }
    }

}
