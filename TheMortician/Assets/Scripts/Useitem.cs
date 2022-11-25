using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useitem : MonoBehaviour
{

    private bool _inReach;

    [SerializeField] private GameObject _pickUpText;
    [SerializeField] private GameObject _checkQuestText;
    


    [SerializeField] private AudioSource _pickUpSound;

    void Start()
    {
        _inReach = false;
        _pickUpText.SetActive(false);
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            _inReach = true;
            _pickUpText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            _inReach = false;
            _pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && _inReach)
        {

            _pickUpSound.Play();
            _inReach = false;
            _pickUpText.SetActive(false);
            _checkQuestText.SetActive(true);
            /*this.gameObject.SetActive(false);*/
            Destroy(this.gameObject);
        }

    }
}
