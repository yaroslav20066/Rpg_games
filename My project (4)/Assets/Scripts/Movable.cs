using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Movable : MonoBehaviour
{
    public int speed;
    public int shiftedSpeed;
    public int jumpHeight;
    public int sensivity;
    public Transform Camera;
    public Vector3 sizeMultiplier;
    public float crouchMultiplier;
    Rigidbody body;
    int actualSpeed;

    public void Start()
    {   
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
        if (sizeMultiplier == Vector3.zero)
        {
            sizeMultiplier = transform.localScale;
        }
    }

    public void move(Vector2 direction)
    {
        body.MovePosition(transform.position + ((transform.forward * direction.y) + (transform.right * direction.x)) * actualSpeed * Time.fixedDeltaTime);
    }

    private float verticalRotation = 0f;

    public void rotate(Vector2 direction)
    {
        body.MoveRotation(transform.rotation * Quaternion.Euler(0, direction.x * sensivity * Time.deltaTime, 0));

        verticalRotation -= direction.y * sensivity * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        Camera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    public void jump()
    {
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), transform.localScale.y))
        {
            body.AddForce(new Vector3(0, jumpHeight, 0));
        }
    }

    public void sprint(bool sprint)
    {
        actualSpeed = sprint ? shiftedSpeed : speed;
    }

    public void crouch(bool crouch)
    {
        transform.localScale = new Vector3(sizeMultiplier.x, crouch ? sizeMultiplier.y * crouchMultiplier : sizeMultiplier.y, sizeMultiplier.z);
    }

    public void updateSpeed()
    {
        speed += 1;
    }
}
