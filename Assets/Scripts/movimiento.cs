using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{   public float WalkSpeed; 
    public float RunSpeed; 
    public float JumpForce;
    private float Horizontal; 
    private Rigidbody2D Rigidbody2D;
    private bool Grounded;
    // Start is called before the first frame update
   
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); // a= -1, d = 1, nada = 0

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }        
        else{ 
            Grounded = false; 
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded){
            jump();
        }
        if (Input.GetKeyDown(KeyCode.C ))
        {
            Run();
        }
        else {
            Walk();
        }

    }

    
    private void jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void Run()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * RunSpeed, Rigidbody2D.velocity.y);
    }
    private void Walk()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * WalkSpeed, Rigidbody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);


    }
}
