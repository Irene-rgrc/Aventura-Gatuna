using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void LoadGameOverScene()
    {
        // Carga la escena de Game Over
        SceneManager.LoadScene("GameOver");
    }


}