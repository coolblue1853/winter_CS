using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



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
            }
        }
    }


    public IEnumerator RegisterUser(string username, string password)
    {
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
            }
        }
    }
}
