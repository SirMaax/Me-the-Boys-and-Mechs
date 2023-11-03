using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private MechMovement _mech;
    
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;
    
    [Header("Refs")] 
    [SerializeField]private MovementController _movement;
    [SerializeField]private MovementController _movement1;
    [SerializeField]private MovementController _movement2;
    [SerializeField]private MovementController _movement3;
    public InputAction inputAction;
    [SerializeField]private Player _player;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private Player player3;
    //How does a function to take input look like?
    public void OnNAMEofPart(InputValue value)
    {
        OtherFunction(value.Get<Vector3>());
        
    }
    
    public void OtherFunction(Vector3 vec)
    {
        //In combination with this function you specifiy why input is feed to the next function
    }
    //--------------------------------------------//


    

    
    private void Start()
    {
        // _movement = GetComponent<MovementController>();
        // _player = GetComponent<Player>();
    }
    
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnUse(InputValue value)
    {
        // _player.Use();
    }
    public void OnUse1(InputValue value)
    {
        player1.Use();
    }
    public void OnUse2(InputValue value)
    {
        player2.Use();
    }
    public void OnUse3(InputValue value)
    {
        player3.Use();
    }
    public void OnInteract(InputValue value)
    {
        // _player.Interact();
    }    
    public void OnMove1(InputValue value)
    {
        MoveInput1(value.Get<Vector2>());
    }
    public void OnInteract1(InputValue value)
    {
        player1.Interact();
    }  
    public void OnMove2(InputValue value)
    {
        MoveInput2(value.Get<Vector2>());
    }
    public void OnInteract2(InputValue value)
    {
        player2.Interact();
    }  
    public void OnMove3(InputValue value)
    {
        MoveInput3(value.Get<Vector2>());
    }
    public void OnInteract3(InputValue value)
    {
        player3.Interact();
    }  
    // public void OnJumpRelease(InputValue value)
    // {
    //     _movement.StopJump();
    // }

    public void MoveInput(Vector2 newMoveDirection)
    {
        if (newMoveDirection[0] == 0 && newMoveDirection[1] == 0)
        {
            // sprintToggle = false;
            // sprint = false;
        }
        
        // if (newMoveDirection.y > 0) _movement.jumpButtonPressed = true;
        // else _movement.jumpButtonPressed = false;
        
        //Remove Y component
        // newMoveDirection.y = 0;
        // _movement.move = newMoveDirection;
        _mech.move = newMoveDirection;
    }
    public void MoveInput1(Vector2 newMoveDirection)
    {
        if (newMoveDirection[0] == 0 && newMoveDirection[1] == 0)
        {
            // sprintToggle = false;
            // sprint = false;
        }
        
        if (newMoveDirection.y > 0) _movement1.jumpButtonPressed = true;
        else _movement1.jumpButtonPressed = false;
        
        //Remove Y component
        newMoveDirection.y = 0;
        _movement1.move = newMoveDirection;
    }
    public void MoveInput2(Vector2 newMoveDirection)
    {
        if (newMoveDirection[0] == 0 && newMoveDirection[1] == 0)
        {
            // sprintToggle = false;
            // sprint = false;
        }
        
        if (newMoveDirection.y > 0) _movement2.jumpButtonPressed = true;
        else _movement2.jumpButtonPressed = false;
        
        //Remove Y component
        newMoveDirection.y = 0;
        _movement2.move = newMoveDirection;
    }
    public void MoveInput3(Vector2 newMoveDirection)
    {
        if (newMoveDirection[0] == 0 && newMoveDirection[1] == 0)
        {
            // sprintToggle = false;
            // sprint = false;
        }
        
        if (newMoveDirection.y > 0) _movement3.jumpButtonPressed = true;
        else _movement3.jumpButtonPressed = false;
        
        //Remove Y component
        newMoveDirection.y = 0;
        _movement3.move = newMoveDirection;
    }

    public void OnEscape(InputValue value)
    {
        GameMaster.ShowGui();
    }

}