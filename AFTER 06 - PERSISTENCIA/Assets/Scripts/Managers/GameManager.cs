using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private static int score;
    public static int Score { get => score; set => score = value; }


    public static GameManager instance;

    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
            score = 0;
            PlayerCollision.OnChangeHP += SetScore;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void SetScore(float newValue)
    {
        score += ((int)newValue) * 200;
        Debug.Log("DESDE EL GM "+score);
    }

    private void OnDisable()
    {
        PlayerCollision.OnChangeHP -= SetScore;
    }
}
