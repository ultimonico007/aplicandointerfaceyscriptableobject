using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rayDistance = 3f;
    public int damageAmount = 10;
    void Update()
    {
        // Movimiento lateral simple
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        // Interactuar con R
        if (Input.GetKeyDown(KeyCode.R))
        {
            InteractuarConRaycast();
        }

        // Atacar con E
        if (Input.GetKeyDown(KeyCode.E))
        {
            AtacarConRaycast();
        }
    }

    void InteractuarConRaycast()
    {
        Ray ray = new Ray(transform.position, transform.right);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            IPresentacion presentacion = hit.collider.GetComponent<IPresentacion>();
            if (presentacion != null)
            {
                presentacion.Accion();
            }
            else
            {
                Debug.Log("No hay enemigo para saludar.");
            }
        }
    }

    void AtacarConRaycast()
    {
        Ray ray = new Ray(transform.position, transform.right);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            ITakeDamage objetivo = hit.collider.GetComponent<ITakeDamage>();
            if (objetivo != null)
            {
                objetivo.TakeDamage(damageAmount);
            }
            else
            {
                Debug.Log("No hay enemigo para atacar.");
            }
        }
    }

}
