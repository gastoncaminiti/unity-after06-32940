using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int score;
    public int Score { get => score; }

    public static event Action<int> OnChangeScore;


    public static GameManager instance;

    [SerializeField]
    private ScoreHistory myHistory;

    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
            score = 0;
            //PlayerCollision.OnChangeHP += SetScore;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        OnChangeScore?.Invoke(score);
        Debug.Log(myHistory.playerName);
        Debug.Log(myHistory.scores[0]);
        Debug.Log(Application.persistentDataPath);
        LoadJSON();
    }

    public void SetScore(float newValue)
    {
        score += ((int)newValue);
        OnChangeScore?.Invoke(score);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("Nombre", "Coder");
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
        PlayerPrefs.Save();
        myHistory.scores.Add(score);
        SaveJSON();
    }

    private void OnDisable()
    {
        PlayerCollision.OnChangeHP -= SetScore;
    }

    //-------------- SERIALIZACION ------------------//


    //EL METODO QUE GUARDA EN DISCO
    private void SaveJSON()
    {
        //CONVERTIR LA INFO DE MI HISTORIAL A UN OBJETO AUXILAR
        ScoreHistory data = new ScoreHistory();
        data.playerName = "EL NOMBRE ES :" + myHistory.playerName;
        data.scores = myHistory.scores;
        //2 TRANFORMAR LAS PROPIEDADES DEL OBJETO A JSON
        string json = JsonUtility.ToJson(data);
        //3 CREAR O ESCRIBIR UN ARCHIVO CON LA CADENA JSON
        File.WriteAllText(Application.persistentDataPath + "/myScoreHistory.json", json);
    }
    //EL METODO QUE RECUPERA DEL DISCO
    private void LoadJSON()
    {
        //CREO LA RUTA DE ARCHIVO
        string path = Application.persistentDataPath + "/myScoreHistory.json";
        //ME PREGUNTO SI EL ARCHIVO EXISTE
        if (File.Exists(path))
        {
            //LEO EL ARCHIVO Y OBTENGO UN STRING
            string json = File.ReadAllText(path);
            //TRANSFORMO EL JSON EN OBJETO
            ScoreHistory data = JsonUtility.FromJson<ScoreHistory>(json);


            myHistory.playerName = data.playerName;
            myHistory.scores = data.scores;

        }

    }

}
