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
        // 자동클릭 구매시 가림막 제거(게임 시작시)
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


}
