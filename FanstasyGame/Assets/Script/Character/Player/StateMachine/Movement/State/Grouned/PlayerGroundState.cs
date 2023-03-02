using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerMovementState
{
    public PlayerGroundState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    #region reuse

    protected override void AddInputActionCallback()
    {
        base.AddInputActionCallback();
        stateMachine.player.input.playerActions.Movement.canceled += OnMovenmentCanceled;
    }
    protected override void RemoveInputActionCallBack()
    {
        base.RemoveInputActionCallBack();
        stateMachine.player.input.playerActions.Movement.canceled -= OnMovenmentCanceled;

    } 
    #endregion
    protected virtual void OnMovenmentCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(stateMachine.idelingState);
    }
    protected virtual void OnMove()
    {
        if (stateMachine.Reusabledata.ShouldSprint)
        {
            stateMachine.ChangeState(stateMachine.sprintingState);
            return;
        }
        Debug.Log("test");
        stateMachine.ChangeState(stateMachine.walkingState);


    }
}
