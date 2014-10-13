#pragma strict
var snd_click : AudioClip;
var can_play : int;

function Start () {
 can_play = 0;
}

function Update () {
	if (can_play == 1) {
		audio.PlayOneShot(snd_click);
		can_play = 0;
	}
}