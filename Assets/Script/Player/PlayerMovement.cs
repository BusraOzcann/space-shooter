using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startPos;
    private bool isMoving = false;
    public GameObject laser;
    public GameObject laserpos_left;
    public GameObject laserpos_right;
    public float Timer = -1.0f;

    [Header("Movement")]
    [SerializeField] private Vector3 objectSizes;
    [SerializeField] private Vector2 screenBounds;
     private Vector3 posOffset = new Vector3(0, 0.5f, 0);
    [SerializeField] private Touch touch;
    private float speed = 5f;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        objectSizes = gameObject.transform.localScale;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartPos();
    }


    void Update()
    {
        if(GameManager.Instance.state == GameState.Play)
        {
            playerScreenBoundaries();

            if (isMoving)
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    Fire();
                    Timer = 0.4f;
                }
            }

            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0));

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
                    {
                        isMoving = true;
                        transform.position = Vector2.MoveTowards(transform.position, touchPosition + posOffset, speed * Time.deltaTime);
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        //transform.position = new Vector3(transform.position.x + (touch.deltaPosition.x * speedModifier * Time.deltaTime), transform.position.y + (touch.deltaPosition.y * speedModifier * Time.deltaTime), transform.position.z);
                        touchPosition.z = 0;
                        //transform.position = Vector2.MoveTowards(transform.position, touchPosition + posOffset, speed * Time.deltaTime);
                        transform.position = touchPosition + posOffset;

                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        isMoving = false;
                    }
                }
            }
        }

        if (GameManager.Instance.state == GameState.Score || GameManager.Instance.state == GameState.Score || GameManager.Instance.state == GameState.WaitingPanel)
        {
            StartPos();
        }

    }
    public void StartPos()
    {
        startPos = Vector3.zero;
        startPos.y = 0 - (screenBounds.y / 1.5f);
        transform.position = startPos;
    }
    private void playerScreenBoundaries()
    {
        if (transform.position.y >= screenBounds.y - objectSizes.y / 2)
        {
            transform.position = (new Vector3(transform.position.x, screenBounds.y - objectSizes.y / 2, transform.position.z));
        }
        if (transform.position.y <= (screenBounds.y * -1) + objectSizes.y / 2)
        {
            transform.position = (new Vector3(transform.position.x, (screenBounds.y * -1) + objectSizes.y / 2, transform.position.z));
        }
        if (transform.position.x >= screenBounds.x - objectSizes.x / 2)
        {
            transform.position = (new Vector3(screenBounds.x - objectSizes.x / 2, transform.position.y, transform.position.z));
        }
        if (transform.position.x <= (screenBounds.x * -1) + objectSizes.x / 2)
        {
            transform.position = (new Vector3((screenBounds.x * -1) + objectSizes.x / 2, transform.position.y, transform.position.z));
        }
    }
    private void Fire()
    {
        Instantiate(laser, laserpos_left.transform.position, Quaternion.identity);
        Instantiate(laser, laserpos_right.transform.position, Quaternion.identity);
    }
}
