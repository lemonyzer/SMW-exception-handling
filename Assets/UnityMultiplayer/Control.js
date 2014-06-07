#pragma strict

function OnGUI() {
	if(GUI.Button(new Rect(20,100,50,50),"up"))
	{
		GameObject.Find("Player(Clone)").transform.rigidbody.velocity.x=2f;
	}
}