using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (UIManager.SLvoi >= 20 && UIManager.SLOc >= 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
