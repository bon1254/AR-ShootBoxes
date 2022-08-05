using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public Text healthtext;

    void Update()
    {
        healthtext.text = "Health ：" + playerStats.Health.ToString();
    }
}
