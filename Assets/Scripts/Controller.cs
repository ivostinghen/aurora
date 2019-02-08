using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private int powerAmount;

    public int GetPowerSourcesAmount() => powerAmount;
    public void SetPowerAmount(int newAmount) => powerAmount = newAmount;


    private void Awake()
    {
        powerAmount = -1;
        instance = this;
    }

    public void DecreasePowerAmount()
    {
        powerAmount--;
        if (powerAmount == 0)
        {
            //Finish();
        }
    }


}
