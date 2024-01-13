using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer.Interfaces;
using Command.Interfaces;
using UnityEngine.SceneManagement;

public class ObserverGame : MonoBehaviour, IObserver<GameObject>
{
    private GameObject enemy;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        SubjectPlayer subject = player.GetComponent<SubjectPlayer>();
        subject.AddObserver(this);
        
    }
    public void UpdateObserver(GameObject data)
    {
        enemy = data;
        if (data.CompareTag("Enemy"))
        {
            //if(enemy.GetComponent<Enemy>().GetType() != "Gambler")
            if (enemy.GetComponent<Enemy>().Attributes.enemyType == "Gambler")
            {
                SceneManager.LoadScene("MiniBlackJack");
                Connection.Instance.SetPosition(player.GetComponent<Transform>().position);
            }
            else if (enemy.GetComponent<Enemy>().Attributes.enemyType != "Gambler")
            {
                Connection.Instance.SetProbability(enemy.GetComponent<Enemy>().GetProbability());
                Connection.Instance.SetMoney(player.GetComponent<GatoPlayer>().getMoney());
                Connection.Instance.SetPosition(player.GetComponent<Transform>().position);
                SceneManager.LoadScene("PiedraPapelTijera");
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("PiedraPapelTijera"));
            }
        }
    }
}
