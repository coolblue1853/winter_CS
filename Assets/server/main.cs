using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public static main Instance;

    public web web;
    void Start()
    {
        Instance = this;
        web= GetComponent<web>();
    }



}
