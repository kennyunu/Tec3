using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class vida : MonoBehaviour
{
    private int life=3;

    public GameObject jugador;

    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public TextMeshProUGUI textoGameOver;
    void Start()
    {
        jugador.SetActive(true);
        textoGameOver.gameObject.SetActive(false);
        
    }

    
    void Update()
    {
        if(life == 3)
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
        }

        else if(life == 2)
        {
            corazon1.SetActive(false);
            corazon2.SetActive(true);
            corazon3.SetActive(true);
        }

        else if(life == 1)
        {
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(true);
        }

        else if(life <= 0)
        {
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider elemento)
    {
        if(elemento.tag == "trampa" || elemento.tag == "Sierra")
        {
            life--;
            print(life);
            if(elemento.tag == "trampa")
            {
                Destroy(elemento.gameObject);
            }
            
            if(life <= 0)
            {
                corazon1.SetActive(false);
                corazon2.SetActive(false);
                corazon3.SetActive(false);
                jugador.SetActive(false);
                textoGameOver.gameObject.SetActive(true); 
            }
        }
    }

    private void OnCollisionEnter(Collision toque)
    {
        if(toque.gameObject.CompareTag("Enemigo"))
        {
            life--;
            print(life);
            if(life <= 0)
            {
                jugador.SetActive(false);
                textoGameOver.gameObject.SetActive(true); 
            }
        }
    }
}