using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public EntityState currentstate { get; private set; }
    public bool canChangeState;

    public void Initialize(EntityState startstate)
    {

        canChangeState = true;
        currentstate = startstate;
        currentstate.Enter();
    }

    public void ChangeState(EntityState newstate)
    {
        if (canChangeState == false)
            return;


        currentstate.Exit();
        currentstate = newstate;
        currentstate.Enter();
    }

    public void UpdateActiveState()
    {
        currentstate.Update();
    }

    public void SwitchOffStateMachine() => canChangeState =false;
}
