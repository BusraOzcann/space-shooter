using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject in_gamePanel;
    public GameObject waitingPanel;
    public GameObject stoppedGamePanel;

    private void Start()
    {
        // GameState oyun ba�lang�c�nda WaitingPanel modunda ba�l�yor!
        waitingPanel.SetActive(true);
        in_gamePanel.SetActive(false);
        stoppedGamePanel.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(true);
        stoppedGamePanel.SetActive(false);
    }

    public void StopGame()
    {
        GameManager.Instance.UpdateGameState(GameState.WaitingPanel);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(false);
        stoppedGamePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        waitingPanel.SetActive(false);
        in_gamePanel.SetActive(true);
        stoppedGamePanel.SetActive(false);
    }

    //private void Update()
    //{
    //    if (GameManager.Instance.state == GameState.WaitingPanel || GameManager.Instance.state == GameState.StopGame)
    //    {
    //        Debug.Log("�fe girdi");
            
    //    }
    //    else if (GameManager.Instance.state == GameState.Play)
    //    {
    //        Debug.Log("else �fe girdi");
    //        waitingPanel.SetActive(false);
    //        in_gamePanel.SetActive(true);
    //    }
    //}
}
