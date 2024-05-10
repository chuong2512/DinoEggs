using System;
using ChuongCustom;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Tween Tween;

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

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentState != State.Playing)
        {
            SetState(State.Playing);
            tap.SetActive(false);
            PlayerController.Instance.Play();

            CountScore();
        }
    }
    
    public void CountScore()
    {
        Tween = DOVirtual.DelayedCall(1f, () =>
        {
            ScoreManager.Score += 1;
        }).SetTarget(transform).SetLoops(-1);
    }

    private void OnDestroy()
    {
        Tween.Kill();
    }

    public void ShowLose()
    {
        
        Tween.Kill();
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