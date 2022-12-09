using UnityEngine;

public class userInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string UserName;
    string UserPassword;
    string Level;
    string Coins;

    public void SetInfo(string username, string userpassword)
    {
        UserName = username;
        UserPassword = userpassword;
    }

    public void SetID(string id)
    {
        UserID = id;
    }


}
