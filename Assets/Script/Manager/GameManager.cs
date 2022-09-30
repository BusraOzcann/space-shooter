using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    public static GameManager Instance { get; private set; }
    public Vector2 screenBounds;
    public int playerSkore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Camera.main.orthographicSize = 5f; //Her zaman 5 olmal� cunku resim konumland�rmalar� hierarchy'den 5'e gore ayarland�. De�i�ilirse background startPos y ekseni de�i�meli.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        UpdateGameState(GameState.WaitingPanel);
    }



    public void UpdateGameState(GameState newState)
    {
        state = newState;
    }

}

public enum GameState
{
    WaitingPanel,
    Play,
    StopGame,
    HighestScore,
    Score
}
