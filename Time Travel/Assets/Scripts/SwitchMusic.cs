using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    public AudioSource MusicPast;
    public AudioSource MusicFut;
    public bool Futuro;
    public KeyCode ChangeFut;
    private bool AddVol;
    private float timerChange ;
    private float cooldown = 0.5f;
    void Update()
    {
        if (Input.GetKeyDown(ChangeFut))
        {
            Futuro = !Futuro;
        }
        if(Futuro)
        {
            SetFut();
            
        }
        else
        {
            SetPast(); 
        }
        if (timerChange >= cooldown)
        {
            AddVol = true;
        }
        else
        {
            timerChange += Time.deltaTime;
        }
    }
    private void SetFut()
    {
        if(AddVol)
        {
            MusicFut.volume += 0.25f;
            MusicPast.volume -= 0.25f;
            AddVol = false;
            timerChange = 0;
        }
    }
    private void SetPast()
    {
        if (AddVol)
        {
            MusicFut.volume -= 0.25f;
            MusicPast.volume += 0.25f;
            AddVol = false;
            timerChange = 0;
        }
    }

}
