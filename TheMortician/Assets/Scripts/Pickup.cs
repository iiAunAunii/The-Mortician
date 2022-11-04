using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    private bool _inReach;

    [SerializeField]private GameObject _pickUpText;
    [SerializeField] private GameObject _interactHitbox;

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
            _interactHitbox.SetActive(true);
            Destroy(this.gameObject);
        }

    }
}
