using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBossController : MonoBehaviour
{

    float x = 160f, y = 0;

    void Start()
    {
        gameObject.GetComponent<CameraController>().enabled = false;
        StartCoroutine(AnimationMoveCameraToBoss());
    }

    IEnumerator AnimationMoveCameraToBoss()
    {
        for(float i=transform.position.x; i<x; i++)
        {
            transform.position = new Vector3(i, transform.position.y, -10);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
