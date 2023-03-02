using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField]public PlayerSO Data { get; private set; }

    public Rigidbody rb { get; private set; }

    public Transform mainCameraTransform { get; private set; }  

    public PlayerInput input { get; private set; }

    public PlayerMovementStateMachine movementStateMachine;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform ;

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
