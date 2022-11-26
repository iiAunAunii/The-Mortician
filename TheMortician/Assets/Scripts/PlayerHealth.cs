using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject hud;
    public GameObject deathScreen;
    public GameObject player;
 

    public float health = 100f;

    private bool isDead;

    void Start()
    {
        deathScreen.SetActive(false);
    }



    void Update()
    {

        if(health <= 0 && !isDead)
        {
            deathScreen.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
        }

        if (health > 100)
        {
            health = 100;
        }
        
    }
}
