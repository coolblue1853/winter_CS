using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject ACBackground;
    public GameObject AEBackground;

    // Start is called before the first frame update
    void Start()
    {
        ACBackground.SetActive(true);
        AEBackground.SetActive(true);
        if (main.Instance.UserInfo.ACPower > 0)
        {
            ACBackground.SetActive(false);
        }
        if (main.Instance.UserInfo.AEPower > 0)
        {
            AEBackground.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
