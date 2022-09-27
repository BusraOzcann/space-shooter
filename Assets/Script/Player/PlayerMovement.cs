using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startPos;
    public GameObject laser;
    public GameObject laserpos_left;
    public GameObject laserpos_right;
    public float Timer = 0;

    [Header("Movement")]
    [SerializeField] private Vector3 objectSizes;
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] private float speed = 15f;
    [SerializeField] private Touch touch;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        objectSizes = gameObject.transform.localScale;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        startPos = Vector3.zero;
        startPos.y = 0 - (screenBounds.y / 1.5f);
        transform.position = startPos;
    }


    void Update()
    {
        playerScreenBoundaries();

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0));

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (Input.touchCount > 0)
            {
                // get the first one
                Touch firstTouch = Input.GetTouch(0);

                if (firstTouch.phase == TouchPhase.Moved)
                {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(firstTouch.position);
                    touchPosition.z = 0;
                    transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
                    Timer -= Time.deltaTime;
                    if (Timer <= 0f)
                    {
                        Instantiate(laser, laserpos_left.transform.position, Quaternion.identity);
                        Instantiate(laser, laserpos_right.transform.position, Quaternion.identity);
                        Timer = 0.4f;
                    }
                    
                }
            }
        }
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
}
