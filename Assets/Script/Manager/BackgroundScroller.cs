using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;
    public Vector2 tempScale;
    public Vector3 startPosition;
    private SpriteRenderer sprite;
    private float newY_pos;

    void Start()
    {
        newY_pos = Camera.main.orthographicSize * 3f;
        transform.position = startPosition;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        tempScale = transform.localScale;

        float spriteWidth = sprite.size.x;
        float spriteHeight = sprite.size.y;

        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = Camera.main.orthographicSize * 2f;

        tempScale.x = screenWidth / spriteWidth;
        tempScale.y = screenHeight / spriteHeight;
        transform.localScale = tempScale;
    }

    void FixedUpdate()
    {
        if(GameManager.Instance.state == GameState.Play)
        {
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
            if (transform.position.y <= 0 - (Camera.main.orthographicSize * 2f)) // Aþagý dogru hareket oldugu için -- ve resmin yuksekligi Camera.main.orthographicSize * 2f 'e eþit oldugu için
            {
                Vector3 position = transform.position;
                position.y = newY_pos - (speed * Time.deltaTime);
                transform.position = position;
            }
        }
    }

}
