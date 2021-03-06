﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Chargepad class is used to run the RechargeBattery() function of the BatterymManager script when the player stands on a chargepad.
/// </summary>

public class Chargepad : MonoBehaviour {

    GameObject player;
    public BatteryManager bat;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) < 3) //player is near enough, or on, the chargpad
        {
            bat.RechargeBattery();
        }
    }
}
