using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
    public GameObject loginSuccesUI;
    private void Awake()
    {
        loginSuccesUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(main.Instance.UserInfo.UserName != "")
        {
            StartCoroutine(goMainScene());
        }


    }


    IEnumerator goMainScene()
    {
        loginSuccesUI.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);

        main.Instance.UserProfile.SetActive(true);
        main.Instance.login.gameObject.SetActive(false);
        //SceneManager.LoadScene("MainScene");

    }



}
