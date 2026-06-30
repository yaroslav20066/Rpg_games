using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputListener : MonoBehaviour
{
    public bool movementIsEnabled;
    public Canvas UI;
    InputSystem_Actions controls;
    Movable movement;
    IteractionScript iteractionScript;
    SwordScript sword;
    bool inventoryOpenedPreviousCheck = false;

    void Start()
    {
        movement = GetComponent<Movable>();
        iteractionScript = GetComponent<IteractionScript>();
        sword = GetComponent<SwordScript>();
        controls = new InputSystem_Actions();
        controls.Enable();
    }

    private void FixedUpdate()
    {
        if (controls.FindAction("OpenInventory").IsPressed())
        {
            if (!inventoryOpenedPreviousCheck)
            {
                inventoryOpenedPreviousCheck = true;
                movementIsEnabled = !movementIsEnabled;
                UI.gameObject.SetActive(!movementIsEnabled);
            }
        } else
        {
            inventoryOpenedPreviousCheck = false;
        }
        if (movementIsEnabled)
        {
            movement.sprint(controls.FindAction("Sprint").IsPressed());
            movement.crouch(controls.FindAction("Crouch").IsPressed());
            movement.move(controls.FindAction("Move").ReadValue<Vector2>());
            movement.rotate(controls.FindAction("Look").ReadValue<Vector2>());
            iteractionScript.interact(controls.FindAction("Interact").WasPressedThisFrame());
        }
        sword.Attack(controls.FindAction("Attack").IsPressed());
        if (controls.FindAction("Jump").IsPressed())
        {
            movement.jump();
        }
    }
}
