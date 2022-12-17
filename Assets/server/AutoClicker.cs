using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    public bool isAutoClick = false;
    public bool isAutoExp = false;


    public void reset()
    {
        isAutoClick = false;
        isAutoExp = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (main.Instance.UserInfo.ACPower != 0 && isAutoClick==false)
        {
            isAutoClick = true;
            StartCoroutine(AutoCoinClick());
        }
        if (main.Instance.UserInfo.AEPower != 0 && isAutoExp == false)
        {
            isAutoExp = true;
            StartCoroutine(AutoExpClick());
        }
    }


    IEnumerator AutoCoinClick()
    {
        if(main.Instance.UserInfo.ACSpeed != 0)
        {
            yield return new WaitForSecondsRealtime(1 / (main.Instance.UserInfo.ACSpeed * 0.1f));
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, main.Instance.UserInfo.ACPower, 0));
            StartCoroutine(AutoCoinClick());
        }
        else
        {
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(AutoCoinClick());
        }

    }
    IEnumerator AutoExpClick()
    {
        if(main.Instance.UserInfo.AESpeed != 0)
        {
            yield return new WaitForSecondsRealtime(1 / (main.Instance.UserInfo.AESpeed * 0.1f));
            StartCoroutine(main.Instance.web.GetCoin(main.Instance.UserInfo.UserName, 0, main.Instance.UserInfo.AEPower));
            StartCoroutine(AutoExpClick());
        }
        else
        {
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(AutoExpClick());
        }


    }
}
