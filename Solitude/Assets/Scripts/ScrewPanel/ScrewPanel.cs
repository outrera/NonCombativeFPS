﻿using UnityEngine;
using UnityEngine.UI;

public class ScrewPanel : Terminal, Breakable {
	
    public int screws = 4;
    public int breakPercent = 100;
    private int canvasWid = 1124; 		//TODO Replace me with Camera.pixelwidth -10% where camera = maincamera
	private int canvasHig = 552;		//TODO Replace me with Camera.pixelheight-10% where camera = maincamera

    private int screwed = 0;
    private bool isFixing = false;

    public override void interact() {
        if (isFixing == false) {
            screwed = 0;
            for (int i = 0; i < screws; i++) {
                Debug.Log("Screwing");
                GameObject newscrew = Instantiate(this.ui.GetComponent<ScrewPanelControler>().screw, ui.transform);
                newscrew.transform.position = new Vector3(Random.Range(60, canvasWid - 60), Random.Range(60, canvasHig - 60), 0);
                newscrew.GetComponent<Button>().onClick.AddListener(delegate { clickButton(newscrew); });
            }
            isFixing = true;
        }
        show();
    }

    public void onBreak() {
        screwed = 0;
        this.setActive(true);
    }

    protected override void initialise() {
        new BreakEvent(this, breakPercent);
        this.onBreak();
    }

    public void clickButton(GameObject button) {
        button.gameObject.SetActive(false);
        if((screwed += 1) == screws) {
            onFix();
        }
    }

    public void onFix() {
        hide();
        isFixing = false;
        this.setActive(false);
    }

    protected override void doUpdate() {
        
    }
    protected override void onClose() {

    }
}
