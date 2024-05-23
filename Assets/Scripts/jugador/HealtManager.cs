using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
   public static HealtManager instance;

    public int currentHealt, maxHealth;

    public float invincibleLength = 2f;
    private float invincCounter;

    public Sprite[] healthBarImages;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       ResetHealth();
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
        UpdateUI(); 
    }

    public void ResetHealth()
    {
        currentHealt = maxHealth;
        UIManager.Instance.healthImage.enabled = true;
        UpdateUI();
    }

    public void AddHealt(int amountToHeal)
    {
        currentHealt += amountToHeal;
        if (currentHealt > maxHealth)
        {
            currentHealt = maxHealth;
        }

        UpdateUI(); 
    }

    public void UpdateUI()
    {
        UIManager.Instance.healthText.text = currentHealt.ToString();   

        switch(currentHealt)
        {
            case 5:
                UIManager.Instance.healthImage.sprite = healthBarImages[4];
                break;
            case 4:
                UIManager.Instance.healthImage.sprite = healthBarImages[3];
                break;
            case 3:
                UIManager.Instance.healthImage.sprite = healthBarImages[2];
                break;
            case 2:
                UIManager.Instance.healthImage.sprite = healthBarImages[1];
                break;
            case 1:
                UIManager.Instance.healthImage.sprite = healthBarImages[0];
                break;
            case 0:
                UIManager.Instance.healthImage.enabled = false;
                break;


        }

    }
    public void PlayerKilled()
    {
        currentHealt = 0;
        UpdateUI();
    }

}
