using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 2000f)]
    private float moveForce = 10f;

    private Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //myRigidbody.AddForce(Vector3.forward);
        //myRigidbody.AddForce(Vector3.forward* 10f);
        myRigidbody.AddForce(Vector3.forward * moveForce);
    }

    // Update is called once per frame
    void Update()
    {
        //ACTUALIZACION DE INPUTS
    }

    private void FixedUpdate()
    {
        //ACTUALIZACION DE FUERZA
        //myRigidbody.AddForce(Vector3.forward * 100f);
    }
}
