using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    IEnumerator waitSecond()
    {
        yield return new WaitForSeconds(5.0f);
    }

    public void PlayBtn(string tutorialLevel)
    {
        StartCoroutine(waitSecond());
        SceneManager.LoadScene(tutorialLevel);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

}
