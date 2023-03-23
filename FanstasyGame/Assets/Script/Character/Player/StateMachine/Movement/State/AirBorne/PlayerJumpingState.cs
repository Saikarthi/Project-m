using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerAirBorneState
{

    private bool ShouldKeepRotating;
    private PlayerJumpData Jumpdata;

    public PlayerJumpingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        Jumpdata = AirBroneData.JumpData;
        
    }
    #region Istate
    public override void Entry()
    {
        base.Entry();
        stateMachine.Reusabledata.MovementSpeedModifier= 0;
        ShouldKeepRotating = stateMachine.Reusabledata.MovementInput != Vector2.zero;
        //video No 15  38:03
        Jump();

        StartAndStopAnimation(stateMachine.player.AnimationData.JumpParameterHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        StartAndStopAnimation(stateMachine.player.AnimationData.JumpParameterHash, false);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (ShouldKeepRotating)
        {
            RotateTowardsTragerPostion(); 
        }

        if(IsMovingUp())
        {
            DecelerateVertically();
        }
    }

    protected bool IsMovingUp(float minimum =0.1f)
    {
        return GetPlayerVerticalVelocity().y> minimum;
    }


    #endregion

    #region Main methods

    private void Jump()
    {
        Vector3 jumpForce = stateMachine.Reusabledata.CurrentJumpForce;
        Debug.Log("current Force: " + jumpForce);

        Vector3 jumpDirection = stateMachine.player.transform.forward;

        if(ShouldKeepRotating)
        {
            jumpDirection = GetTargetRoationDirection(stateMachine.Reusabledata.CurrentTargetRotation.y);
        }

        jumpForce.x *= jumpDirection.x;
        jumpForce.z *= jumpDirection.z;


        ResetVelocity();   
        
        stateMachine.player.rb.AddForce(jumpForce, ForceMode.VelocityChange);

    }
    #endregion

}
