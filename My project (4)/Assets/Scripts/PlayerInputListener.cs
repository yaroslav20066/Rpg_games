using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputListener : MonoBehaviour
{
    InputSystem_Actions controls;
    Movable movement;

    void Start()
    {
        movement = GetComponent<Movable>();
        controls = new InputSystem_Actions();
        controls.Enable();
    }

    private void FixedUpdate()
    {
        movement.sprint(controls.FindAction("Sprint").IsPressed());
        movement.crouch(controls.FindAction("Crouch").IsPressed());
        movement.move(controls.FindAction("Move").ReadValue<Vector2>());
        movement.rotate(controls.FindAction("Look").ReadValue<Vector2>());
        if (controls.FindAction("Jump").IsPressed())
        {
            movement.jump();
        }
    }
}
