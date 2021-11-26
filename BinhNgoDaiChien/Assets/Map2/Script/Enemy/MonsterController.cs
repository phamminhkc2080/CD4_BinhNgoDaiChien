using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

    public List<GameObject> list = new List<GameObject>();

    private enemyHealth enemyScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].active == false)
            {
                StartCoroutine(Delay(i));
            }
        }
    }

    IEnumerator Delay(int i)
    {
        yield return new WaitForSeconds(6);
        list[i].SetActive(true);
        enemyScript = list[i].gameObject.GetComponent<enemyHealth>();
        enemyScript.Start();
        
    }
}
