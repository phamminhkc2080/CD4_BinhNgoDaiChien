using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Map : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (UI_Manager.SLcung >= 10 && UI_Manager.SLkiem >= 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
