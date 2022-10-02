using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIInstance { get; private set; }

    public GameObject in_gamePanel;
    public GameObject waitingPanel;
    public GameObject stoppedGamePanel;
    public GameObject scorePanel;
    public TMP_Text scoreTxt;
    public TMP_Text playerHealthTxt;
    private void Start()
    {
        if (UIInstance != null && UIInstance != this)
        {
            Destroy(this);
        }
        else
        {
            UIInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        // GameState oyun baþlangýcýnda WaitingPanel modunda baþlýyor!
        WaitingPanel();
        UpdateScoreText(GameManager.Instance.playerScore.ToString());
    }

    public void WaitingPanel()
    {
        GameManager.Instance.UpdateGameState(GameState.WaitingPanel);
        waitingPanel.SetActive(true);
        in_gamePanel.SetActive(false);
        stoppedGamePanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(true);
        stoppedGamePanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void StopGame()
    {
        GameManager.Instance.UpdateGameState(GameState.WaitingPanel);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(false);
        scorePanel.SetActive(false);
        stoppedGamePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(true);
        stoppedGamePanel.SetActive(false);
        scorePanel.SetActive(false);
    }
    
    public void EndGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Score);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(false);
        stoppedGamePanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void UpdateScoreText(string val)
    {
        scoreTxt.text = "SKOR : " + val;
    }

    public void RestartGame()
    {
        GameManager.Instance.playerScore = 0;
        GameObject.FindObjectOfType<Player>().health = 100;
        GameObject.FindObjectOfType<PlayerMovement>().StartPos();
        WaitingPanel();
    }

    public void ChangePlayerHealth(string val)
    {
        playerHealthTxt.text = "CAN : " + val;
    }

}
