using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class userInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string UserName;
    string UserPassword;
    string Level;
    string Coins;

    public GameObject wrongUser;
    public GameObject wrongPass;

    public void SetInfo(string username, string userpassword)
    {
        UserName = username;
        UserPassword = userpassword;
    }

    public void SetID(string id)
    {
        UserID = id;
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
