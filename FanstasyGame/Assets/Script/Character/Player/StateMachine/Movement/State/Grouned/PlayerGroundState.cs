using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerMovementState
{
    private SlopeData slopeData;

    public PlayerGroundState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        slopeData = stateMachine.player.ColliderUtility.SlopeData;
    }
    #region Main Methode

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        FloatCapsule();
    }

    private void FloatCapsule()
    {
        Vector3 capsuleColliderCentreInWorldSpace = stateMachine.player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;
        Ray downwardRayFromCapsuleCentre = new Ray(capsuleColliderCentreInWorldSpace, Vector3.down);
        if(Physics.Raycast(downwardRayFromCapsuleCentre,out RaycastHit hit, slopeData.floatRayDistance,stateMachine.player.LayerData.groundLayer))
        {
            float distanceaToFloatingPoint = stateMachine.player.ColliderUtility.CapsuleColliderData.ColliderCentreInLocalSpace.y * stateMachine.player.transform.localScale.y - hit.distance;
            if (distanceaToFloatingPoint == 0.0f)
                return;
            Debug.Log("b");

            float amountTOlift = distanceaToFloatingPoint * slopeData.stepReachForce - GetPlayerVerticalVelocity().y;
            Vector3 liftForce = new Vector3(0f, amountTOlift);
            stateMachine.player.rb.AddForce(liftForce, ForceMode.VelocityChange);
        }

    }

    protected override void AddInputActionCallback()
    {
        base.AddInputActionCallback();
        stateMachine.player.input.playerActions.Movement.canceled += OnMovenmentCanceled;
        stateMachine.player.input.playerActions.Jump.started += OnJumpStarted;
    }

    private void OnJumpStarted(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(stateMachine.jumpingState);
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
        stateMachine.ChangeState(stateMachine.walkingState);
    }
}
