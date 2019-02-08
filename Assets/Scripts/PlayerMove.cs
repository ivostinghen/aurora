using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float forwardSpeed;
    private Vector3 direction;
    private Transform cam;
    private bool flipping;
    public void SetSpeed(float newSpeed) => this.forwardSpeed = newSpeed;
    public void ResetSpeed() => this.forwardSpeed = speed;
    public float GetSpeed() => this.forwardSpeed;


    private void Awake()
    {
        cam = Camera.main.transform;
        SetDirection();
        forwardSpeed = 0;
    }

    public void SetDirection()
    {
        direction = cam.forward;
        //direction.y = 0;
        if (direction.sqrMagnitude != 0.0f) direction.Normalize();
    }

    /// Forward Move
    void ForwardMove()
    {
        transform.position += transform.forward * Time.deltaTime * forwardSpeed;
    }

    public void StopMove()
    {
        forwardSpeed = 0;
    }

    public void Move()
    {
        ResetSpeed();
        SetDirection();
    }

    public IEnumerator Flip()
    {
        flipping = true;
        Vector3 rot = transform.eulerAngles;
        for (int i=0;i<360;i+=5)
        {
            rot = transform.eulerAngles;
            rot.z = i;
            transform.eulerAngles = rot;
            yield return new WaitForSeconds(0.02F);
        }
        flipping = false;
    }

    public void UpdateRotation()
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * 2F
        );
    }

    public void LateUpdate()
    {
        if(!flipping)UpdateRotation();
        ForwardMove();
    }

}
