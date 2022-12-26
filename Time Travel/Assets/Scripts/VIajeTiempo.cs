using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VIajeTiempo : MonoBehaviour
{
    public float MaxCharge;
    public float CurrentCharge;
    private float TimerCd;
    public float MaxCd;
    private bool AddCharge;
    //public CoolBar;
    private void Update()
    {
        if (TimerCd >= MaxCd)
        {
            AddCharge = true;
        }
        else
        {
            TimerCd += Time.deltaTime;
        }
    }
    public void PastOrFut(bool InPast)
    { 
        if(InPast)
        {
          IniciarCooldown();
        }
        else
        {
            //CoolBar = MaxCharge;
        }
    }
    public void IniciarCooldown()
    {
        if (AddCharge)
        {
            CurrentCharge++;
            AddCharge = false;
            TimerCd = 0;
        }
    }
    

        
        

}
