using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform Player;
    public float minX = 0, maxX=155;
    public float minY = 0, maxY = 9.5f;
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

            if (pos.x < 0) pos.x = 0;
            if (pos.x > maxX) pos.x = maxX;

            if (pos.y < 0) pos.y = 0;
            if (pos.y > maxY) pos.y = maxY;

            transform.position = pos;
        }
    }
}
