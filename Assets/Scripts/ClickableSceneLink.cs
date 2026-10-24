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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.player1.GetComponent<playerController>().enabled = false;
            gameManager.player2.GetComponent<playerController>().enabled = false;
            
            pausePanel.SetActive(true);
        }
    }

    public void GoBackToGame()
    {
        gameManager.player1.GetComponent<playerController>().enabled = true;
        gameManager.player2.GetComponent<playerController>().enabled = true;
        
        pausePanel.SetActive(false);
    }
}