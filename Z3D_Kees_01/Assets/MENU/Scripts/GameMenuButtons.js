var isQuit=false;
var isSinglePlayer=false;
var isMultiPlayer=false;
var isOptions=false;
var isBack = false;
var isBackCredits = false;
var isTutorial = false;
var isCredits = false;

//menu 1, 2 and credits for deactivation system
public var menu1 :GameObject;
public var menu2 :GameObject;
public var menuCredits :GameObject;
var snd_enter : AudioClip; // drag the sound here

var ClickSound : GameObject;

function OnMouseEnter(){
	//change text color
	renderer.material.color=Color.red;
	//play button sound
	audio.PlayOneShot(snd_enter);
}

function OnMouseExit(){
	//change text color
	renderer.material.color=Color.white;
}

function OnMouseUp(){
	//play sound; 
	var clone;
	Instantiate(ClickSound);

	//is this quit?
	if (isQuit==true) {
		//quit the game
		Application.Quit();
	}
	//is this singleplayermode?
	if (isSinglePlayer==true) {
		//load level
		Application.LoadLevel(1);
	}
	//is this multiplayermode?
	if (isMultiPlayer==true) {
		//load level
		Application.LoadLevel(1);
	}
	//is this options?
	if (isOptions==true) {
		menu1.SetActive(false);
		menu2.SetActive(true);
		//change text color
	renderer.material.color=Color.white;
	}
	//is this the back button (in menu2)
	if (isBack==true) {
		menu1.SetActive(true);
		menu2.SetActive(false);
		//change text color
	renderer.material.color=Color.white;
	}
	//credits
	if (isCredits==true) {
		menuCredits.SetActive(true);
		menu2.SetActive(false);
		//change text color
	renderer.material.color=Color.white;
	}
	//back in credits
	if (isBackCredits==true) {
		menuCredits.SetActive(false);
		menu2.SetActive(true);
		//change text color
	renderer.material.color=Color.white;
	}
}

function Update(){
	//quit game if escape key is pressed
	if (Input.GetKey(KeyCode.Escape)) {
		Application.Quit();
	}
}