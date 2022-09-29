using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    public float seniorSpeed = 2f;
    public float midSpeed = 2.5f;
    public float juniorSpeed = 3f;

    private float actualSpeed;

    void Start()
    {
        string tag = gameObject.tag;
        if (tag == "MidEnemyShip") actualSpeed = midSpeed;
        else if (tag == "SeniorEnemyShip") actualSpeed = seniorSpeed;
        else if (tag == "JuniorEnemyShip") actualSpeed = juniorSpeed;
        else actualSpeed = 0f;
    }

    void Update()
    {
        transform.position += new Vector3(0, actualSpeed * Time.deltaTime * -1, 0);
    }
}
