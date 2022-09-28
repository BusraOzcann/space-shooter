using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = 8f;

    Vector3 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        
        if(transform.position.y >= screenBounds.y + 2f)
        {
            Destroy(gameObject);
        }
    }
}
