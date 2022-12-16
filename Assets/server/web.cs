using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;


// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class web : MonoBehaviour
{
    void Start()
    {

    }




    public IEnumerator getText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/winterDev_Backend/getData.php"))
        {
            yield return www.Send();

            if(www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] result = www.downloadHandler.data;
            }

        }
    }

    public IEnumerator getUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/winterDev_Backend/getUser.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] result = www.downloadHandler.data;
            }

        }
    }

    public  IEnumerator Login(string username, string password)
    {
        password = main.Instance.UserInfo.SHA256Hash(password + username);

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text != "Username does not exsist.")
                {
                    if (www.downloadHandler.text != "Wrong Password!")
                    {
                        main.Instance.UserInfo.resetWrongUI();
                        main.Instance.UserInfo.SetInfo(username, password);
                        main.Instance.UserInfo.SetID(www.downloadHandler.text);
                        StartCoroutine(readExpData(username));
                        StartCoroutine(readCoinData(username));
                        StartCoroutine(readLevelData(username));
                        StartCoroutine(readCPowerData(username));
                        StartCoroutine(readEPowerData(username));

                        main.Instance.UserProfile.SetActive(true);
                        main.Instance.LoginUI.SetActive(false);


                    }
                    else
                    {
                        main.Instance.UserInfo.WrongPassward();
                    }

                }
                else
                {
                    main.Instance.UserInfo.WrongUsername();
                }


            }
        }
    }


    public IEnumerator RegisterUser(string username, string password)
    {

        password = main.Instance.UserInfo.SHA256Hash(password + username);


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/registerUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                main.Instance.RegisterUI.gameObject.SetActive(false);
            }
        }


    }
    public IEnumerator GetCoin(string username, long coin,int exp)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginCoin", coin.ToString());
        form.AddField("loginExp", exp);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/getCoin.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readExpData(username));
                StartCoroutine(readCoinData(username));
                StartCoroutine(readCPowerData(username));
                StartCoroutine(readEPowerData(username));
            }
        }


    }
    public IEnumerator SetLevel(string username, int level)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginLevel", level);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/setLevel.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }


    }
    public IEnumerator SetCPower(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/setCPower.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }


    }

    public IEnumerator SetEPower(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/setEPower.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }


    }

    public IEnumerator readCoinData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/readCoinData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
               
                main.Instance.UserInfo.SetCoin(Int64.Parse(www.downloadHandler.text));

            }
        }
    }

    public IEnumerator readExpData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/readExpData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetExp(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readLevelData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/readLevelData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetLevel(Int32.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readCPowerData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/readCPowerData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetCPower(Int32.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readEPowerData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/winterDev_Backend/readEPowerData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetEPower(Int32.Parse(www.downloadHandler.text));
            }
        }
    }

}
