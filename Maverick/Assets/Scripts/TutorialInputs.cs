using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TutorialInputs : MonoBehaviour
{
    public AudioClip clip;

    bool wasdDone = false;
    bool meleeDone = false;
    bool shootDone = false;

    public bool tutorialOver = false;

    public Image movementImage;
    public Image meleeImage;
    public Image shootImage;

	// Use this for initialization
	void Start ()
    {
        movementImage.CrossFadeAlpha(0, 0, true);
        meleeImage.CrossFadeAlpha(0, 0, true);
        shootImage.CrossFadeAlpha(0, 0, true);
        movementImage.CrossFadeAlpha(1, 1, true);
    }


    // Update is called once per frame
    void Update ()
    {
        if (wasdDone == false)
        {
            wasdDone = CheckWasd();
            if (wasdDone)
            {
                FadeMovement();
                AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                meleeImage.CrossFadeAlpha(1, 1, true);
            }
            return;
        }
        else if (meleeDone == false)
        {
            meleeDone = CheckMelee();
            if (meleeDone)
            {
                FadeMelee();
                AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                shootImage.CrossFadeAlpha(1, 1, true);
            }
            return;
        }
        else if (shootDone == false)
        {
            shootDone = CheckShoot();
            if (shootDone)
            {
                FadeShoot();
                AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
            }
            return;
        }
        else
        {
            tutorialOver = true;
        }
	}

    bool CheckWasd()
    {
        bool wCheck = Input.GetKey(KeyCode.W);
        bool aCheck = Input.GetKey(KeyCode.A);
        bool sCheck = Input.GetKey(KeyCode.S);
        bool dCheck = Input.GetKey(KeyCode.D);

        return (wCheck || aCheck || sCheck || dCheck);
    }

    bool CheckMelee()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }

    bool CheckShoot()
    {
        return Input.GetKey(KeyCode.Mouse1);
    }

    void FadeMovement()
    {
        movementImage.CrossFadeAlpha(0, 1, true);
        //print(wasdDone);
    }

    void FadeMelee()
    {
        meleeImage.CrossFadeAlpha(0, 1, true);
        //print(meleeDone);
    }

    void FadeShoot()
    {
        shootImage.CrossFadeAlpha(0, 1, true);
        //print(shootDone);
    }

    public void EndTutorial(string highwayLevel)
    {
        //SceneManager.LoadScene(highwayLevel);
    }
}
