using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class Enemigo: MonoBehaviour 
{ 
    public Transform jugador; 
    public float velocidad = 0.65f;

    public bool moverse = true;
    public bool atacar = true;

    public Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    void Update() 
    { 
        if (jugador == null) return;

        if (moverse)
        {
            anim.SetBool("caminar", true);
            Vector3 direccion = (jugador.position - transform.position).normalized; 
            direccion.y = 0;

            transform.position += direccion * velocidad * Time.deltaTime; 
            transform.LookAt(jugador); 
        }
        else
        {
            anim.SetBool("caminar", false);
        }

        
    }

    private void OnCollisionEnter(Collision toque)
    {
        if (toque.gameObject.CompareTag("jugador") && atacar)
        {
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {   
        moverse = false;
        atacar = false;

        yield return new WaitForSeconds(2f);

        atacar = true;
        moverse = true;

    }
}
