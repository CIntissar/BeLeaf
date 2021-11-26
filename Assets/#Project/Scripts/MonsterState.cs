using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState
{
    //STATE MANAGER
    MonsterBaseState currentState;
    MonsterKO koState;
    MonsterHurt hurtState;
    MonsterIdle idleState;
    MonsterHappy happyState;
    MonsterWalk walkingState;


    void Start() 
    {
        currentState = idleState;
        currentState.EnterState(this); //this = monster en question        
    }

    void Update() 
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(MonsterBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

}
