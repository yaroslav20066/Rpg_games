using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputListener : MonoBehaviour
{
    InputSystem_Actions controls;
    Movable movement;
    IteractionScript iteractionScript;

    void Start()
    {
        movement = GetComponent<Movable>();
        iteractionScript = GetComponent<IteractionScript>();
        controls = new InputSystem_Actions();
        controls.Enable();
    }

    private void FixedUpdate()
    {
        movement.sprint(controls.FindAction("Sprint").IsPressed());
        movement.crouch(controls.FindAction("Crouch").IsPressed());
        movement.move(controls.FindAction("Move").ReadValue<Vector2>());
        movement.rotate(controls.FindAction("Look").ReadValue<Vector2>());
        iteractionScript.interact(controls.FindAction("Interact").WasPressedThisFrame());
        if (controls.FindAction("Jump").IsPressed())
        {
            movement.jump();
        }
    }
}
