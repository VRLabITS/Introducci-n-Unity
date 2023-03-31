using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptejemplo : MonoBehaviour
{
    public float velocidad = 2.0f;
    public Rigidbody rb;
    private PlayerControls controls;
    public Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(direction.x * velocidad, rb.velocity.y, direction.y  * velocidad);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonDown("Jump"))
        if (controls.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("Salto presionado");
            rb.AddForce(Vector3.up * 12, ForceMode.Impulse);
        }

        direction = controls.Player.Move.ReadValue<Vector2>();
        // transform.Translate(movimiento * Time.deltaTime * velocidad);
        Vector3 directionXZ = new Vector3(direction.x, 0f, direction.y);   
        // rb.AddForce(directionXZ * velocidad);

        //rb.velocity.y
        

        // Obtener el desplazamiento que el usuario indica
        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");
        //
        // rb.AddForce(new Vector3(x, 0f, z));

        // Construimos un vector que describa el desplazamiento
        //Vector3 movimiento = new Vector3(x, 0, z);
        // Movemos el objeto
        //transform.Translate(movimiento * Time.deltaTime * velocidad);
    }
}
