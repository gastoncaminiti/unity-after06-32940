using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    [SerializeField]
    private float rayDistance = 10f;

    [SerializeField] private GameObject bullet;

    private bool canShoot = true;

    [SerializeField] ParticleSystem shootParticle;

    [SerializeField] bool isActive = true;

    [SerializeField] GameObject[] waypoints;

    [SerializeField][Range(3,20)] float speed = 8;

    void Start()
    {
        StartCoroutine(RotateBehavior());
        StartCoroutine(WaypointsBehavior());
    }

    private void Update()
    {
        // SE EJECUTA CADA FRAME
    }

    //CORRUTINA ES UN METODO QUE SE EJECUTA CON TIEMPOS DE ESPERA INDEPENDIENTES DEL FPS
    IEnumerator RotateBehavior()
    {

        while (isActive)
        {
            for (int i = 0; i < 4; i++)
            {
                //ESPERAR OTROS DOS SEGUNDOS PARA VOLVER A ROTAR
                yield return new WaitForSeconds(2f);
                //ESPERAR DOS SEGUNDOS ANTES DE ROTAR
                transform.Rotate(0f, 90f, 0f);
            }
        }

    }

    IEnumerator WaypointsBehavior()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            //TE DESPLAZAS AL PUNTO EN I
            while (transform.position != waypoints[i].transform.position)
            {
                yield return null;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, speed * Time.deltaTime);
            }
            //ESPERAS UNOS SEGUNDOS
            yield return new WaitForSeconds(2f);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CannonRaycast();
    }

    private void CannonRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player") && canShoot)
            {
                Debug.Log("COLLISION CON PLAYER");
                Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                shootParticle.Play();
                canShoot = false;
                Invoke("delayShoot", 1f);
            }
        }
    }

    void delayShoot()
    {
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = shootPoint.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(shootPoint.position, direction);
        //Gizmos.DrawLine(shootPoint.position, direction); ESTE GIZMO NO AFECTA LA ROTACION
    }
}
