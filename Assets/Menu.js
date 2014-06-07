
function OnGUI() {
	GUI.Label(new Rect((Screen.width/2)-80,(Screen.height/2)-130,200,50),"SELECT CONNECTION TYPE");
	GUI.Label(new Rect((Screen.width-250),(Screen.height-60),250,30),"Super Serious Cereal War MP Demo 0.1");
	
	if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)-100,200,50),"Single Player"))
	{
		Application.LoadLevel("sp_classic");
	}
	
	if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)-40,200,50),"Master Server Connection"))
	{
		Application.LoadLevel("mp_MasterServer");
	}
	
	if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)+20,200,50),"Direct Connection"))
	{
		Application.LoadLevel("mp_StarTrooper");
	}
	
	if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)+80,200,50),"Touch Test"))
	{
		Application.LoadLevel("touchtest");
	}
	
		if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)+140,200,50),"Photon Network"))
	{
		Application.LoadLevel("pun_classic");
	}
	
}