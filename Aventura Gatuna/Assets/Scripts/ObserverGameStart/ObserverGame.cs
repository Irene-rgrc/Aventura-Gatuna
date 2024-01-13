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
            //if(enemy.GetComponent<Enemy>().GetEnemyType() == "Gambler")
            if (enemy.GetComponent<Enemy>().Attributes.enemyType == "Gambler")
            {
                Connection.Instance.SetPosition(player.GetComponent<Transform>().position);
                Connection.Instance.SetMoney(player.GetComponent<GatoPlayer>().getMoney());
                Connection.Instance.SetIsPlaying(true);
                SceneManager.LoadScene("MiniBlackJack"); 
            }
            //if(enemy.GetComponent<Enemy>().GetEnemyType() != "Gambler")
            else if (enemy.GetComponent<Enemy>().Attributes.enemyType != "Gambler")
            {
                Connection.Instance.SetProbability(enemy.GetComponent<Enemy>().GetProbability());
                Connection.Instance.SetMoney(player.GetComponent<GatoPlayer>().getMoney());
                Debug.Log(player.GetComponent<GatoPlayer>().getMoney());
                Debug.Log(enemy.GetComponent<Enemy>().GetProbability());
                Connection.Instance.SetPosition(player.GetComponent<Transform>().position);
                Connection.Instance.SetIsPlaying(true);
                SceneManager.LoadScene("PiedraPapelTijera");
            }
        }
    }
}
