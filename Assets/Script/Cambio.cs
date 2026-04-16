using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void cambiarEscena()
    {
        SceneManager.LoadScene("juego");
    }
}
