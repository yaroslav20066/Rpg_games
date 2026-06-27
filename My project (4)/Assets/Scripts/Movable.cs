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

    public void rotate(Vector2 direction)
    {
        body.MoveRotation(transform.rotation * Quaternion.Euler(0, direction.x * sensivity * Time.fixedDeltaTime, 0));
        if (Camera.localEulerAngles.x > 80.1f && Camera.localEulerAngles.x < 180)
        {
            Camera.localEulerAngles = new Vector3(80, Camera.localRotation.y, Camera.localRotation.z);
        }
        else
        {
            if (Camera.localEulerAngles.x < 279.9f && Camera.localEulerAngles.x > 180)
            {
                Camera.localEulerAngles = new Vector3(280, Camera.localRotation.y, Camera.localRotation.z);
            }
            else
            {
                Camera.Rotate(new Vector3(-direction.y * sensivity * Time.fixedDeltaTime, 0, 0));
            }
        }
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
}
