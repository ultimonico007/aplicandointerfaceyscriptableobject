using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemigo : MonoBehaviour, IPresentacion, ITakeDamage
{
    public EnemigoData data;

    private int vidaActual;

    void Start()
    {
        vidaActual = data.vida;
    }

    public void Accion()
    {
        Debug.Log($"{data.nombre} dice: {data.saludo}");
    }


    public void TakeDamage(int amount)
    {
        vidaActual -= amount;
        Debug.Log($"{data.nombre} recibe {amount} de daño. Vida actual: {vidaActual}");

        if (vidaActual <= 0)
        {
            Debug.Log($"{data.nombre} ha muerto.");
            Destroy(gameObject);
        }
    
    }
}
