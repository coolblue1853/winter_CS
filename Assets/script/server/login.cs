using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class login : MonoBehaviour
{

    //로그인시 입력필드
    public InputField userNameInput;
    public InputField userPassInput;
    public Button loginBotton;



    // Start is called before the first frame update
    void Start()
    {
        //로그인 버튼 클릭
        loginBotton.onClick.AddListener(() => 
        {
            StartCoroutine( main.Instance.web.Login(userNameInput.text, userPassInput.text));
        });
    }

    public void OpenRegisterUI()
    {
        main.Instance.RegisterUI.SetActive(true);

    }
    public void CloseRegisterUI()
    {
        main.Instance.RegisterUI.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
