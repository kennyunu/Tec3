using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animacionModelados : MonoBehaviour {

    public Animator anim; //Variable del animator

    private int dato;
    private int dato2;

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
        animar(dato + "," + dato2);
    }

    void animar(string datoArduino)  //"data1,data2"
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

        anim.SetBool("adelante", false);
        anim.SetBool("atras", false);
        anim.SetBool("derecha", false);
        anim.SetBool("izquierda", false);

        if (dato >= 800)
        {
            left();
        }
        if (dato < 300)
        {
            right();
        }

        if (dato2 >= 800)
        {
            forward();
        }
        if (dato2 < 300)
        {
            backward();
        }
    }
}
