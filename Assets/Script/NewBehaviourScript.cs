using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class NewBehaviourScript : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public float valor = 60f;
    public float vel = 0.5f;
    public float vel2 = 0.5f;
    private  float distanciaMov;
    SerialPort puerto = new SerialPort("COM3", 9600);
    public int dato;
    public int dato2;

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

    void mover(string datoArduino)  //"data1,data2"
                                    //  0      1    
                                    //datosArray[0] = "data1"
                                    //datosArray[1] = "data2"
    {
        string[] datosArray = datoArduino.Split(char.Parse(","));

        if (datosArray.Length == 2)
        {
            dato = int.Parse(datosArray[0]);   //data1 = "data1"
            dato2 = int.Parse(datosArray[1]);  //data2  = "data2"
            print(dato + "   " + dato2);
        }

        if (dato >= 800)
        {
            //Space.Self Space.World
            transform.Translate(Vector3.left * distanciaMov, Space.Self);       }
        if (dato < 300)
        {
            transform.Translate(Vector3.right * distanciaMov, Space.Self);       }

        if (dato2 >= 800)
        {
            transform.Translate(Vector3.forward * distanciaMov, Space.Self);       }
        if (dato2 < 300)
        {
            transform.Translate(Vector3.back * distanciaMov, Space.Self);       }
        

    }
}