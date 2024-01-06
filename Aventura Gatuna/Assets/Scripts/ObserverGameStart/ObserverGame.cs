using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer.Interfaces;
using Command.Interfaces;
using UnityEngine.SceneManagement;

public class ObserverGame : MonoBehaviour, IObserver<GameObject>
{
    private int enemyProbabillity = 90;
    public static ObserverGame instance;
    private static IGameController gameplayController;

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
            SceneManager.LoadScene("PiedraPapelTijera");
            //se usa data para cambiar la probabilidad a la que sea
        }
    }
    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if(controller != null) {
            if (controller.GetComponent<GameplayController>() != null) { gameplayController = controller.GetComponent<GameplayController>(); }
            //if (controller.GetComponent<FlipScript>() != null){ gameplayController = controller.GetComponent<FlipScript>();}
            gameplayController.SetEnemyProb(enemyProbabillity);
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
