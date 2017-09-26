﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
 * Controls and displays the win and lose condition for the game which is a timer.
 * Displays the countdown timer on a canvas
 * 
 *Created by Jonothan
 *Modified by Alexander Tilley 23/09/2017
 *
 */
public class GameConditions : MonoBehaviour {

    float shiphealth = 100;
    float TurretAccuracy = 60f;   //THE ACCURACY FROM TURRET CALIBRATION VARIABLE NEEDS TO GO HERE
    float AsteroidHitChance;
    bool AsteroidOccurance = false;
    public float GameTime = 600.0f;
    public Text TimeLefttext;
    public Text ShipHealthtext;                 //Text to display on bridge screen to update time
    bool GameoverCrewdead;
    bool GameoverShipdead;
    public GameObject EndGameWindow;            //Window that displays the end game screen
    public AudioClip Explosionclip;
    public AudioSource Explosionsource;

    public Text EndGameText;					//Text Object to display at endgame

    // Use this for initialization
    void Start ()
    {
        ShipHealthtext.text = "Hull Integrity " + shiphealth + " %";
        Explosionsource.clip = Explosionclip;

    }
	
	// Update is called once per frame
	void Update ()
    {


        AsteroidHitChance = (100 - TurretAccuracy);
        AsteroidChance();

        if(AsteroidOccurance == true && shiphealth >= 0)
        {
            float random1 = Random.Range(0, 100);
            {
                if(random1 >= 0 && random1 <= AsteroidHitChance)
                {
                    float random2 = Random.Range(1, 7);
                    {
                        shiphealth = shiphealth - random2;
                        ShipHealthtext.text = "Hull Integrity " + shiphealth + " %";
                        Explosionsource.Play();
                        
                    }
                    
                }
            }
        }

        GameObject terminalObject = GameObject.Find("TerminalConsole5 (1)");
        CryoTerminalScript cryotermscript = terminalObject.GetComponent<CryoTerminalScript>();
        GameoverCrewdead = cryotermscript.allcrewdead;

        GameTime -= UnityEngine.Time.deltaTime;
        TimeLefttext.text = "Time Remaining:  " + Mathf.Round(GameTime);

        if(GameTime < 0)											//Player Wins
        {
			EndGameWindow.SetActive(true);						//Display EndGame Window
            Player.playerObj.FPSEnable(false);
        }
        if(GameoverCrewdead)
        {
            loseGame("The crew are dead");
        }

        if(shiphealth <= 0)
        {
            loseGame("The ship has been destroyed");
        }
       

    }

    void AsteroidChance()
    {
        float random = Random.Range(0, 5000);
        {
            if (random < 65 && random > 50)
            {
                AsteroidOccurance = true;
            }
            else
            {
                AsteroidOccurance = false;
            }
        }

    }



	//Triggers lose game state and displays addtional text if needed
	public void loseGame(string optional){
		if (optional == null) {				//If nothing was entred
			optional = "";
		}
		EndGameText.color = Color.red;
		EndGameText.text = "Game Over \n" + optional;	//Change Text
		EndGameWindow.SetActive(true);
		Player.playerObj.FPSEnable(false);

	}
}