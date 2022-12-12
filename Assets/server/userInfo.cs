using UnityEngine;

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

}
