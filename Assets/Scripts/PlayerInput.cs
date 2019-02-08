using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;
    float debugTime;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        playerMove.enabled = true;
    }

    private void Update()
    {
        debugTime += Time.deltaTime;

        if(Input.GetButtonDown("Fire1"))
        {
            //if (playerMove.GetSpeed() > 0) playerMove.StopMove();
            /*else */playerMove.Move();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            playerMove.StopMove();
            //StartCoroutine(playerMove.Flip());
        }




    }



}
