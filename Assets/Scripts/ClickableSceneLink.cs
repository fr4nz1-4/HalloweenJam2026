using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ClickableSceneLink : MonoBehaviour
{
    public string sceneToLoad;  
    public GameObject pausePanel;
    public GameManager gameManager;
    
    public void ChangeScene(string sceneToLoad)
    {
        Debug.Log("called changeScene");
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void QuitGame()
    {
        Debug.Log("Spiel wird beendet..."); // Funktioniert nur im Editor
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.activeSelf && SceneManager.GetActiveScene().name == "main")
            Pause();
    }

    public void GoBackToGame()
    {
        gameManager.player1.GetComponent<playerController>().enabled = true;
        gameManager.player2.GetComponent<playerController>().enabled = true;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        gameManager.player1.GetComponent<playerController>().enabled = false;
        gameManager.player2.GetComponent<playerController>().enabled = false;
        
    }
    
    public IEnumerator waitAndChangeScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChangeScene("StartScene");

    }

}