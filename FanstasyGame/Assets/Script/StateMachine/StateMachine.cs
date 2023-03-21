using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine 
{
    public IState currentState;

    public void ChangeState(IState state)
    {
        currentState?.Exit ();

        currentState = state;

        currentState.Entry();
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }
    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
    public void OnTriggerEnter(Collider collider)
    {
        currentState?.OnTriggerEnter(collider);
    }
    public void OnAnimationEnterEvent()
    {
        currentState?.OnAnimationEntryEvent();
    }
    public void OnAnimationExitEvent()
    {
        currentState?.OnAnimationExitEvent();
    }
    public void OnAnimationTransionEvent()
    {
        currentState?.OnAnimationTrantionEvent();
    }
}
