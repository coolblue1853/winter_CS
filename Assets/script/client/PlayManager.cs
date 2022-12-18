using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayManager : MonoBehaviour
{
    // 상점 구매 비용
    long CPowerUpgradeCost;
    long EPowerUpgradeCost;

    long ACPUpgradeCost;
    long ACSUpgradeCost;
    long AEPUpgradeCost;
    long AESUpgradeCost;

    //상점 구매 비용 텍스트
    public Text CPowerUpgradeCostTxt;
    public Text EPowerUpgradeCostTxt;

    public Text ACPUpgradeCostTxt;
    public Text ACSUpgradeCostTxt;
    public Text AEPUpgradeCostTxt;
    public Text AESUpgradeCostTxt;


    //상점관련 게임오브젝트(UI)
    public GameObject ShopUi;

    public GameObject AutoClickBuyButton;
    public GameObject AutoExpBuyButton;

    public GameObject ACBackground;
    public GameObject AEBackground;

    public AutoClicker autoClicker;
    private void Start()
    {
        StartCoroutine(RankUpdater());
    }

    void Update()
    {
        ShopCostUpdater();
    }


    // 랭킹 시스템 업데이트
    IEnumerator RankUpdater()
    {
        StartCoroutine(main.Instance.web.GetRankExp());
        StartCoroutine(main.Instance.web.GetRankUser());
        yield return new WaitForSecondsRealtime(60f);
        StartCoroutine(RankUpdater());
    }



    //상점 가격 업데이터
    void ShopCostUpdater()
    {
        if(main.Instance.UserInfo.ACPower != 0)
        {
            AutoClickBuyButton.SetActive(false);
        }
        else
        {
            AutoClickBuyButton.SetActive(true);
        }
        if (main.Instance.UserInfo.AEPower != 0)
        {
            AutoExpBuyButton.SetActive(false);
        }
        else
        {
            AutoExpBuyButton.SetActive(true);
        }

        CPowerUpgradeCost = 10 * (int)(Mathf.Pow(2, main.Instance.UserInfo.CPower));
        CPowerUpgradeCostTxt.text = CPowerUpgradeCost.ToString();


        EPowerUpgradeCost = 20 * (int)(Mathf.Pow(2, main.Instance.UserInfo.EPower));
        EPowerUpgradeCostTxt.text = EPowerUpgradeCost.ToString();



        ACPUpgradeCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.ACPower));
        ACPUpgradeCostTxt.text = ACPUpgradeCost.ToString();

        ACSUpgradeCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.ACSpeed));
        ACSUpgradeCostTxt.text = ACSUpgradeCost.ToString();

        AEPUpgradeCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.AEPower));
        AEPUpgradeCostTxt.text = AEPUpgradeCost.ToString();

        AESUpgradeCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.AESpeed));
        AESUpgradeCostTxt.text = AESUpgradeCost.ToString();

    }




    //클릭하여 경험치 + 코인획득
    public void Click()
    {
        StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, main.Instance.UserInfo.CPower, main.Instance.UserInfo.EPower));

    }
    
    //게임 로그아웃
    public void Logout()
    {
        autoClicker.reset();
        main.Instance.UserProfile.SetActive(false);
        main.Instance.LoginUI.SetActive(true);


    }

    public void CloseShop()
    {
        ShopUi.SetActive(false);

    }
    public void OpenShop()
    {
        ACBackground.SetActive(true);
        AEBackground.SetActive(true);
        if (main.Instance.UserInfo.ACPower > 0)
        {
            ACBackground.SetActive(false);
        }
        if (main.Instance.UserInfo.AEPower > 0)
        {
            AEBackground.SetActive(false);
        }
        ShopUi.SetActive(true);

    }
    // 상점구매 기능들
    public void ClickUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= CPowerUpgradeCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -CPowerUpgradeCost, 0));
            StartCoroutine(main.Instance.web.SetCPower(main.Instance.UserInfo.UserName));


        }
    }
    public void ExpUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= EPowerUpgradeCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -EPowerUpgradeCost, 0));
            StartCoroutine(main.Instance.web.SetEPower(main.Instance.UserInfo.UserName));

        }
    }
    public void ACBuy()
    {
        if (main.Instance.UserInfo.Coins >= 100)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -100, 0));

            StartCoroutine(main.Instance.web.SetACPower(main.Instance.UserInfo.UserName));
            StartCoroutine(main.Instance.web.SetACSpeed(main.Instance.UserInfo.UserName));

        }
    } // 최초구매
    public void AEBuy()
    {
        if (main.Instance.UserInfo.Coins >= 100)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -100, 0));
            StartCoroutine(main.Instance.web.SetAEPower(main.Instance.UserInfo.UserName));
            StartCoroutine(main.Instance.web.SetAESpeed(main.Instance.UserInfo.UserName));

        }
    } // 최초구매
    public void ACPUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= ACPUpgradeCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -ACPUpgradeCost, 0));
            StartCoroutine(main.Instance.web.SetACPower(main.Instance.UserInfo.UserName));

        }
    }
    public void ACSUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= ACSUpgradeCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -ACSUpgradeCost, 0));
            StartCoroutine(main.Instance.web.SetACSpeed(main.Instance.UserInfo.UserName));

        }
    }
    public void AEPUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= AEPUpgradeCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -AEPUpgradeCost, 0));
            StartCoroutine(main.Instance.web.SetAEPower(main.Instance.UserInfo.UserName));

        }
    }
    public void AESUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= AESUpgradeCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -AESUpgradeCost, 0));
            StartCoroutine(main.Instance.web.SetAESpeed(main.Instance.UserInfo.UserName));

        }
    }
}

