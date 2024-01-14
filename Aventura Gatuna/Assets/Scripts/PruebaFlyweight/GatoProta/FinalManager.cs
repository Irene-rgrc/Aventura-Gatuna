using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    public GameObject prota;

    public void Update()
    {
        SelectFinalScene();
    }

    public void SelectFinalScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log(Connection.Instance.GetCoinWin());
        if (Connection.Instance.GetCoinWin()==1)
        {
            Invoke("LoadFinaleScene1", 5f);
        }
        if (Connection.Instance.GetCoinWin()==2) {
            Invoke("LoadFinaleScene2", 5f);
        }
    }
    void LoadFinaleScene1()
    {
        SceneManager.LoadScene("Final1");
    }

    void LoadFinaleScene2()
    {
        SceneManager.LoadScene("Final2");
    }

}