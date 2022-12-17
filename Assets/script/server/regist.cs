using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class regist : MonoBehaviour
{

    public InputField userNameInput;
    public InputField userPassInput;
    public InputField userPassInput2;
    public Button registBotton;

    public GameObject notSameTxt;
 
    // Start is called before the first frame update
    void Start()
    {




        registBotton.onClick.AddListener(() =>
        {
            if(userNameInput.text != "" && userPassInput.text != "")
            {
                if (userPassInput.text == userPassInput2.text)
                {

                    StartCoroutine(main.Instance.web.RegisterUser(userNameInput.text, userPassInput.text));
                }
            }

        });
    }
    private void Update()
    {
        if ((userPassInput.text == userPassInput2.text) || userPassInput2.text == "")
        {
            notSameTxt.SetActive(false);
        }

        else
        {
            notSameTxt.SetActive(true);
        }
    }




}
