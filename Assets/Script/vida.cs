using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    private int life = 3;

    public GameObject jugador;

    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;

    public TextMeshProUGUI textoGameOver;

    public GameObject efectoSangre;

    void Start()
    {
        jugador.SetActive(true);
        textoGameOver.gameObject.SetActive(false);
        ActualizarCorazones();
    }

    void ActualizarCorazones()
    {
        corazon1.SetActive(life >= 3);
        corazon2.SetActive(life >= 2);
        corazon3.SetActive(life >= 1);
    }

    private void OnTriggerEnter(Collider elemento)
    {
        if (elemento.CompareTag("trampa") || elemento.CompareTag("Sierra"))
        {
            life--;
            ActivarSangre();
            Debug.Log("Vida: " + life);

            ActualizarCorazones();

            if (elemento.CompareTag("trampa"))
            {
                Destroy(elemento.gameObject);
            }

            if (life <= 0)
            {
                Derrota();
            }
        }
    }

    private void OnCollisionEnter(Collision toque)
    {
        if (toque.gameObject.CompareTag("Enemigo"))
        {
            life--;
            ActivarSangre();
            Debug.Log("Vida: " + life);

            ActualizarCorazones();

            if (life <= 0)
            {
                Derrota();
            }
        }
    }

    void Derrota()
    {
        jugador.SetActive(false);
        textoGameOver.gameObject.SetActive(true);
        
        Invoke("cargarescena", 2f);

    }

    void cargarescena()
    {
        SceneManager.LoadScene("derrota");
    }

    void ActivarSangre()
    {
        efectoSangre.SetActive(true);

        ParticleSystem ps = efectoSangre.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }

        Invoke("DesactivarSangre", 2f);
    }

    void DesactivarSangre()
    {
        efectoSangre.SetActive(false);
    }
}