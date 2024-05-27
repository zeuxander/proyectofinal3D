using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int maxHealt = 1;
    private int currentHealt;

    public int deathSound;

    public GameObject deathEffect, itemDrop;

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealt;

    }

    public void TakeDamage()
    {
        currentHealt--;
        if(currentHealt <= 0 )
        {
            AudioManager.instance.PlaySFX(deathSound);
            Destroy(gameObject);

            Instantiate(deathEffect, transform.position,transform.rotation);
           //para tirar obejtos  Instantiate(itemDrop, transform.position, transform.rotation);
        }

        PlayerController.instance.Bounce();
    }
}
