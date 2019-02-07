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
            playerMove.Move();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            playerMove.SetSpeed(0);
        }
        
    }


    
}
