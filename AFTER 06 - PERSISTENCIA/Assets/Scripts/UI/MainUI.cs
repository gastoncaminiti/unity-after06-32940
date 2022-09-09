using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CARGANDO ESCENA");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // UN METODO PARA CAMBIAR LA ESCENA -> CUANDO SE PRESIONAL EL BOTON PLAY
    public void OnClickPlay()
    {
        Debug.Log("SE PRESIONO EL BOTON PLAY");
        //SceneManager.LoadScene("Level0");
        SceneManager.LoadScene(1);
    }

    public void OnResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
