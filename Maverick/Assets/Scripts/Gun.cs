using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Animator myAnimator;

    // Use this for initialization
    void Start ()
    {
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        myAnimator.SetBool("shooting", Input.GetMouseButton(1));
    }
}
