using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public UIController uIController;
    public SpawnBoxes spawnBoxes;
    public PlayerStats playerStats;

    public int TimeSeconds;
    public Text timerText;

    void PlayTimer()
    {
        if (spawnBoxes.timerStartCountdown == true)
        {
            TimeSeconds -= 1;

            timerText.text = TimeSeconds + "";

            if (TimeSeconds == 0)
            {
                if (playerStats.IsPlayerWin == true)
                {
                    return;
                }

                uIController.GameOver();
                CancelInvoke("PlayTimer");
            }
            else if (playerStats.IsPlayerWin == true)
            {
                CancelInvoke("PlayTimer");
            }
        }       
    }

    public void CountTime()
    {
        InvokeRepeating("PlayTimer", 1, 1);
    }
}
