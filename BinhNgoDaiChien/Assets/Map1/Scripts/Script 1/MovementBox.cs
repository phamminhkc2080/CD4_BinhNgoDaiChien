using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBox : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public bool MoveX;
    public float StartPositionX;//(10) start X position moves object
    public float rangeX;//(7) pham vi di chuyen
    public float speedX;

    public bool MoveY;
    public float StartPositonY;// = -5f;
    public float rangeY;// = 0.3f;
    public float speedY;
    void Start()
    {

    }

    void Update()
    {
        float directionX;
        float directionY;
        if (MoveX)
            directionX = Mathf.PingPong(Time.time * speedX, rangeX) + StartPositionX;
        else directionX = transform.position.x;

        if (MoveY)
            directionY = Mathf.PingPong(Time.time * speedY, rangeY) + StartPositonY;
        else directionY = transform.position.y;

        Vector2 vt = new Vector2(directionX, directionY);
        transform.position = vt;
    }
}
