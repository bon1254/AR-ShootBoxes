using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    [Header("UI")]
    public Button[] Buttons;

    [Header("Audio")]
    public SoundsManager soundsManager;

    [Header("Menus")]
    public GameObject LoginMenu;
    public GameObject TitleMenu;
    public GameObject OptionMenu;

    [Header("Animator")]
    public Animator LoginMenuFadeOutAnimator;
    public Animator TitleMenuFadeOutAnimator;

    [Header("SceneFader")]
    public string levelToload = "MainScene";
    public SceneFader sceneFader;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = true;
        }
    }

    // Start is called before the first frame update
    public void GoMainScene()
    {
        sceneFader.FadeTo(levelToload);

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }

    public void OpenOptionMenu()
    {
        TitleMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void CloseOptionMenu()
    {
        TitleMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }

    public void FadeOutLoginMenu_FadeInTitleMenu()
    {
        LoginMenuFadeOutAnimator.SetBool("IsLoginMenuFadeOut", true);
        TitleMenu.SetActive(true);
        TitleMenuFadeOutAnimator.SetBool("IsTitleMenuFadeIn", true);
        Invoke("CloseLoginMenu", 0.7f);
    }

    void CloseLoginMenu()
    {
        LoginMenu.SetActive(false);
    }
}
