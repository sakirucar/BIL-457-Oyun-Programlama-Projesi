using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected VariableJoystick joystick;
    [SerializeField] protected Animator animCtrl;
    [SerializeField] protected float Speed = 5f;
    [SerializeField] protected float RotationSpeed = 10f;
    [SerializeField] private Vector2 xLimits;
    [SerializeField] private Vector2 zLimits;


    void Update()
    {
        MovementUpdate();
    }

    public virtual void MovementUpdate()
    {
        if (joystick == null)
            return;

        Vector2 direction = joystick.Direction;

        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        movementVector = movementVector * Time.deltaTime * Speed;

        transform.position += movementVector;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xLimits.x, xLimits.y),
            transform.position.y,
            Mathf.Clamp(transform.position.z, zLimits.x, zLimits.y));
        if (movementVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
        }

        bool isWalking = direction.magnitude > 0;
        if (animCtrl == null)
            return;
        animCtrl.SetBool("IsWalking", isWalking);
        animCtrl.SetFloat("SpeedValue", direction.magnitude);
    }
}
