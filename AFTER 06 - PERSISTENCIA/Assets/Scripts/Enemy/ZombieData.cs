using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie Data", menuName = "Crear Zombie Data")]
public class ZombieData : ScriptableObject
{
     // DESING DATA
    [Header("CONFIGUARACION DE MOVIENTO")]

    [Tooltip("LA VELOCIDAD DE MOVIMIENTO ES ENTRE 1 Y 10")]
    [SerializeField]
    [Range(1f, 10f)]
    public float speed = 2f;

    [SerializeField]
    [Range(1f, 10f)]
    public float jumpSpeed = 2f;

    [SerializeField]
    [Range(1f, 10f)]
    private float angularSpeed = 2f;
    

    [Header("CONFIGUARACION DE ATAQUE")]
    
    [SerializeField]
    [Range(1f, 10f)]
    private float rangeAttack = 2f;
    public float RangeAttack { get => rangeAttack; }
    public float AngularSpeed { get => angularSpeed; set => angularSpeed = value; }

    void SetAngulaSpeed(float value){
        angularSpeed = value;
    }
}
