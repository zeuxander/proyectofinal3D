using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPickup : MonoBehaviour
{


    public int healAmount;
    public bool isFullHeal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Destroy(gameObject);

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
