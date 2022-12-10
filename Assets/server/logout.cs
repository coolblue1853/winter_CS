using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class logout : MonoBehaviour
{
   public void goLoginScene()
    {
        StartCoroutine(goLoginSceneIEnum());
    }
  IEnumerator goLoginSceneIEnum()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("LoginScene");
    }
}
