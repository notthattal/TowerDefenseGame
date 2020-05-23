using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int baseHitpoints = 10;
    [SerializeField] Text healthText = default;
    [SerializeField] AudioClip baseHitSFX = default;


    private void Start()
    {
        healthText.text = baseHitpoints.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        baseHitpoints -= 1;
        healthText.text = baseHitpoints.ToString();
        GetComponent<AudioSource>().PlayOneShot(baseHitSFX);
    }
}
