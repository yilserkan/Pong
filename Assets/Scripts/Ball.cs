using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform ballTransform = null;
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private ScoreHandler scoreHandler = null;
    [SerializeField] private float ballStartThrust = 10f;
    [SerializeField] [Range(0f, 1f)] private float spreadAmount = 0.6f;
    [SerializeField] private float speedMultiplier = 1.1f;
    [SerializeField] private float ballDirection = 1;

    private void Start()
    {   
        ScoreHandler.ScoreHasChanged += ThrowBall;
        ThrowBall();
    }

    private void OnDestroy() 
    {
        ScoreHandler.ScoreHasChanged -= ThrowBall;    
    }

    private void ThrowBall()
    {
        ballTransform.position = Vector3.zero;

        if(scoreHandler.GetLastScoredPlayer() == 0)
        {
            float ballThurstDirection = Random.Range(-spreadAmount, spreadAmount);

            rb.velocity = new Vector3(1f, ballThurstDirection, 0f )* ballStartThrust * ballDirection;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z) * (speedMultiplier + 1);
        } 
        else if(other.gameObject.tag == "Goal")
        {
            int playerNumberOfGoal = other.gameObject.GetComponent<Goal>().GetPlayerNumber();
            if(playerNumberOfGoal == 1)
            {
                ballDirection = -1;
            }
            else
            {
                ballDirection = 1;
            }
            scoreHandler.IncreaseScore(playerNumberOfGoal);
        }   
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z) ;
        }
        Debug.Log(rb.velocity);
    }

    void Update()
    {
        if( Keyboard.current.leftArrowKey.wasPressedThisFrame )
            scoreHandler.IncreaseScore(1);

        if(rb.velocity.x * rb.velocity.x <= 25 || rb.velocity.x *rb.velocity.x >= 400)
        {
            float xVelocitySign = Mathf.Sign(rb.velocity.x);
            float newXVelocity = Mathf.Clamp(rb.velocity.x * xVelocitySign, 5, 20);
            rb.velocity = new Vector3(newXVelocity * xVelocitySign, rb.velocity.y, rb.velocity.z);
        }
    }
}
