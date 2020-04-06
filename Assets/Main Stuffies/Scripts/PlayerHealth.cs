using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int basehealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthtext;
    [SerializeField] AudioClip reachedBase;
    private void Start()
    {
        
        healthtext.text = basehealth.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        basehealth -= healthDecrease;
        healthtext.text = basehealth.ToString();
        GetComponent<AudioSource>().PlayOneShot(reachedBase);
        if (basehealth == 0) 
        {
            SceneManager.LoadScene(0);
        }
    }

}
