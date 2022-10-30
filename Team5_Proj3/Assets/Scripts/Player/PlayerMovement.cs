using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private PlayerInput playerInput;
    private InputAction upAction;
    private InputAction downAction;

    [SerializeField] float moveSpeed;
    [SerializeField] Transform endTargetMiddle;
    [SerializeField] Transform endTargetTop;
    [SerializeField] Transform endTargetBottom;
    private Transform currentEndTarget;
  

    
   

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        upAction = playerInput.actions["Up"];
        downAction = playerInput.actions["Down"];
        currentEndTarget = endTargetMiddle;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        this.transform.position = Vector3.MoveTowards(transform.position, currentEndTarget.position, Time.deltaTime * moveSpeed);
    }

    private void Movement()
    {
        if(upAction.WasPressedThisFrame() && upAction.IsPressed())
        {
            if(transform.position.z <= 2f)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            }
           
            
        }
        else if(downAction.WasPerformedThisFrame() && downAction.IsPressed())
        {
            if (transform.position.z >= -2)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            }
               
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TopZone"))
        {
            currentEndTarget = endTargetTop;
        }
        else if (other.CompareTag("MiddleZone"))
        {
            currentEndTarget = endTargetMiddle;
        }
        else if(other.CompareTag("BottomZone"))
        {
            currentEndTarget = endTargetBottom;
        }
    }
}
