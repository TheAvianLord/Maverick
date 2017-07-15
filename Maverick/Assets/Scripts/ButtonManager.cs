using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayBtn(string highwayLevel)
    {
        SceneManager.LoadScene(highwayLevel);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

}
