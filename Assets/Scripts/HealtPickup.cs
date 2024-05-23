using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPickup : MonoBehaviour
{


    public int healAmount;
    public bool isFullHeal;
    public GameObject heartEffect;

    public int soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Destroy(gameObject);
            Instantiate(heartEffect, PlayerController.instance.transform.position + new Vector3(0f,1f,0f), PlayerController.instance.transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);

            if (isFullHeal)
            {
                HealtManager.instance.ResetHealth();
            }
            else
            {
                HealtManager.instance.AddHealt(healAmount);
            }
        }
    }
}
