using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostSystem : MonoBehaviour
{
    public float damage = 20;
    public float damageTime = 1;
    public GameObject FPSController;
    public float timeHealth = 3.0f;
    IEnumerator damagePlayer = null;
    IEnumerator healthPlayer = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "FPSController")
        {
            if(healthPlayer != null)          
            StopCoroutine(healthPlayer);

            damagePlayer = other.GetComponent<HealthSytem>().RemoveHealth(damage,damageTime);
            StartCoroutine(damagePlayer);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "FPSController")
        {
            if (healthPlayer != null)
                StopCoroutine(damagePlayer);

            healthPlayer = other.gameObject.GetComponent<HealthSytem>().StartHealth(other.gameObject.GetComponent<HealthSytem>().health, timeHealth);
            StartCoroutine(healthPlayer);
        }
    }
}
