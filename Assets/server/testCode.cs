﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(main.Instance.UserInfo.UserName != "")
        {
            Debug.Log("ok!");
        }


    }



}