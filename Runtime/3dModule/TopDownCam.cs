using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class TopDownCam : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public float offsetX;
    public float offsetY = 5f;
    public float offsetZ = 2f;
    

    void Start()
    {
        offsetY = Math.Abs(offsetY);
        offsetX = Mathf.Abs(offsetX);
        offsetZ = Mathf.Abs(offsetZ) * -1; // Ensure offsetZ is negative
    }

    void Update()
    {
        cam.position = player.position + new Vector3(offsetX, offsetY, offsetZ);
        transform.LookAt(player);
    }
}