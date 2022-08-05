using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public UIController uicontroller;
    public TextMesh floatingtextscore;

    public float Health;
    public float StartHealth = 3;
    public bool IsPlayerWin = false;

    [HideInInspector]
    public float Score = 0f;  

    void Start()
    {
        Score = 0f;
        Health = StartHealth;
    }

    void Update()
    {

    }

    public void TakeDamge(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            uicontroller.GameOver();
        }
    }

    public void GetPoints()
    {
        float scores = 10f;

        floatingtextscore.text = "+ " + scores.ToString();

        Score += scores;
    }
}
