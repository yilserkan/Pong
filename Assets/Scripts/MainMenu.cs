using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerOne = null;
    [SerializeField] private GameObject playerTwo = null;
    [SerializeField] private GameObject aiPlayer = null;
    [SerializeField] private GameObject ball = null;

    private void Awake() 
    {
        Time.timeScale = 0;   
    }

    public void StartGameCoop()
    {
        playerOne.SetActive(true);
        playerTwo.SetActive(true);
        ball.SetActive(true);

        Time.timeScale = 1;
    }

    public void StartGameAgainstAI()
    {
        playerOne.SetActive(true);
        aiPlayer.SetActive(true);
        ball.SetActive(true);

        Time.timeScale = 1;
    }

    public void ResetPosition()
    {
        playerOne.transform.position = new Vector3(-8f,0f,0f);
        playerTwo.transform.position = new Vector3(8f, 0f, 0f);
        aiPlayer.transform.position = new Vector3(8f, 0f, 0f);
    }
}
