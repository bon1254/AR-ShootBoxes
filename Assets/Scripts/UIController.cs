using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public SpawnBoxes spawnBoxes;
    public SoundsManager soundsManager;
    public PlayerStats playerStats;
    public SceneFader sceneFader;

    public const string HardMode_Bestscore = "CgkIvKzGmPUTEAIQAQ";

    [Header("UI")]
    public GameObject ChoseModeUI;
    public GameObject TeachUI;
    public GameObject ScoreUI;
    public Text ScoreText;
    public GameObject GameUI;
    public Text DebugText;

    [Header("Animator")]
    public Animator animatorTeachUI;
    public Animator animatorChoseModeUI;
    public Animator animatorGameUI;
    public Animator animatorScoreUI;

    public void Start()
    {
        animatorTeachUI.SetBool("IsOpening", true);
        //先跳出教學介面
    }

    public void OpenChoseMode() 
    {
        //開始選擇難易度按鈕
        soundsManager.ButtonSound01();
        animatorTeachUI.SetBool("IsClosing", true);

        Invoke("OpenChoseModeUI", 1);
        //選擇完後關掉
    }

    void OpenChoseModeUI()
    {
        ChoseModeUI.SetActive(true);
        animatorChoseModeUI.SetBool("IsOpening", true);
        //開起選擇難易度介面

        TeachUI.SetActive(false); //關閉教學介面
    }

    public void CloseChoseModeUI() 
    {
        animatorChoseModeUI.SetBool("IsClosing", true);
        Invoke("ChoseModeUIClosing", 1);
        //選擇完難易度然後關掉
    }

    void ChoseModeUIClosing()
    {
        ChoseModeUI.SetActive(false);
    }


    public void GameOver()
    {
        Invoke("CloseGameUI", 1);

        animatorGameUI.SetBool("IsClosing", true);

        ScoreUI.SetActive(true);
        ScoreText.text = playerStats.Score.ToString();

        animatorScoreUI.SetBool("IsOpening", true);
    }

    public void SubmitScore()
    {
        if (spawnBoxes.IsHardMode == true)
        {
            long scorepoints = Convert.ToInt64(playerStats.Score);
            GooglePlayLeaderBoard.Instance.reportScore(scorepoints);
            DebugText.text = "Report scroe success!!" + DebugText.text.ToString();
        }
    }

    public void CloseGameUI()
    {
        GameUI.SetActive(false);
    }

    public void GoToMenu()
    {
        sceneFader.FadeTo("Main");
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
