using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyStates currentState {  get; private set; }

    public void Initialize(EnemyStates startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(EnemyStates newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
