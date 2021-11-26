using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text voiText;
    public Text OcSenText;
    public Text CoinText;
    public Text ScoreText;

    public static int SLvoi, SLOc, SLCoin, Diem;

    void Start()
    {
        SLCoin = UI_Manager.SLCoin;
        Diem = UI_Manager.Diem;
        SLvoi = 20;
        SLOc = 0;

        CoinText.text = "0" + SLCoin;
        ScoreText.text = Diem + "";
    }

    public void IncrementVoi()
    {
        SLvoi++;
        voiText.text = SLvoi+" / 20";
    }
    public void IncrementOcSen()
    {
        SLOc++;
        OcSenText.text = SLOc + " / 20";
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
        Diem += SLvoi * 20 + SLOc * 10 + (SLCoin - UI_Manager.SLCoin) * 10;
        ScoreText.text = Diem+"";
    }
}
