using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostValueScript : MonoBehaviour
{
    private Text textGhostsCount;

    
    void Start()
    {
        textGhostsCount = GetComponent<Text>();
    }

    void Update()
    {
        textGhostsCount.text = (Ghost.GhostGhostInstanceCount -1).ToString();
    }
}