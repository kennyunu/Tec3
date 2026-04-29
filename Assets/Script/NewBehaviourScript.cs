using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class NewBehaviourScript : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public float valor = 60f;
    public float vel = 2f;

    private  float distanciaMov;
    SerialPort puerto = new SerialPort("COM20", 9600);

    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }


    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * valor;
        transform.Rotate(Vector3.up * horizontal);

        vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * valor;
        transform.Rotate(Vector3.up * vertical);

        distanciaMov = vel * Time.deltaTime;

        if(puerto.IsOpen)
        {
            try
            {
                mover(puerto.ReadByte());
                print(puerto.ReadByte());
            }
            catch(System.Exception)
            {

            }
        }
    }

     void mover(int direccion)
    {
        if(direccion == 1)
        {
            transform.Translate(Vector3.left * distanciaMov);
        }
        if(direccion == 2)
        {
            transform.Translate(Vector3.right * distanciaMov);
        }
        if(direccion == 3)
        {
            transform.Translate(Vector3.forward * distanciaMov);
        }
        if(direccion == 4)
        {
            transform.Translate(Vector3.back * distanciaMov);
        }
    }
}