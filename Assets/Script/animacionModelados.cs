using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animacionModelados : MonoBehaviour {

    public Animator anim; //Variable del animator


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
        if (Input.GetKey(KeyCode.W))
        {
            forward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            backward();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            right();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            left();
        }
        else
        {
            anim.SetBool("adelante", false);
            anim.SetBool("atras", false);
            anim.SetBool("derecha", false);
            anim.SetBool("izquierda", false);
        }

    }
}
