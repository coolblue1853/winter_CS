using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main Instance;

    public web web;
    public userInfo UserInfo;
    void Start()
    {
        Instance = this;
        web= GetComponent<web>();
        UserInfo = GetComponent<userInfo>();
    }


    public void Update()
    {

    }
}
