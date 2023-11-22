using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject AutoClickBackground;
    public GameObject AutoExpBackground;

    // Start is called before the first frame update
    void Start()
    {
        // 자동클릭 구매시 가림막 제거(게임 시작시)
        AutoClickBackground.SetActive(true);
        AutoExpBackground.SetActive(true);
        if (main.Instance.UserInfo.ACPower > 0)
        {
            AutoClickBackground.SetActive(false);
        }
        if (main.Instance.UserInfo.AEPower > 0)
        {
            AutoExpBackground.SetActive(false);
        }
    }


}
