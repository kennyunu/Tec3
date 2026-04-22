using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioVolver : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void cambiarVolver()
    {
        SceneManager.LoadScene("juego");
    }
}
