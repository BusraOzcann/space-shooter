using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> objectPool;
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
        Camera.main.orthographicSize = 5f; //Her zaman 5 olmalý cunku resim konumlandýrmalarý hierarchy'den 5'e gore ayarlandý. Deðiþilirse background startPos y ekseni deðiþmeli.
        objectPool = new List<GameObject>();
        
    }



    void Update()
    {
        
    }
}
