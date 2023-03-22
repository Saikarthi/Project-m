using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStopIngState : PlayerGroundState
{
    public PlayerStopIngState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    #region Istate
    public override void Entry()
    {
        base.Entry();
        stateMachine.Reusabledata.MovementSpeedModifier = 0;
        StartAndStopAnimation(stateMachine.player.AnimationData.StopingParameterHash, true);

    }
    public override void Exit()
    {
        base.Exit();
        StartAndStopAnimation(stateMachine.player.AnimationData.StopingParameterHash, false);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(!IsMovingHorizontally())
        {
            return;
        }
        DecelerateHorizontally(); 
    }
    #endregion

    #region reuble
    protected  void DecelerateHorizontally()
    {
        Vector3 PlayerHorizontal = GetPlayerHorizontalVelocity();
        stateMachine.player.rb.AddForce(-PlayerHorizontal* stateMachine.Reusabledata.MovementDecelrationForce, ForceMode.Acceleration);
    }

    protected bool IsMovingHorizontally(float minimumMagnitude = 0.1f)
    {

        Vector3 PlayerHorizontal = GetPlayerHorizontalVelocity();
        Vector2 PlayerHorizontalV2 = new Vector2(PlayerHorizontal.x, PlayerHorizontal.z);

        return PlayerHorizontal.magnitude>minimumMagnitude;
    }

    public override void OnAnimationTrantionEvent()
    {
        stateMachine.ChangeState(stateMachine.idelingState);
    }


    protected override void OnMovenmentCanceled(InputAction.CallbackContext obj)
    {

    }

    protected override void AddInputActionCallback()
    {
        base.AddInputActionCallback();

        stateMachine.player.input.playerActions.Movement.started += OnMovementStarted;
    }

    private void OnMovementStarted(InputAction.CallbackContext obj)
    {
        OnMove();
    }

    protected override void RemoveInputActionCallBack()
    {
        base.RemoveInputActionCallBack();
        stateMachine.player.input.playerActions.Movement.started -= OnMovementStarted;
    }
    #endregion
}
