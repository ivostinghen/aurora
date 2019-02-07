using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;


    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        playerMove.enabled = true;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (playerMove.GetSpeed() > 0) playerMove.StopMove();
            else playerMove.Move();
        }
       
        
    }


    
}
