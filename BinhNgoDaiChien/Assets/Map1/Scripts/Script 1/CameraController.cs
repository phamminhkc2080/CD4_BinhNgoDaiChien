using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Player;
    public float minX, maxX;
    public float minY, maxY;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector3 pos = transform.position;
            pos.x = Player.position.x;
            pos.y = Player.position.y;

            if (pos.x < minX) pos.x = minX;
            if (pos.x > maxX) pos.x = maxX;

            if (pos.y < minY) pos.y = minY;
            if (pos.y > maxY) pos.y = maxY;

            transform.position = pos;
        }
    }
}
