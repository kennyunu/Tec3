using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class NewBehaviourScript : MonoBehaviour
{
    /*public float horizontal;
    public float vertical;

    public float valor = 60f;*/
    public float vel = 1.5f;
    /*public float vel2 = 1.5f;*/
    private  float distanciaMov;
    SerialPort puerto = new SerialPort("COM3", 9600);
    public int dato;
    public int dato2;
    public int dato3;
    public int dato4;

    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }


    void Update()
    {
        /*horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * valor;
        transform.Rotate(Vector3.up * horizontal);

        vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * valor;
        transform.Rotate(Vector3.up * vertical);*/

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
        print(datoArduino);
        string[] datosArray = datoArduino.Split(',');

        if (datosArray.Length == 4)
        {
            dato = int.Parse(datosArray[0]);   //data1 = "data1"
            dato2 = int.Parse(datosArray[1]);  //data2  = "data2"
            dato3 = int.Parse(datosArray[2]);  //data3  = "data3"
            dato4 = int.Parse(datosArray[3]);  //data4  = "data4"
            /*print(dato + "   " + dato2 + "   " + dato3 + "   " + dato4);*/
        }

        if (dato == 1)
        {
            //Space.Self Space.World
            transform.Translate(Vector3.left * distanciaMov, Space.Self);       
        }
        if (dato2 == 1)
        {
            transform.Translate(Vector3.right * distanciaMov, Space.Self);       
        }

        if (dato3 >= 800)
        {
            transform.Translate(Vector3.forward * distanciaMov, Space.Self);       
        }
        if (dato3 <= 300)
        {
            transform.Translate(Vector3.back * distanciaMov, Space.Self);       
        }
        if (dato4 >= 800)
        {
            transform.Rotate(Vector3.up * vel, Space.Self);
        }
        if (dato4 <= 300)
        {
            transform.Rotate(Vector3.down * vel, Space.Self);
        }
        
        

    }
}