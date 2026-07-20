using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PlayerInputListener : MonoBehaviour
{
    [HideInInspector] public bool movementIsEnabled;
    public HUD mainHUD;
    public TextMeshProUGUI typeWeapon;
    public ItemInventory itemInventory;
    public Canvas UI;
    public GameOverScript gameOverScript;
    public EndingScript endingScript;
    //public Counter debugcounter;
    InputSystem_Actions controls;
    Movable movement;
    IteractionScript iteractionScript;
    SwordScript sword;
    BowScript bow;
    PlayerStatsScript stats;
    bool inventoryOpenedPreviousCheck = false, itemInventoryOpenedPreviousCheck = false;
    bool skillMenuOpen = false, itemMenuOpen = false;
    bool changed_weapon = false;
    public bool gameEnded = false;

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

    public void die() {
        gameEnded = true;
        movementIsEnabled = false;
        gameOverScript.showGameOverScreen();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ending(int endingID) {
        gameEnded = true;
        movementIsEnabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        endingScript.showEnding(endingID, stats.isRogue);
    }

    private void Update()
    {
            if (controls.FindAction("ScrollWheel").ReadValue<Vector2>().normalized.y != 0) {
                if (controls.FindAction("ScrollWheel").ReadValue<Vector2>().normalized.y > 0) {
                     mainHUD.hotbarSelectedSlot -=1; 
                }
                else { mainHUD.hotbarSelectedSlot +=1; }

            if (mainHUD.hotbarSelectedSlot > 4) mainHUD.hotbarSelectedSlot = 0;
            if (mainHUD.hotbarSelectedSlot < 0) mainHUD.hotbarSelectedSlot = 4;
        }
    }
    private void FixedUpdate()
    {  
        if (controls.FindAction("Exit").IsPressed())
        {
            Application.Quit();
        }

        if (gameEnded) {
            return;
        }

        if (controls.FindAction("TEST").IsPressed())
        {
            stats.experience += 50;
        }
        if (controls.FindAction("OpenInventory").IsPressed() && !itemMenuOpen)
        {
            if (!inventoryOpenedPreviousCheck)
            {
                inventoryOpenedPreviousCheck = true;
                movementIsEnabled = !movementIsEnabled;
                UI.gameObject.SetActive(!movementIsEnabled);
                skillMenuOpen = !movementIsEnabled;
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

        if (controls.FindAction("Inventary").IsPressed() && !skillMenuOpen)
        {
            if (!itemInventoryOpenedPreviousCheck)
            {
                itemInventoryOpenedPreviousCheck = true;
                movementIsEnabled = !movementIsEnabled;
                if (movementIsEnabled) {itemInventory.Hide();}
                else {itemInventory.Show();}
                itemMenuOpen = !movementIsEnabled;
                mainHUD.inventoryOpen = itemMenuOpen;
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
            itemInventoryOpenedPreviousCheck = false;
        }

        if (controls.FindAction("MiddleClick").IsPressed() && !skillMenuOpen) {
            itemInventory.consume(mainHUD.hotbarSelectedSlot);
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
                
                typeWeapon.text = "Type: Sword";
            }
            else if (changed_weapon)
            {
                bow.Attack(controls.FindAction("Attack").IsPressed());

                typeWeapon.text = "Type: Bow";
            }
            movement.sprint(controls.FindAction("Sprint").IsPressed());
            movement.crouch(controls.FindAction("Crouch").IsPressed());
            movement.move(controls.FindAction("Move").ReadValue<Vector2>());
            movement.rotate(controls.FindAction("Look").ReadValue<Vector2>());
            movement.zoom(controls.FindAction("Zoom").IsPressed());
            iteractionScript.interact(controls.FindAction("Interact").WasPressedThisFrame());
            
            if (controls.FindAction("Jump").IsPressed()) {
            movement.jump();
            }
        }
        
    }
}
