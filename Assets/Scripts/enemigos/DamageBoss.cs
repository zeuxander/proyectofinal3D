using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Playe")
        {
            BossController.instance.DamageBoss();
        }
    }
}
