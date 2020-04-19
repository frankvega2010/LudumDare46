using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonobehaviourSingleton<PlayerState>
{
    public bool hasPlayerWon;

    private void Start()
    {
        hasPlayerWon = false;
    }
}
