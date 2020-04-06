
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem Deathfx;
    [SerializeField] ParticleSystem Hitfx;
    [SerializeField] AudioClip HitSFX;
    [SerializeField] AudioClip DeathSFX;
    [SerializeField] float Hits = 5;

    [Header("Unity Stuff")]
    public Image healthBar;
    public float health;
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        health = Hits;
    }
    public void enemypos() { transform.localPosition = new Vector3(0, 0, 0); }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (Hits <= 0){KillEnemy();}
    }


    private void ProcessHit()
    {
        
        Hits = Hits - 1;
        healthBar.fillAmount = Hits / health;
        Hitfx.Play();
        myAudioSource.PlayOneShot(HitSFX);
    }


    public void KillEnemy()
    {
        var deathfx = Instantiate(Deathfx, transform.position, Quaternion.identity);
        deathfx.Play();
        var group = GameObject.Find("DeathFXGroup");
        deathfx.transform.SetParent(group.transform);
        //float destroyDelay = deathfx.main.duration;
        AudioSource.PlayClipAtPoint(DeathSFX, Camera.main.transform.position);
        Destroy(deathfx.gameObject, 2f);
        Destroy(gameObject);

    }
}

