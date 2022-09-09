using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] sfxCollection;

    private AudioSource sfxSource = null;

    private void Awake()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerEvents.OnHeal += HealingSFX;
        PlayerEvents.OnDamage += DamageSFX;
        PlayerEvents.OnWin += WinSFX;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHeal -= HealingSFX;
        PlayerEvents.OnDamage -= DamageSFX;
        PlayerEvents.OnWin -= WinSFX;
    }

    private void HealingSFX(int hp)
    {
        if (hp < 10) PlaySFX(0, 1.2f);
        else PlaySFX(1, 0.8f);
    }

    private void DamageSFX(float hp)
    {
        if (hp > 10) PlaySFX(2, 1.2f);
        else PlaySFX(3, 0.8f);
    }

    private void PlaySFX(int clipIndex, float volume)
    {
        sfxSource.PlayOneShot(sfxCollection[clipIndex], volume);
    }

    private void WinSFX()
    {
        PlaySFX(4, 1.3f);
    }

}
