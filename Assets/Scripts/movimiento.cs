using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{  
    public float JumpForce;
    public float WalkSpeed; 
    public float RunSpeed; 
    private float Horizontal; 
    private Rigidbody2D Rigidbody2D;
    private bool Grounded;
    private bool mirando_derecha = true;
   
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); // 'a' = -1, 'd' = 1, nada = 0

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.2f))
        {
            // Verifica si el personaje está en el suelo creando un rayo hacia abajo
            Grounded = true;
        }        
        else
        { 
            Grounded = false; 
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.B)) 
        {
            Run();
        }
        else
        {
            Walk();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Run()
    {
    Horizontal = Horizontal * RunSpeed;
    }

    private void Walk()
    {
    Horizontal = Horizontal * WalkSpeed;
    }

    private void Girar()
    {
        mirando_derecha = !mirando_derecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void FixedUpdate()
    {
        // Se usa para física ya que se verifica cada cierto tiempo a diferencia de Update
        // que se verifica cada ciertos fotogramas. Esto lo hace más consistente. 

        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
        if(Horizontal < 0 && mirando_derecha){
            Girar();
        }
        else if(Horizontal > 0 && !mirando_derecha){
            Girar();
        }
    }
}
