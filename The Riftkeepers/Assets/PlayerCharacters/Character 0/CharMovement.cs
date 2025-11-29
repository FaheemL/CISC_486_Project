using UnityEngine;
using UnityEngine.InputSystem;
using PurrNet;

public class CharMovement : NetworkBehaviour
{
    public InputActionAsset InputActions;

    private InputAction pMoveAct;

    private Vector2 pVelocity;

    private Animator pAnimator;
    private Rigidbody pRigBod;

    public float pSpeed = 5;
    public float pRotSpd = 5;
    public float pJmpSpd = 5;

    protected override void OnSpawned()
    {
        base.OnSpawned();

        if (!isOwner)
        {
            enabled = false;
            return;
        }

        var map = InputActions.FindActionMap("Player");
        map.Enable();
        pMoveAct = map.FindAction("Move");

        pAnimator = GetComponent<Animator>();
        pRigBod = GetComponent<Rigidbody>();
    }

    protected override void OnDespawned()
    {
        base.OnDespawned();

        if (!isOwner) return;

        InputActions.FindActionMap("Player").Disable();
    }

    private void Update()
    {
        if (!isOwner) return;

        pVelocity = pMoveAct.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!isOwner) return;

        Walking();
        Rotating();
    }

    private void Walking()
    {
        pAnimator.SetFloat("speedY", pVelocity.y);
        pAnimator.SetFloat("speedX", pVelocity.x);

        pRigBod.MovePosition(
            pRigBod.position +
            transform.forward * pVelocity.y * pSpeed * Time.deltaTime
        );
    }

    private void Rotating()
    {
        float pRot = pVelocity.x * pRotSpd * Time.deltaTime;
        Quaternion deltaRot = Quaternion.Euler(0, pRot, 0);
        pRigBod.MoveRotation(pRigBod.rotation * deltaRot);
    }
}
