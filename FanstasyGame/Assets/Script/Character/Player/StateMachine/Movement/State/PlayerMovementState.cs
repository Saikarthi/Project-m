using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine stateMachine;

    protected Vector2 movementInput;

    protected float baseSpeed = 5f;
    protected float speedModifer =2;
    public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;
    }

    #region Istate
    public virtual void Entry()
    {
        Debug.Log("State:" + GetType().Name);
    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }


    public virtual void PhysicsUpdate()
    {
        Move();
    }


    public virtual void Update()
    {

    }
    #endregion

    #region Main Function


    private void Move()
    {
        if (movementInput == Vector2.zero || speedModifer == 0)
            return;
        Vector3 movementDirection = GetMovementDirection();
        float movementSpeed = GetMovementSpeed();
        Vector3 currentVelocity = GetCurrentVelocity();
        stateMachine.player.rb.AddForce(movementDirection * movementSpeed - currentVelocity,ForceMode.VelocityChange);
    }

    private void ReadMovementInput()
    {
        movementInput = stateMachine.player.input.playerActions.Movement.ReadValue<Vector2>();
    }

    #endregion


    #region Reusable Function

    protected Vector3 GetMovementDirection()
    {
        return new Vector3(movementInput.x, 0, movementInput.y);
    }
    protected float GetMovementSpeed()
    {
        return baseSpeed * speedModifer;
    }
    protected Vector3 GetCurrentVelocity()
    {
        Vector3 temp = stateMachine.player.rb.velocity;
        temp.y = 0;
        return temp;
    }

    #endregion
}
