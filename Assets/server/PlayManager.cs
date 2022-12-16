using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayManager : MonoBehaviour
{
    long CPowerUpgradeCost;
    long EPowerUpgradeCost;

    public Text CPowerUpgradeCostTxt;
    public Text EPowerUpgradeCostTxt;

    public GameObject ShopUi;

    void Update()
    {
        ShopCostUpdater();
    }

    void ShopCostUpdater()
    {

        CPowerUpgradeCost = 10 * (int)(Mathf.Pow(2, main.Instance.UserInfo.CPower));
        CPowerUpgradeCostTxt.text = CPowerUpgradeCost.ToString();


        EPowerUpgradeCost = 20 * (int)(Mathf.Pow(2, main.Instance.UserInfo.EPower));
        EPowerUpgradeCostTxt.text = EPowerUpgradeCost.ToString();
    }


    public void Click()
    {
        StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, main.Instance.UserInfo.CPower, main.Instance.UserInfo.EPower));

    }
    public void Logout()
    {
        main.Instance.UserProfile.SetActive(false);
        main.Instance.LoginUI.SetActive(true);
    }

    public void CloseShop()
    {
        ShopUi.SetActive(false);

    }
    public void OpenShop()
    {
        ShopUi.SetActive(true);

    }
    public void ClickUpgrade()
    {
        if(main.Instance.UserInfo.Coins >= CPowerUpgradeCost)
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
}

