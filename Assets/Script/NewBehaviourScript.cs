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
    private int dato;

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
                mover(puerto.ReadLine());
                print(puerto.ReadLine());
            }
            catch(System.Exception)
            {

            }
        }
    }

     void mover(string datoArduino)
    {
        dato = int.Parse(datoArduino);
        
        if(dato<400)
        {
            transform.Translate(Vector3.left * vel);
        }
        else if(dato>601)
        {
            transform.Translate(Vector3.right * vel);
        }        
    }
}