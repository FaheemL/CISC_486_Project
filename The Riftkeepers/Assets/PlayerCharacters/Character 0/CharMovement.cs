using UnityEngine;
using UnityEngine.InputSystem;

public class CharMovement : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction pMoveAct;
    private InputAction pLookAct;

    private Vector2 pVelocity;
    

    private Animator pAnimator;
    private Rigidbody pRigBod;

    public float pSpeed = 5;
    public float pRotSpd = 5;
    public float pJmpSpd = 5;


    private void OnEnable(){

        InputActions.FindActionMap("Player").Enable();


    }

    private void OnDisable()
    {

        InputActions.FindActionMap("Player").Disable();


    }

    private void Awake(){

        pMoveAct = InputSystem.actions.FindAction("Move");
        

        pAnimator = GetComponent<Animator>();
        pRigBod = GetComponent<Rigidbody>();

    }

    private void Update(){
        
        pVelocity = pMoveAct.ReadValue<Vector2>();
       




    }

    private void FixedUpdate(){
        Walking();
        Rotating();
    }


    private void Walking(){
        pAnimator.SetFloat("speedY", pVelocity.y);
        pAnimator.SetFloat("speedX", pVelocity.x);
        pRigBod.MovePosition(pRigBod.position + transform.forward * pVelocity.y * pSpeed * Time.deltaTime);
        
      
    } 

    private void Rotating(){

    

            float pRot = pVelocity.x * pRotSpd * Time.deltaTime;
            Quaternion deltaRot = Quaternion.Euler(0, pRot, 0);
            pRigBod.MoveRotation(pRigBod.rotation * deltaRot);
        
        

    }
}
