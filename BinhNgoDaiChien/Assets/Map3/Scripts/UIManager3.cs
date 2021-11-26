using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager3 : MonoBehaviour
{

    public Text voiText;
    public Text CoinText;
    public Text ScoreText;

    public static int SLvoi, SLCoin, Diem;

    //controller player and boss
    public Slider HealthBarBoss;
    public GameObject player;
    public GameObject boss;
    public GameObject camera;

    bool setCombat = true;
    private DialogueTrigger trigger;

    void Start()
    {
        //SLvoi = UIManager.SLvoi;
        SLvoi = 20;
        SLCoin = UIManager.SLCoin;
        Diem = UIManager.Diem;

        CoinText.text = "0" + SLCoin;
        ScoreText.text = "Score: " + Diem;
        voiText.text = SLvoi+"";

        //controller slider boss
        HealthBarBoss.gameObject.SetActive(false);
    }

    void Update()
    {
        checkPlayerAndBoss();
        voiText.text = SLvoi + "";
    }

    public void IncrementCoin()
    {
        SLCoin++;
        CoinText.text = "0" + SLCoin;
    }

    public void SetScore()
    {
        // Diem = voi*20 + oc*10 + coin*10;
        //                               coin cu da nhan voi diem
        Diem += (SLCoin - UIManager.SLCoin) * 10;
        ScoreText.text = "Score: " + Diem;
    }

    public void SetVoi()
    {
        
    }

    void checkPlayerAndBoss()
    {
        if (Vector3.Distance(boss.transform.position, player.transform.position) <= 11 && setCombat)
        {
            setCombat = false;

            ScoreText.gameObject.SetActive(false);
            CoinText.gameObject.SetActive(false);

            camera.GetComponent<CameraBossController>().enabled = true;

            StartCoroutine(delayShowDialog());
        }
    }

    IEnumerator delayShowDialog()
    {
        trigger = boss.GetComponent<DialogueTrigger>();
        yield return new WaitForSeconds(2);
        trigger.StartDialogue();
    }
}
