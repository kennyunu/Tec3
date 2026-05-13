using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animacionModelados : MonoBehaviour {

    public Animator anim; //Variable del animator

    private int dato;
    private int dato2;
    private int dato3;

    public NewBehaviourScript controlador;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }


    public void forward()
    {
        anim.SetBool("adelante", true);
    }

    public void backward()
    {
        anim.SetBool("atras", true);
    }

    public void right()
    {
        anim.SetBool("derecha", true);
    }

    public void left()
    {
        anim.SetBool("izquierda", true);
    }


    // Update is called once per frame
    void Update ()
    {
        dato = controlador.dato;
        dato2 = controlador.dato2;
        dato3 = controlador.dato3;
        animar(dato + "," + dato2 + "," + dato3);
    }

    void animar(string datoArduino)  //"data1,data2,data3"
                                    //  0      1      2    
                                    //datosArray[0] = "data1"
                                    //datosArray[1] = "data2"
                                    //datosArray[2] = "data3"
    {
        string[] datosArray = datoArduino.Split(',');

        if (datosArray.Length == 4)
        {
            dato = int.Parse(datosArray[0]);   //data1 = "data1"
            dato2 = int.Parse(datosArray[1]);  //data2  = "data2"
            dato3 = int.Parse(datosArray[2]);  //data3  = "data3"
            print(dato + "   " + dato2 + "   " + dato3);
        }

        anim.SetBool("adelante", false);
        anim.SetBool("atras", false);
        anim.SetBool("derecha", false);
        anim.SetBool("izquierda", false);

        if (dato == 1)
        {
            left();
        }
        if (dato2 == 1)
        {
            right();
        }

        if (dato3 >= 800)
        {
            forward();
        }
        if (dato3 <= 300)
        {
            backward();
        }
    }
}
