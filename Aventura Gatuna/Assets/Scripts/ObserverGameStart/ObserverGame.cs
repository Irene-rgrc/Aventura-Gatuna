using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer.Interfaces;
using UnityEngine.SceneManagement;

public class ObserverGame : MonoBehaviour, IObserver<GameObject>
{
    public float enemyProbabillity = 50;
    public static ObserverGame instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        GameObject player = GameObject.FindWithTag("Player");
        SubjectPlayer subject = player.GetComponent<SubjectPlayer>();
        subject.AddObserver(this);
    }
    public void UpdateObserver(GameObject data)
    {
        if (data.CompareTag("Enemy"))
        {
            //rand elige juego y se carga la escena
            SceneManager.LoadScene("CoinFlip");
            //se cargan las stats
        }
    }
}
