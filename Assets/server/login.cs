using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class login : MonoBehaviour
{

    public InputField userNameInput;
    public InputField userPassInput;
    public Button loginBotton;

    public GameObject registerUi;
    // Start is called before the first frame update
    void Start()
    {
        loginBotton.onClick.AddListener(() => 
        {

            StartCoroutine( main.Instance.web.Login(userNameInput.text, userPassInput.text));
        });
    }


    public void OepnRegisterUi()
    {
        registerUi.SetActive(true);
    }
}
