using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo : MonoBehaviour
{

    public AudioClip audio1;

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
        if(elemento.tag == "jugador")
        {
            audioSource.clip = audio1;
            audioSource.Play();
        }
    }
}