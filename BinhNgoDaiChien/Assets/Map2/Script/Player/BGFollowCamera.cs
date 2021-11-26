using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollowCamera : MonoBehaviour
{
    public Transform camera;

    /*
     * Toa Do Goc BackGround
     * (X: 13.35, y: 2.5, z:-10)
     * Toa Do Goc Camera
     * (x: 0, y:0, z:-1)
     * 
     * Toa do goc
     * X_BG - X_Cam = 17.4
     * Y_BG - Y_Cam = 2.5
     * 
     * Khoang Cach Camera di chuyen quanh BG
     * Max X - Min X = 8
     * Max Y - Min Y = 8.3
     */
    //private float minX = 17.4f;
    //private float maxX = 9.4f;

    private float minY = 2.5f;
    private float maxY = -5.8f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 posCamera = camera.position;
        Vector3 posBG = this.transform.position;

        posBG.x = posCamera.x + 13.35f;

        //posBG.x = posCamera.x + minX;
        //posBG.y = posCamera.y + minY;

        //if ((posBG.x - posCamera.x) > minX) posBG.x = posCamera.x + minX;
        //if ((posBG.x - posCamera.x) < maxX) posBG.x = posCamera.x + maxX;

        if ((posBG.y - posCamera.y) > minY) posBG.y = posCamera.y + minY;
        if ((posBG.y - posCamera.y) < maxY) posBG.y = posCamera.y + maxY;

        this.transform.position = posBG;
    }
}
