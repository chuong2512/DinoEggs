using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum State
{
    Start,
    Playing,
    Lose,
}

public class GameManager : Singleton<GameManager>
{
    public State currentState = State.Start;

    public TextMeshProUGUI point, highPoint;

    public GameObject tap;

    public GameObject[] respawns;

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Restart(bool up)
    {
        if (up)
        {
            Data.Player.LevelUP();
        }

        SceneManager.LoadScene("Game");
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentState != State.Playing)
        {
            SetState(State.Playing);
            tap.SetActive(false);
            PlayerController.Instance.Play();
        }
    }

    private bool CheckWin()
    {
        return true;
    }

    public void MoveColor(TesterTube tube)
    {
    }


    public void Help()
    {
    }

    public void ShowLose()
    {
        Time.timeScale = 0;

        SetState(State.Lose);
        Manager.ScreenManager.OpenScreen(ScreenType.Lose);

        /*point.SetText($"Your Eggs : {TheLevelTMP.Instance.point}");

        DirGameDataManager.Ins.playerData.SetPoint(TheLevelTMP.Instance.point);

        highPoint.SetText($"Best Eggs : {DirGameDataManager.Ins.playerData.point}");*/
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    public void Continue()
    {
        Time.timeScale = 1;

        respawns = GameObject.FindGameObjectsWithTag("Enemy");

        if (respawns != null)
        {
            foreach (GameObject respawn in respawns)
            {
                Destroy(respawn);
            }
        }

        SetState(State.Playing);
    }
}