using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class in_control : MonoBehaviour
{
    i_movemnet2d movementController;
    public PlayerInput controls;

    private void Awake()
    {
        controls.onActionTriggered +=  Move;
        InputMaster inp = new InputMaster();
      ///  inp.Player.Movement.performed = 
    }
    
    private void Start()
    {
        movementController = GetComponent<i_movemnet2d>();    
    }

    public void Move(InputAction.CallbackContext context) {

    }
    
    void Update()
    {
        if (movementController != null)
        {
            float movX = 0;
            float movY = 0;

            if (Input.GetKey(KeyCode.A)) movX = -1f;
            if (Input.GetKey(KeyCode.D)) movX = 1f;
            if (Input.GetKey(KeyCode.W)) movY = +1f;
            if (Input.GetKey(KeyCode.S)) movY = -1f;

            movementController.MoveVelocity(new Vector2(movX, movY));
        }
    }
}
