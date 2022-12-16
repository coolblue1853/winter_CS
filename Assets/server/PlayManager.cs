using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayManager : MonoBehaviour
{
    long CPowerUpgradeCost;

    public Text CPowerUpgradeCostTxt;

    public GameObject ShopUi;

    void Update()
    {
        ShopCostUpdater();
    }

    void ShopCostUpdater()
    {

        CPowerUpgradeCost = 100 * (int)(Mathf.Pow(2, main.Instance.UserInfo.CPower));
        CPowerUpgradeCostTxt.text = CPowerUpgradeCost.ToString();
    }


    public void Click()
    {
        StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, main.Instance.UserInfo.CPower, 1));

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
}
