using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private  float RepeatRate = 1f;

    [SerializeField]
    private float Time = 1f;

    // Start is called before the first frame update
    private Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();
        InvokeRepeating("Battery", Time, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Battery(){
        myLight.intensity-=0.5f;
        if(myLight.intensity == 0) CancelInvoke("Battery");
    }
}
