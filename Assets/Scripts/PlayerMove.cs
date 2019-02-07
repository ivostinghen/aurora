using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float besierHeight = 5;
    private float besierTime;
    private bool moving;
    private Vector3 A, B, C;
    [SerializeField]
    private float speed;
    private float forwardSpeed;
    private Coroutine[] cor = new Coroutine[2];
    private Vector3 direction;
    
    public void SetSpeed(float newSpeed) => this.forwardSpeed = newSpeed;
    public float GetSpeed() => this.forwardSpeed;


    public void SetDirection()
    {
        //this.direction = Camera.main.transform.forward;
        direction = Camera.main.transform.forward;
        direction.y = 0;
        if (direction.sqrMagnitude != 0.0f)
        {
            direction.Normalize();

        }
    }

    private void Awake()
    {
        SetDirection();
        forwardSpeed = 0;
    }

    /// Besier Curved Move
    private IEnumerator CalculateBesier(float speed)
    {
        while(besierTime <= 1)
        {
            besierTime += Time.deltaTime  * speed;
            float t = besierTime;
            Vector3 besierPos = (A - (2 * t * A) + (t * t * A)) + ((2 * t * B) - (2 * t * t * B)) + (t * t * C);
            transform.position = besierPos;
            yield return new WaitForSeconds(.02F);
        }
        besierTime = 0;
        cor[1] = null;
    }

    public void SetBesierPos(float height, float distance)
    {
        
        besierTime = 0;
        Vector3 besierStartPoint = this.transform.position;
        A = besierStartPoint;
        C = besierStartPoint + direction * distance;
        B = (A + C) / 2;
        B.y += height;
        
    }

    ///Moving Sequence
    public IEnumerator MoveSequence()
    {
        SetBesierPos(besierHeight/2, 10);
        cor[1] = StartCoroutine(CalculateBesier(4F));
        while (cor[1]!=null)
        {
            yield return new WaitForSeconds(.02F);
        }

        SetBesierPos(-besierHeight/4 , 10);
        cor[1] = StartCoroutine(CalculateBesier(4F));
        while (cor[1] != null)
        {
            yield return new WaitForSeconds(.02F);
        }

        ForwardMove();
        SetSpeed(speed);
        cor[0] = null;
    }

    /// Forward Move
    void ForwardMove()
    {
        transform.position += direction * Time.deltaTime * forwardSpeed;
    }

    public void StopMove()
    {
        forwardSpeed = 0;
        foreach (Coroutine c in cor)
        {
            if (c != null) StopCoroutine(c);
        }
    }

    public void Move()
    {
        SetDirection();

        if (GetSpeed() > 0) return;

        if (cor[0] == null) cor[0] = StartCoroutine(MoveSequence());
       
    }

    public void AdjustRotation()
    {
        //Vector3 rot = this.transform.eulerAngles;
        //rot.x = -besierTime*2;
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,rot, Time.deltaTime*2F);
    }

    public void LateUpdate()
    {
        
        transform.LookAt(transform.position + direction);
        ForwardMove();
    }

}
