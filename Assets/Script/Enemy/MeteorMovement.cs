using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public float bigMeteorSpeed = 2f;
    public float midMeteorSpeed = 2.5f;
    public float smallMeteorSpeed = 3f;
    public float tinyMeteorSpeed = 3.5f;
    private string objectTag;
    void Start()
    {
        objectTag = gameObject.tag;
    }


    void Update()
    {
        
    }
}
