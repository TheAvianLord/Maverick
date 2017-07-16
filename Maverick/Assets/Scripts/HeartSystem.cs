using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{

    public Slider healthSlider;
    public Text theText;

    public GameObject player;
    public Player playerScript;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        healthSlider.maxValue = Player.maxHealth;
        healthSlider.value = playerScript.health;
        theText.text = playerScript.health + "/" + Player.maxHealth;
    }
}

