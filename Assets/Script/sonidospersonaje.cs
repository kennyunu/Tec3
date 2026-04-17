using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidospersonaje : MonoBehaviour
{

    public AudioClip audio1;
    public AudioClip audio2;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider elemento)
    {
        if(elemento.tag == "moneda")
        {
            audioSource.clip = audio1;
            audioSource.Play();
        }

        if(elemento.tag == "trampa" || elemento.tag == "Sierra")
        {
            audioSource.clip = audio2;
            audioSource.Play();
        }

    }

    private void OnCollisionEnter(Collision toque)
    {
        if(toque.gameObject.CompareTag("Enemigo"))
        {
            audioSource.clip = audio2;
            audioSource.Play();
        }
    }
}