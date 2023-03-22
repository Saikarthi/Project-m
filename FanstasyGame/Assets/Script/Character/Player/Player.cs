using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField]public PlayerSO Data { get; private set; }

    [field: Header("Collision")]
    [field: SerializeField]public CapsulecColliderUtility ColliderUtility { get; private set; }
    [field: SerializeField]public PlayerLayerData LayerData { get; private set; }
    [field: SerializeField]public PlayeraAnimationData AnimationData { get; private set; }

    public Rigidbody rb { get; private set; }
    public Animator animator { get; private set; }

    public Transform mainCameraTransform { get; private set; }  

    public PlayerInput input { get; private set; }

    public PlayerMovementStateMachine movementStateMachine;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();

        AnimationData.Initialize();

        mainCameraTransform = Camera.main.transform;

        movementStateMachine = new PlayerMovementStateMachine(this);

        animator = GetComponentInChildren<Animator>();

    }

    public void OnValidate()
    {
        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();
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

    private void OnTriggerEnter(Collider other)
    {
        movementStateMachine.OnTriggerEnter(other);
    }
}
