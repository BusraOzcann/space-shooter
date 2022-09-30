using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float damage = 20f;

    public float speed = 8f;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(GameManager.Instance.state == GameState.Play) transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= GameManager.Instance.screenBounds.y + 2f || transform.position.y <= (GameManager.Instance.screenBounds.y * -1) - 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
