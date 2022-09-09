using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private ParticleSystem fireTrap;

    [SerializeField]
    [Range(5, 20)]
    int delayTrap = 10;


    [SerializeField]
    bool isActive = true;

    void Start()
    {
        fireTrap = GetComponent<ParticleSystem>();
        StartCoroutine(FireTrapCoroutine());
    }

    IEnumerator FireTrapCoroutine()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(delayTrap);
            fireTrap.Play();
        }
    }
}
