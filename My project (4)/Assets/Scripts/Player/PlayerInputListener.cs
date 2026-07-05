using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputListener : MonoBehaviour
{
    [HideInInspector] public bool movementIsEnabled;
    public Canvas UI;
    InputSystem_Actions controls;
    Movable movement;
    IteractionScript iteractionScript;
    SwordScript sword;
    BowScript bow;
    PlayerStatsScript stats;
    bool inventoryOpenedPreviousCheck = false;
    bool changed_weapon = true;

    void Start()
    {
        movement = GetComponent<Movable>();
        iteractionScript = GetComponent<IteractionScript>();
        sword = GetComponent<SwordScript>();
        bow = GetComponent<BowScript>();
        controls = new InputSystem_Actions();
        controls.Enable();
        stats = GetComponent<PlayerStatsScript>();
    }

    private void FixedUpdate()
    {
        if (controls.FindAction("Exit").IsPressed())
        {
            Application.Quit();
        }
        if (controls.FindAction("TEST").IsPressed())
        {
            stats.experience += 50;
        }
        if (controls.FindAction("OpenInventory").IsPressed())
        {
            if (!inventoryOpenedPreviousCheck)
            {
                inventoryOpenedPreviousCheck = true;
                movementIsEnabled = !movementIsEnabled;
                UI.gameObject.SetActive(!movementIsEnabled);
                Cursor.visible = !movementIsEnabled;
                if (!movementIsEnabled == true)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else 
                {
                    Cursor.lockState = CursorLockMode.Locked;    
                }
            }
        } 
        else
        {
            inventoryOpenedPreviousCheck = false;
        }
        if (movementIsEnabled)
        {
            if (controls.FindAction("Sword").IsPressed())
            {
                changed_weapon = false;
            }
            else if (controls.FindAction("Bow").IsPressed())
            {
                changed_weapon = true;
            }
            if (!changed_weapon)
            {
                sword.Attack(controls.FindAction("Attack").IsPressed());
                sword.Heavy_Attack(controls.FindAction("Heavy_attack").IsPressed());
            }
            else if (changed_weapon)
            {
                bow.Attack(controls.FindAction("Attack").IsPressed());
            }
            movement.sprint(controls.FindAction("Sprint").IsPressed());
            movement.crouch(controls.FindAction("Crouch").IsPressed());
            movement.move(controls.FindAction("Move").ReadValue<Vector2>());
            movement.rotate(controls.FindAction("Look").ReadValue<Vector2>());
            movement.zoom(controls.FindAction("Zoom").IsPressed());
            iteractionScript.interact(controls.FindAction("Interact").WasPressedThisFrame());
        }
        if (controls.FindAction("Jump").IsPressed())
        {
            movement.jump();
        }
    }
}
