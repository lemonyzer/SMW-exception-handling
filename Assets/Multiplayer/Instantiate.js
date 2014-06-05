#pragma strict

var PlayerCharacter : Transform;

function OnNetworkLoadedLevel () {
	// Instantiating SpaceCraft when Network is loaded
	//Network.Instantiate(SpaceCraft, transform.position, transform.rotation, 0);
	Network.Instantiate(PlayerCharacter, new Vector3(Random.Range(0.0f, 19.0f),Random.Range(2f, 15.0f),0), transform.rotation, 0);
	
}

function OnPlayerDisconnected (player : NetworkPlayer) {
	Debug.Log("Server destroying player");
	Network.RemoveRPCs(player, 0);
	Network.DestroyPlayerObjects(player);
}