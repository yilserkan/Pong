using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int playerNumber = 1;

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
}
