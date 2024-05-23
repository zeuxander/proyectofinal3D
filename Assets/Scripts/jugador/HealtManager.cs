using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
   public static HealtManager instance;

    public int currentHealt, maxHealth;

    public float invincibleLength = 2f;
    private float invincCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealt = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;

            for(int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if(Mathf.Floor(invincCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }
                if (invincCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
          
        }
    }

    public void Hurt()
    {
        if ((invincCounter <=0))
        {
            currentHealt--;

            if (currentHealt <= 0)
            {
                currentHealt = 0;
                GameManager.Instance.Respawn();
            }
            else
            {
                PlayerController.instance.Knockback();
                invincCounter = invincibleLength;
            }
       
        }
    }

    public void ResetHealth()
    {
        currentHealt = maxHealth;
    }

    public void AddHealt(int amountToHeal)
    {
        currentHealt += amountToHeal;
        if (currentHealt > maxHealth)
        {
            currentHealt = maxHealth;
        }
    }
}
