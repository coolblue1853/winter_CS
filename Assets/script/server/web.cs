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

    // PHP와 연결하기 위한 메인 스크립트. 보든 함수의 도메인은 포트포워딩을 통해 접속 가능하도록 설정

    public  IEnumerator Login(string username, string password)
    {
        // 암호화를 위한 SHA256 + 솔팅
        password = main.Instance.UserInfo.SHA256Hash(password + username);

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/Login.php", form))
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

                        StartCoroutine(readAEPowerData(username));
                        StartCoroutine(readACPowerData(username));
                        StartCoroutine(readAESpeedData(username));
                        StartCoroutine(readACSpeedData(username));

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

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/registerUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text != "Username is already taken.")
                {
                    Debug.Log(www.downloadHandler.text);
                    main.Instance.RegisterUI.gameObject.SetActive(false);
                    main.Instance.UserInfo.UsernameAlreadyOff();
                }
                else
                {
                    main.Instance.UserInfo.UsernameAlready();
                }

            }
        }


    }


    // get 함수는 서버에서 정보를 삽입하는 함수들입니다. 각 변수에 맞는 함수를 발동시킵니다.
    public IEnumerator getText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://http://http://168.131.40.88:3306/winterDev_Backend/getData.php"))
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
    public IEnumerator getUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://168.131.40.88:3306/winterDev_Backend/getUser.php"))
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
    public IEnumerator GetCoin(string username, long coin, long exp)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginCoin", coin.ToString());
        form.AddField("loginExp", exp.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/getCoin.php", form))
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



            }
        }


    }
    public IEnumerator GetRankExp()
    {


        WWWForm form = new WWWForm();


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/getRankExp.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {

                main.Instance.UserInfo.SetRankExp(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator GetRankUser()
    {


        WWWForm form = new WWWForm();


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/getRankUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetRankUser(www.downloadHandler.text);

            }
        }
    }

    // set함수들 또한 정보를 삽입하는 함수들입니다.
    public IEnumerator SetLevel(string username, int level)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginLevel", level);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setLevel.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readLevelData(username));


            }
        }


    }
    public IEnumerator SetCPower(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setCPower.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {

                StartCoroutine(readCPowerData(username));
            }
        }


    }
    public IEnumerator SetEPower(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setEPower.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readEPowerData(username));

            }
        }


    }
    public IEnumerator SetAEPower(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setAEPower.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readAEPowerData(username));

            }
        }


    }
    public IEnumerator SetACPower(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setACPower.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readACPowerData(username));

            }
        }


    }
    public IEnumerator SetAESpeed(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setAESpeed.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readAESpeedData(username));

            }
        }


    }
    public IEnumerator SetACSpeed(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/setACSpeed.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(readACSpeedData(username));

            }
        }


    }
    public IEnumerator readCoinData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readCoinData.php", form))
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


    // read 함수들은 서버를 통해 데이터베이스에서 정보를 읽어와 변수에 넣는 함수들입니다.
    public IEnumerator readExpData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readExpData.php", form))
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

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readLevelData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetLevel(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readCPowerData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readCPowerData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetCPower(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readEPowerData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readEPowerData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetEPower(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readAEPowerData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readAEPowerData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetAEPower(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readACPowerData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readACPowerData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetACPower(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readAESpeedData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readAESpeedData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetAESpeed(Int64.Parse(www.downloadHandler.text));
            }
        }
    }
    public IEnumerator readACSpeedData(string username)
    {


        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://168.131.40.88:3306/winterDev_Backend/readACSpeedData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                main.Instance.UserInfo.SetACSpeed(Int64.Parse(www.downloadHandler.text));
            }
        }
    }

}
