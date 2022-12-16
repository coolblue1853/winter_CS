using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main Instance;

    public web web;
    public userInfo UserInfo;
    public login login;

    public GameObject UserProfile;
    public GameObject LoginUI;
    public GameObject RegisterUI;

    void Start()
    {
        Instance = this;
        web= GetComponent<web>();
        UserInfo = GetComponent<userInfo>();
    }


}
