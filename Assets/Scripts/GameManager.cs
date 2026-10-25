using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;

public class GameManager : MonoBehaviour
{
    public TMP_Text scorePlayer1;
    public TMP_Text scorePlayer2;

    public playerController player1;
    public playerController player2;

    public GameObject LoosePanel;
    public AudioSource youGotBaitedSound;
    private float time;
    public TMP_Text timeText;
    public GameObject targetPosition;
    public bool pauseTime;
    private Vector3 einheitsvector = new Vector3(1, 1, 1);
    private bool cutSceneActivated;
    
    public ClickableSceneLink sceneLink;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        sceneLink.pausePanel.SetActive(false);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer1.text = player1.scoreValue.ToString();
        scorePlayer2.text = player2.scoreValue.ToString();
        if (pauseTime == false)
        {
            time += Time.deltaTime;
        }
        
        timeText.text = time.ToString("0");
        // if (time <= Mathf.Round(0f))
        // {
        //     pauseTime = true;
        // }

        if (time >= 67)
        {
            youLoose();
        }
    }

    // private void FixedUpdate()
    // {
    //     if (cutSceneActivated)
    //     {
    //         player1.rb.MovePosition(targetPosition.transform.position +
    //                                 einheitsvector * Time.deltaTime * player1.moveSpeed);
    //     }
    //     
    // }

    public void youLoose()
    {
        LoosePanel.SetActive(true);
        timeText.gameObject.SetActive(false);
        player1.GetComponent<playerController>().enabled = false;
        player2.GetComponent<playerController>().enabled = false;
        StartCoroutine(sceneLink.waitAndChangeScene(3));
    }
    

    // void cutScene()
    // {
    //     cutSceneActivated = true;
    //     Debug.Log("cutScene called");
    //     player1.GetComponent<playerController>().enabled = false;
    //     player2.GetComponent<playerController>().enabled = false;
    //     // Time.timeScale = 0;
    //
    //     
    //     // player1.rb.MovePosition(targetPosition.transform.position + einheitsvector * Time.deltaTime * player1.moveSpeed);
    //     
    //     // if (player1.scoreValue > player2.scoreValue)
    //     // {
    //     //     player1.transform.position = Vector3.MoveTowards(player1.transform.position, targetPosition.transform.position, 
    //     //         player1.moveSpeed);
    //     // } 
    //     // else if (player2.scoreValue > player1.scoreValue)
    //     // {
    //     //     player2.transform.position = Vector3.MoveTowards(player2.transform.position, targetPosition.transform.position, 
    //     //         player2.moveSpeed);
    //     // }
    // }
}
