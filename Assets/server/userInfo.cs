using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;

public class userInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string UserName;
    string UserPassword;
    public int Level;
    public int CPower;
    public long Coins;
    public long Exp;



    public GameObject wrongUser;
    public GameObject wrongPass;

    public Text UserNameTxt;
    public Text LevelTxt;
    public Text CoinTxt;
    public Text ExpTxt;
    public Text CPowerTxt;

    //Item info

    void Update()
    {
        SetUserInfo();
    }
    

     public void SetUserInfo()
    {
        UserNameTxt.text = UserName;
        LevelTxt.text = Level.ToString();
        CoinTxt.text = Coins.ToString();
        ExpTxt.text = Exp.ToString();
        CPowerTxt.text = CPower.ToString();

    }


    public void SetInfo(string username, string userpassword)
    {
        UserName = username;
        UserPassword = userpassword;
    }
    public void SetExp(long exp)
    {
        Exp = exp;

    }
    public void SetCoin(long coins)
    {
        Coins = coins;

    }
    public void SetID(string id)
    {
        UserID = id;
    }
    public void SetLevel(int level)
    {
        Level = level;
    }
    public void SetCPower(int cpower)
    {
        CPower = cpower;

    }


    public void WrongUsername()
    {
        wrongUser.SetActive(true);
        wrongPass.SetActive(false);
    }
    public void WrongPassward()
    {
        wrongUser.SetActive(false);
        wrongPass.SetActive(true);
    }
    public void resetWrongUI()
    {
        wrongUser.SetActive(false);
        wrongPass.SetActive(false);
    }

    public string SHA256Hash(string data)
    {
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
        StringBuilder stringBuilder = new StringBuilder();
        foreach (byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }
        return stringBuilder.ToString();
    }   


}
