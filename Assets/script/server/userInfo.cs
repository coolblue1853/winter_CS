using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;

public class userInfo : MonoBehaviour
{
    // 유저 정보 모음
    public string UserID { get; private set; }
    public string UserName;
    string UserPassword;
    public long Level;
    public long Coins;
    public long Exp;
    public long CPower;
    public long EPower;
    public long ACPower;
    public long ACSpeed;
    public long AEPower;
    public long AESpeed;

    public string RankUser;
    public long RankExp;
    // 변수 텍스트
    public Text UserNameTxt;
    public Text LevelTxt;
    public Text CoinTxt;
    public Text ExpTxt;
    public Text CPowerTxt;
    public Text EPowerTxt;
    public Text ACPowerTxt;
    public Text ACSpeedTxt;
    public Text AEPowerTxt;
    public Text AESpeedTxt;

    public Text RankUserTxt;
    public Text RankExpTxt;

    // 로그인 안내 텍스트
    public GameObject wrongUser;
    public GameObject wrongPass;
    public GameObject usernameAlready;



    //Item info

    void Update()
    {
        SetUserInfo();
    }
    

    // 유저 변수를 해당하는 텍스트에 소팅
     public void SetUserInfo()
    {
        UserNameTxt.text = UserName;
        LevelTxt.text = Level.ToString();
        CoinTxt.text = Coins.ToString();
        ExpTxt.text = Exp.ToString();
        CPowerTxt.text = CPower.ToString();
        EPowerTxt.text = EPower.ToString();
        AEPowerTxt.text = AEPower.ToString();
        ACPowerTxt.text = ACPower.ToString();
        AESpeedTxt.text = AESpeed.ToString();
        ACSpeedTxt.text = ACSpeed.ToString();

        RankUserTxt.text = RankUser.ToString();
        RankExpTxt.text = RankExp.ToString();
    }


    // web에서 php를통해 받은 변수를 인스턴스 변수에 입력
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
    public void SetLevel(long level)
    {
        Level = level;
    }
    public void SetCPower(long cpower)
    {
        CPower = cpower;

    }
    public void SetEPower(long epower)
    {
        EPower = epower;

    }
    public void SetACPower(long acpower)
    {
        ACPower = acpower;

    }
    public void SetAEPower(long aepower)
    {
        AEPower = aepower;

    }
    public void SetACSpeed(long acspeed)
    {
        ACSpeed = acspeed;

    }
    public void SetAESpeed(long aespeed)
    {
        AESpeed = aespeed;

    }

    public void SetRankUser(string user)
    {
        RankUser = user;

    }
    public void SetRankExp(long exp)
    {
        RankExp = exp;

    }


    // 로그인 안내 함수
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
    public void UsernameAlready()
    {
        usernameAlready.SetActive(true);
    }
    public void UsernameAlreadyOff()
    {
        usernameAlready.SetActive(false);
    }
    public void resetWrongUI()
    {
        wrongUser.SetActive(false);
        wrongPass.SetActive(false);
    }

    // 암호화를 위한 해시함수
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
