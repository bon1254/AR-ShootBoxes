using UnityEngine;
using UnityEngine.UI ;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayLeaderBoard : MonoBehaviour
{
    public static GooglePlayLeaderBoard Instance;

    private const string HardMode_Bestscore = "CgkIvKzGmPUTEAIQAQ";
    protected bool isLogged;

    public Text Messegetext;
    private Text reporttext;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Instance = this;     
    }

    public void Initialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestIdToken()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Instance.SignIn();
        MainMenu.Instance.FadeOutLoginMenu_FadeInTitleMenu();
    }

    public void SignIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                isLogged = true;
                Messegetext.text = "Logged in google play service" + Messegetext.text.ToString();
            }
            else
            {
                isLogged = false;
                Messegetext.text = "Unable to sign in google play service" + Messegetext.text.ToString();
            }
        });
    }
    

    public void reportScore(long score)
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {               
                Social.ReportScore(score, HardMode_Bestscore,               
                (bool success2) =>
                    {
                        reporttext = GameObject.Find("Canvas/ScoreUI/reportText").GetComponent<Text>();
                        reporttext.text = "Report is success" + reporttext.text.ToString();
                        //Handle Report Success 
                    }
                );
            }
        });        
    }
    
    public void ShowAllLeaderboard()
    {
        if (!isLogged)
        {
            return;
        }
        Social.ShowLeaderboardUI();
    }

    public void ShowScoreLeaderboard()
    {
        if (!isLogged)
        {
            return;
        }
        PlayGamesPlatform.Instance.ShowLeaderboardUI(HardMode_Bestscore);
    }
}
