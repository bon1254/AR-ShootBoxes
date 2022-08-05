using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public Text Scoretext;

    void Update()
    {
        Scoretext.text = "Points ：" + playerStats.Score.ToString();
    }
}
