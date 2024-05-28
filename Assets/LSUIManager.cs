using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LSUIManager : MonoBehaviour
{

    public static LSUIManager Instance;

    public TextMeshProUGUI lNameText;

    public GameObject lNamePanel;


    public TextMeshProUGUI coinsText;
    void Awake()
    {
        Instance = this;
    }

    
    void Update()
    {
        
    }
}
