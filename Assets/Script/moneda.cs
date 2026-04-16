using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneda : MonoBehaviour
{
    private int puntaje = 0;
    private string textoPuntaje;
    public TextMeshProUGUI guiTexto;

    public GameObject puerta1;
    public GameObject puerta2;
    public GameObject puerta3;

    public TextMeshProUGUI textoPuerta1;
    public TextMeshProUGUI textoPuerta2;
    public TextMeshProUGUI textoPuerta3;
    public TextMeshProUGUI textoWin;

    public Animator anim;
    public MonoBehaviour movimiento;
    private bool win = false;

    private bool puerta1Abierta = false;
    private bool puerta2Abierta = false;
    private bool puerta3Abierta = false;
    
    void Start()
    {
        textoWin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textoPuntaje = "Monedas:" + puntaje.ToString();

        guiTexto.text = textoPuntaje;

        if (puntaje >= 10 && !puerta1Abierta)
        {
            puerta1.SetActive(false);
            StartCoroutine(MostrarTexto(textoPuerta1));
            puerta1Abierta = true;
        }

        else if (puntaje >= 20 && !puerta2Abierta)
        {
            puerta2.SetActive(false);
            StartCoroutine(MostrarTexto(textoPuerta2));
            puerta2Abierta = true;
        }

        else if (puntaje >= 30 && !puerta3Abierta)
        {
            puerta3.SetActive(false);
            StartCoroutine(MostrarTexto(textoPuerta3));
            puerta3Abierta = true;
        }
        else if (puntaje >= 40 && !win)
        {
            textoWin.gameObject.SetActive(true);
            anim.SetBool("ganar", true);
            movimiento.enabled = false;
            win = true;
        }

    }

    private IEnumerator MostrarTexto(TextMeshProUGUI texto)
    {
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        texto.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider elemento)
    {
        if (elemento.tag == "moneda")
        {
            Destroy(elemento.gameObject);

            puntaje++;

            print(puntaje);
        }
    }

}
