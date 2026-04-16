using System.Collections;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    [Header("Puntos de movimiento")]
    public Transform puntoA;
    public Transform puntoB;

    [Header("Movimiento")]
    public float velocidad = 2f;
    public float pausaEnPuntos = 1f;
    public float suavizado = 2f; // controla la aceleración

    [Header("Rotación")]
    public float velocidadRotacion = 360f;

    private Vector3 objetivoActual;
    private bool yendoAPuntoB = true;
    private bool enPausa = false;

    void Start()
    {
        if (puntoA == null || puntoB == null)
        {
            Debug.LogError("Asigna los puntos A y B en el inspector.");
            enabled = false;
            return;
        }

        transform.position = puntoA.position;
        objetivoActual = puntoB.position;
    }

    void Update()
    {
        RotarSierra();

        if (!enPausa)
        {
            Mover();
        }
    }

    void RotarSierra()
    {
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }

    void Mover()
    {
        float distancia = Vector3.Distance(transform.position, objetivoActual);

        // Movimiento con aceleración suave
        float velocidadActual = Mathf.Lerp(0, velocidad, 1 / (distancia + 0.1f) * suavizado);

        transform.position = Vector3.MoveTowards(
            transform.position,
            objetivoActual,
            velocidadActual * Time.deltaTime
        );

        // Si llegó al punto
        if (distancia < 0.05f)
        {
            StartCoroutine(PausaYCambio());
        }
    }

    IEnumerator PausaYCambio()
    {
        enPausa = true;

        yield return new WaitForSeconds(pausaEnPuntos);

        // Cambiar objetivo
        yendoAPuntoB = !yendoAPuntoB;
        objetivoActual = yendoAPuntoB ? puntoB.position : puntoA.position;

        enPausa = false;
    }
}