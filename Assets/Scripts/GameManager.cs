using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scorePlayer1;
    public TMP_Text scorePlayer2;

    public playerController player1;
    public playerController player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer1.text = player1.scoreValue.ToString();
        scorePlayer2.text = player2.scoreValue.ToString();
    }
}
