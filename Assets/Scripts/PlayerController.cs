using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] private GameObject player = null;
    [SerializeField] private Transform midpoint = null;
    [SerializeField] private bool isPlayerOne = false;
    [SerializeField] private float moveSpeed = .2f;
    [SerializeField] private Vector2 boundaries = new Vector2();

    private Controls controls;
    
    private float playerInput = 0;

    private void Start() 
    {
        controls = new Controls();

        if(isPlayerOne)
        {
            controls.Player1.Move.performed += SetPlayerInput;
            controls.Player1.Move.canceled += SetPlayerInput;
        }
        else
        {
            controls.Player2.Move.performed += SetPlayerInput;
            controls.Player2.Move.canceled += SetPlayerInput;
        }

        controls.Enable();
    }

    private void Update() 
    {
        float newPlayerYPosition = Mathf.Clamp(
                                player.transform.position.y + new Vector3(0f, playerInput * moveSpeed * Time.deltaTime, 0f).y,
                                boundaries.x, boundaries.y);

        player.transform.position = new Vector3(player.transform.position.x, newPlayerYPosition, player.transform.position.z);
    }

    private void SetPlayerInput(InputAction.CallbackContext cxt)
    {
        playerInput = cxt.ReadValue<float>();
    }
    //DELEtE
    public float CalculateDistanceToMidpoint(Vector3 position)
    {
        return midpoint.position.sqrMagnitude - position.sqrMagnitude;
       
    }
}
