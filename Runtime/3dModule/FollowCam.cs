using System;
using UnityEngine;

namespace _3dModule
{
    public class FollowCam : MonoBehaviour
    {
        public Transform cam;
        public Transform player;
        public float camDistance;

        void Start()
        {
            camDistance = Math.Abs(camDistance) * -1; // Ensure camDistance is negative
        }

        void Update()
        {
            cam.position = player.position + new Vector3(0, 5, camDistance);
            transform.LookAt(player);
        }
    }
}