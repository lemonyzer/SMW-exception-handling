
var numberOfAllPlayer = 4;
var numberOfAIPlayer = 3;
var numberOfLocalUserPlayer = 1;
var btnCount : float;
var btnSpacing : float;
var btnHeight : float;

function OnGUI() {
	GUI.Label(new Rect((Screen.width/2)-80,(Screen.height/2)-130,200,50),"SELECT CONNECTION TYPE");
	GUI.Label(new Rect((Screen.width-250),(Screen.height-60),250,30),"Super Serious Cereal War MP Demo 0.1");
//	
//	btnCount = 4f;
//	btnSpacing = 5f;
//	btnHeight = Screen.height/(btnCount);
//	
//	Debug.Log(btnHeight);
	
	//if(GUI.Button(new Rect((Screen.width*0.5)-100,(Screen.height/2)-100,200,btnHeight),"Single Player"))
	if(GUI.Button(new Rect(0,0,Screen.width*0.5f,Screen.height*0.5f),"Single Player"))
	{
		numberOfAllPlayer = 4;
		numberOfAIPlayer = 3;
		numberOfLocalUserPlayer = 1;
		PlayerPrefs.SetInt("NumberOfAllPlayers",numberOfAllPlayer);
		PlayerPrefs.SetInt("NumberOfAIPlayers",numberOfAIPlayer);
		PlayerPrefs.SetInt("NumberOfLocalUserPlayers",numberOfLocalUserPlayer);
		Application.LoadLevel("sp_classic");
	}
	
	if(GUI.Button(new Rect((Screen.width*0.5f),(Screen.height*0.5f),Screen.width*0.5f,Screen.height*0.5f),"Interpolation & Prediction"))
	{
		numberOfAllPlayer = 4;
		numberOfAIPlayer = 0;
		numberOfLocalUserPlayer = 1;
		PlayerPrefs.SetInt("NumberOfAllPlayers",numberOfAllPlayer);
		PlayerPrefs.SetInt("NumberOfAIPlayers",numberOfAIPlayer);
		PlayerPrefs.SetInt("NumberOfLocalUserPlayers",numberOfLocalUserPlayer);
		Application.LoadLevel("hostclientmenu");
	}
	
	//if(GUI.Button(new Rect((Screen.width*0.5)-100,(Screen.height/2)+20,200,50),"Direct Connection"))
	if(GUI.Button(new Rect((Screen.width*0.5f),0,Screen.width*0.5f,Screen.height*0.5f),"Multiplayer"))
	{
		numberOfAllPlayer = 4;
		numberOfAIPlayer = 0;
		numberOfLocalUserPlayer = 1;
		PlayerPrefs.SetInt("NumberOfAllPlayers",numberOfAllPlayer);
		PlayerPrefs.SetInt("NumberOfAIPlayers",numberOfAIPlayer);
		PlayerPrefs.SetInt("NumberOfLocalUserPlayers",numberOfLocalUserPlayer);
		Application.LoadLevel("mp_Multiplayer");;
	}
//	
//	if(GUI.Button(new Rect((Screen.width*0.5)-100,(Screen.height/2)+80,200,50),"Touch Test"))
//	{
//		Application.LoadLevel("touchtest");
//	}
	
	//if(GUI.Button(new Rect((Screen.width*0.5)-100,(Screen.height/2)+140,200,50),"Photon Network"))
	if(GUI.Button(new Rect(0,(Screen.height*0.5f),Screen.width*0.5f,Screen.height*0.5f),"Photon Network"))
	{
		Application.LoadLevel("pun_menu");
	}
	
}