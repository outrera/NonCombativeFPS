﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CargoRoomAnim checks the state of the crane animation currently, and plays the appropriate animation based on this.
/// </summary>

public class CargoRoomAnim : MonoBehaviour
{

    Animator anim;
    int nextCrate;
    AudioSource source;

    public CrateGiveItem crate1;
    public CrateGiveItem crate2;
    public CrateGiveItem crate3;
    public CrateGiveItem crate4;

    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        source.volume = (PlayerPrefs.GetFloat("SFXSound"));
    }

  
    /// <summary>
    /// playAnim will check if there is an animation playing, and if there is not, it will either:
    /// - Return the crate currently accessible by the player
    /// - Grab a crate and make it accessible by the player
    /// </summary>
    public void playAnim()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Default State"))
        {
            nextCrate = Random.Range(1,4);
            switch (nextCrate)
            {
                case 1:
                    anim.SetTrigger("Crate1Fetch");
                    crate1.canGiveItem = true;
                    Debug.Log("crate1");
                    break;
                case 2:
                    anim.SetTrigger("Crate2Fetch");
                    crate2.canGiveItem = true;
                    Debug.Log("crate2");
                    break;
                case 3:
                    anim.SetTrigger("Crate3Fetch");
                    crate3.canGiveItem = true;
                    Debug.Log("crate3");
                    break;
                case 4:
                    anim.SetTrigger("Crate4Fetch");
                    crate4.canGiveItem = true;
                    Debug.Log("crate4");
                    break;
            }
        }
        else if (
            anim.GetCurrentAnimatorStateInfo(0).IsName("Crate 1 Resting") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Crate 2 Resting") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Crate 3 Resting") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Crate 4 Resting")
            )
        {
            switch (nextCrate)
            {
                case 1:
                    anim.SetTrigger("Crate1Return");
                    break;
                case 2:
                    anim.SetTrigger("Crate2Return");
                    break;
                case 3:
                    anim.SetTrigger("Crate3Return");
                    break;
                case 4:
                    anim.SetTrigger("Crate4Return");
                    break;
            }
        }
    } //end of playanim();
}