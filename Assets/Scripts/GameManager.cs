using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public TMP_Text scorePlayer1;
    public TMP_Text scorePlayer2;

    public playerController player1;
    public playerController player2;

    public GameObject LoosePanel;
    public AudioSource youGotBaitedSound;
    
    public ClickableSceneLink sceneLink;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        sceneLink.pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer1.text = player1.scoreValue.ToString();
        scorePlayer2.text = player2.scoreValue.ToString();
    }

    public void youLoose()
    {
        LoosePanel.SetActive(true);
        player1.GetComponent<playerController>().enabled = false;
        player2.GetComponent<playerController>().enabled = false;
    }

    void Pause()
    {
        // PausePanel.SetActive(true);
        player1.GetComponent<playerController>().enabled = false;
        player2.GetComponent<playerController>().enabled = false;
    }

    void continueGame()
    {
        // PausePanel.SetActive(false);
        player1.GetComponent<playerController>().enabled = true;
        player2.GetComponent<playerController>().enabled = true;
    }
    
    public IEnumerator waitAndChangeScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sceneLink.ChangeScene("StartScene");

    }
}
