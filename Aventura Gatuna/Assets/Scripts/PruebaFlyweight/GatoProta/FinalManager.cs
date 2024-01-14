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
        // Obtén la escena actual
        Scene currentScene = SceneManager.GetActiveScene();

        // Verifica si estamos en la escena deseada y la vida del prota es cero
        if (currentScene.name == "CoinFlip" && Connection.Instance.GetCoinWin())
        {
            // Carga la escena del final 1
            LoadFinalScene("Final1");
        }
        if (currentScene.name == "CoinFlip" && !Connection.Instance.GetCoinWin()) {
            LoadFinalScene("Final2");
        }
    }
        public void LoadFinalScene(string sceneName)
    {
        // Carga la escena de Game Over
        SceneManager.LoadScene(sceneName);
    }


}