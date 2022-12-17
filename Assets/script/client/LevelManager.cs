using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    long lv2 = 100;
    long lv3 = 1000;
    long lv4 = 10000;
    long lv5 = 100000;
    long lv6 = 1000000;
    long lv7 = 10000000;
    long lv8 = 100000000;
    long lv9 = 1000000000;
    long lv10 = 10000000000;


    bool isLv2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(main.Instance.UserInfo.Exp> lv2 && main.Instance.UserInfo.Level == 1)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName,2));
            main.Instance.UserInfo.SetLevel(2);
        }
        else if (main.Instance.UserInfo.Exp > lv3 && main.Instance.UserInfo.Level == 2)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 3));
            main.Instance.UserInfo.SetLevel(3);
        }
        else if(main.Instance.UserInfo.Exp > lv4 && main.Instance.UserInfo.Level == 3)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName,4));
            main.Instance.UserInfo.SetLevel(4);
        }
        else if(main.Instance.UserInfo.Exp > lv5 && main.Instance.UserInfo.Level == 4)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 5));
            main.Instance.UserInfo.SetLevel(5);
        }
        else if (main.Instance.UserInfo.Exp > lv6 && main.Instance.UserInfo.Level == 5)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 6));
            main.Instance.UserInfo.SetLevel(6);
        }
        else if(main.Instance.UserInfo.Exp > lv7 && main.Instance.UserInfo.Level == 6)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 7));
            main.Instance.UserInfo.SetLevel(7);
        }
        else if(main.Instance.UserInfo.Exp > lv8 && main.Instance.UserInfo.Level == 7)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 8));
            main.Instance.UserInfo.SetLevel(8);
        }
        else if(main.Instance.UserInfo.Exp > lv9 && main.Instance.UserInfo.Level == 8)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 9));
            main.Instance.UserInfo.SetLevel(9);
        }
        else if(main.Instance.UserInfo.Exp > lv10 && main.Instance.UserInfo.Level == 9)
        {
            StartCoroutine(main.Instance.web.SetLevel(main.Instance.UserInfo.UserName, 10));
            main.Instance.UserInfo.SetLevel(10);
        }


    }
}
