using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    public Rigidbody rb { get; private set; }

    public PlayerInput input { get; private set; }

    public PlayerMovementStateMachine movementStateMachine;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        movementStateMachine = new PlayerMovementStateMachine(this);
    }
    void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.idelingState);
    }
    void Update()
    {
        movementStateMachine.HandleInput();

        movementStateMachine.Update();
    }
    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();

    }
}
