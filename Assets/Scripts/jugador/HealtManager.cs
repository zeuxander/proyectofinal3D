using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
   public static HealtManager instance;

    public int currentHealt, maxHealth;

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
        
    }

    public void Hurt()
    {
        currentHealt--;

        if (currentHealt <=0)
        {
            currentHealt = 0;
            GameManager.Instance.Respawn();
        }
        else
        {
            PlayerController.instance.Knockback();
        }
    }
}
