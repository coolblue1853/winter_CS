using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayManager : MonoBehaviour
{
    // 상점 구매 비용
    long clickPowerUpCost;
    long expPowerUpCost;

    long autoClickPowerCost;
    long autoClickSpeedCost;
    long autoExpPowerCost;
    long autoExpSpeedCost;

    //상점 구매 비용 텍스트
    public Text clickPowerCostText;
    public Text expPowerCostText;

    public Text autoClickPowerCostText;
    public Text autoClickSpeedCostText;
    public Text autoExpPowerCostText;
    public Text autoExpSpeedCostText;


    //상점관련 게임오브젝트(UI)
    public GameObject shopUi;

    public GameObject autoClickBuyButton;
    public GameObject autoExpBuyButton;

    public GameObject autoClickBackground;
    public GameObject autoExpBackground;

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
            autoClickBuyButton.SetActive(false);
        }
        else
        {
            autoClickBuyButton.SetActive(true);
        }
        if (main.Instance.UserInfo.AEPower != 0)
        {
            autoExpBuyButton.SetActive(false);
        }
        else
        {
            autoExpBuyButton.SetActive(true);
        }

        clickPowerUpCost = 10 * (int)(Mathf.Pow(2, main.Instance.UserInfo.CPower));
        clickPowerCostText.text = clickPowerUpCost.ToString();


        expPowerUpCost = 20 * (int)(Mathf.Pow(2, main.Instance.UserInfo.EPower));
        expPowerCostText.text = expPowerUpCost.ToString();



        autoClickPowerCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.ACPower));
        autoClickPowerCostText.text = autoClickPowerCost.ToString();

        autoClickSpeedCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.ACSpeed));
        autoClickSpeedCostText.text = autoClickSpeedCost.ToString();

        autoExpPowerCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.AEPower));
        autoExpPowerCostText.text = autoExpPowerCost.ToString();

        autoExpSpeedCost = 40 * (int)(Mathf.Pow(2, main.Instance.UserInfo.AESpeed));
        autoExpSpeedCostText.text = autoExpSpeedCost.ToString();

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
        shopUi.SetActive(false);

    }
    public void OpenShop()
    {
        autoClickBackground.SetActive(true);
        autoExpBackground.SetActive(true);
        if (main.Instance.UserInfo.ACPower > 0)
        {
            autoClickBackground.SetActive(false);
        }
        if (main.Instance.UserInfo.AEPower > 0)
        {
            autoExpBackground.SetActive(false);
        }
        shopUi.SetActive(true);

    }
    // 상점구매 기능들
    public void ClickUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= clickPowerUpCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -clickPowerUpCost, 0));
            StartCoroutine(main.Instance.web.SetCPower(main.Instance.UserInfo.UserName));


        }
    }
    public void ExpUpgrade()
    {
        if (main.Instance.UserInfo.Coins >= expPowerUpCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -expPowerUpCost, 0));
            StartCoroutine(main.Instance.web.SetEPower(main.Instance.UserInfo.UserName));

        }
    }
    public void BuyAutoClick()
    {
        if (main.Instance.UserInfo.Coins >= 100)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -100, 0));

            StartCoroutine(main.Instance.web.SetACPower(main.Instance.UserInfo.UserName));
            StartCoroutine(main.Instance.web.SetACSpeed(main.Instance.UserInfo.UserName));

        }
    } // 최초구매
    public void BuyAutoExp()
    {
        if (main.Instance.UserInfo.Coins >= 100)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -100, 0));
            StartCoroutine(main.Instance.web.SetAEPower(main.Instance.UserInfo.UserName));
            StartCoroutine(main.Instance.web.SetAESpeed(main.Instance.UserInfo.UserName));

        }
    } // 최초구매
    public void UpAutoClickPower()
    {
        if (main.Instance.UserInfo.Coins >= autoClickPowerCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -autoClickPowerCost, 0));
            StartCoroutine(main.Instance.web.SetACPower(main.Instance.UserInfo.UserName));

        }
    }
    public void UpAutoClickSpeed()
    {
        if (main.Instance.UserInfo.Coins >= autoClickSpeedCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -autoClickSpeedCost, 0));
            StartCoroutine(main.Instance.web.SetACSpeed(main.Instance.UserInfo.UserName));

        }
    }
    public void UpAutoExpPower()
    {
        if (main.Instance.UserInfo.Coins >= autoExpPowerCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -autoExpPowerCost, 0));
            StartCoroutine(main.Instance.web.SetAEPower(main.Instance.UserInfo.UserName));

        }
    }
    public void UpAutoExpSpeed()
    {
        if (main.Instance.UserInfo.Coins >= autoExpSpeedCost)
        {
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, -autoExpSpeedCost, 0));
            StartCoroutine(main.Instance.web.SetAESpeed(main.Instance.UserInfo.UserName));

        }
    }
}

