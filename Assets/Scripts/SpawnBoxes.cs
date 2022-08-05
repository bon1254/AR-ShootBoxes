using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    public UIController uIController;
    public SoundsManager soundsManager;

    [Header("Timer")]
    public Timer timer;
    public bool timerStartCountdown = false;

    public Transform[] SpawnPoints;
    public GameObject[] Boxes;

    public bool IsHardMode = false;

    public void EasyMode_StopSpawning()
    {
        StopCoroutine(EasyMode_StartSpawning());
    }

    public void NormalMode_StopSpawning()
    {
        StopCoroutine(NormalMode_StartSpawning());
    }

    public void HardMode_StopSpawning()
    {
        StopCoroutine(HardMode_StartSpawning());
    }


    public void EasyModeStartSpawn()
    {
        soundsManager.ButtonSound01();
        StartCoroutine(EasyMode_StartSpawning());
        uIController.CloseChoseModeUI();
        timerStartCountdown = true;

        timer.CountTime();
    }

    public void NormalModeStartSpawn()
    {
        soundsManager.ButtonSound01();
        StartCoroutine(NormalMode_StartSpawning());
        uIController.CloseChoseModeUI();
        timerStartCountdown = true;

        timer.CountTime();
    }

    public void HardModeStartSpawn()
    {
        IsHardMode = true;

        soundsManager.ButtonSound01();
        StartCoroutine(HardMode_StartSpawning());
        uIController.CloseChoseModeUI();
        timerStartCountdown = true;

        timer.CountTime();
    }

    public IEnumerator EasyMode_StartSpawning()
    {
        GameObject boxes = Boxes[Random.Range(0, Boxes.Length)];
        Transform points = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        int timerRandom = (int)Random.Range(2f, 3f);

        yield return new WaitForSeconds(timerRandom);

        Instantiate(boxes, points.position, Quaternion.identity);

        StartCoroutine(EasyMode_StartSpawning());
    }

    public IEnumerator NormalMode_StartSpawning()
    {
        GameObject boxes = Boxes[Random.Range(0, Boxes.Length)];
        Transform points = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        int timerRandom = (int)Random.Range(1.5f, 2f);

        yield return new WaitForSeconds(timerRandom);

        Instantiate(boxes, points.position, Quaternion.identity);

        StartCoroutine(NormalMode_StartSpawning());
    }

    public IEnumerator HardMode_StartSpawning()
    {
        GameObject boxes = Boxes[Random.Range(0, Boxes.Length)];
        Transform points = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        int timerRandom = (int)Random.Range(0.2f, 1.2f);

        yield return new WaitForSeconds(timerRandom);

        Instantiate(boxes, points.position, Quaternion.identity);

        StartCoroutine(HardMode_StartSpawning());
    }
}
