using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad = "SampleScene"; // Geçmek istediðiniz sahne adý
    public string sceneToLoad2 = "Menu"; // Geçmek istediðiniz sahne adý


    public void StartTheGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void QuitGame()
    {
        Debug.Log("Oyun kapatýlýyor...");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneToLoad2);
    }
}
