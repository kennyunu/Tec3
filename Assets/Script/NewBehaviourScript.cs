using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public float valor = 60f;
    public float velocidad = 2f;

    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * valor;
        transform.Rotate(Vector3.up * horizontal);

        vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * valor;
        transform.Rotate(Vector3.up * vertical);

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*velocidad);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left*Time.deltaTime*velocidad);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right*Time.deltaTime*velocidad);
        }

        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back*Time.deltaTime*velocidad);
        }
    }
}