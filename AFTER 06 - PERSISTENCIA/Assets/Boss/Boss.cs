using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip voice1;
    [SerializeField] AudioClip voice2;

    private AudioSource myAudioPlayer;

    [SerializeField]
    Renderer myHead;

    void Start()
    {
        myAudioPlayer = GetComponent<AudioSource>();
        Invoke("CallVoice1", 2f);
        Invoke("CallVoice2", 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CallVoice1()
    {
        myAudioPlayer.PlayOneShot(voice1);
        myHead.materials[4].SetColor("_EmissionColor", Color.cyan);
    }


    private void CallVoice2()
    {
        if (!myAudioPlayer.isPlaying)
        {
            myAudioPlayer.PlayOneShot(voice2);
        }
        myHead.materials[4].SetColor("_EmissionColor", Color.green);
    }
}
