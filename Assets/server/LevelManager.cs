using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    long lv2 = 100;
    long lv3 = 10000;
    long lv4 = 1000000;
    long lv5 = 100000000;
    long lv6 = 10000000000;
    long lv7 = 1000000000000;
    long lv8 = 100000000000000;
    long lv9 = 10000000000000000;
    long lv10 = 1000000000000000000;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(main.Instance.UserInfo.Exp> lv2 && main.Instance.UserInfo.Exp != 2)
        {
            main.Instance.UserInfo.SetLevel(2);
        }
        else if (main.Instance.UserInfo.Exp > lv3 && main.Instance.UserInfo.Exp != 3)
        {
            main.Instance.UserInfo.SetLevel(3);
        }
        else if(main.Instance.UserInfo.Exp > lv4 && main.Instance.UserInfo.Exp != 4)
        {
            main.Instance.UserInfo.SetLevel(4);
        }
        else if(main.Instance.UserInfo.Exp > lv5 && main.Instance.UserInfo.Exp != 5)
        {
            main.Instance.UserInfo.SetLevel(5);
        }
        else if (main.Instance.UserInfo.Exp > lv6 && main.Instance.UserInfo.Exp != 6)
        {
            main.Instance.UserInfo.SetLevel(6);
        }
        else if(main.Instance.UserInfo.Exp > lv7 && main.Instance.UserInfo.Exp != 7)
        {
            main.Instance.UserInfo.SetLevel(7);
        }
        else if(main.Instance.UserInfo.Exp > lv8 && main.Instance.UserInfo.Exp != 8)
        {
            main.Instance.UserInfo.SetLevel(8);
        }
        else if(main.Instance.UserInfo.Exp > lv9 && main.Instance.UserInfo.Exp != 9)
        {
            main.Instance.UserInfo.SetLevel(9);
        }
        else if(main.Instance.UserInfo.Exp > lv10 && main.Instance.UserInfo.Exp != 10)
        {
            main.Instance.UserInfo.SetLevel(10);
        }


    }
}
