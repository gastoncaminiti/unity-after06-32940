using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private float live = 1;
    public float HP { get { return live; } }

    private void OnEnable()
    {
        PlayerEvents.OnHeal += Healing;
        PlayerEvents.OnDamage += Damage;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHeal -= Healing;
        PlayerEvents.OnDamage -= Damage;
    }

    public void Healing(int value)
    {
        live += value;
        //DISPARAR EFECTO
        //DISPARAR SONIDO
    }

    public void Damage(float value)
    {
        live -= value;
    }
}
