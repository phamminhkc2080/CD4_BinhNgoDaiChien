using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Text cungText;
    public Text kiemText;
    public Text CoinText;
    public Text ScoreText;

    public static int SLcung, SLkiem, SLCoin, Diem;

    void Start()
    {
        SLcung = 0;
        SLkiem = 0;
        SLCoin = 0;
        Diem = 0;
    }

    public void IncrementCung()
    {
        SLcung++;
        cungText.text = SLcung + " / 10";
    }
    public void IncrementKiem()
    {
        SLkiem++;
        kiemText.text = SLkiem + " / 07";
    }
    public void IncrementCoin()
    {
        SLCoin++;
        CoinText.text = "0" + SLCoin;
    }

    public void SetScore()
    {
        // Diem = voi*20 + oc*10 + coin*10;
        Diem += SLcung * 20 + SLkiem * 10 + SLCoin * 10;
        ScoreText.text = Diem + "";
    }

}
