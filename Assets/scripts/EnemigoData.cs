using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoEnemigo", menuName = "Enemigo Data")]
public class EnemigoData : ScriptableObject
{
    public string nombre;
    public int vida;
    public string saludo;
}