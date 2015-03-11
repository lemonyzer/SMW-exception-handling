using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RequireNetwork : MonoBehaviour
{

	public Slider slots;
	public Toggle listenServer;
	public Toggle tglUseNat;
	public Text port;
	public GameObject panelStartServer;

	public void Start()
	{
		if( Network.peerType == NetworkPeerType.Disconnected )
		{
			panelStartServer.SetActive (true);
		}
	}

	public void StartServer()
	{
		if( Network.peerType == NetworkPeerType.Disconnected )
		{
			Network.InitializeServer( int.Parse(slots.value.ToString()), 25005, tglUseNat.isOn );
			Debug.Log ("useNat = " + tglUseNat.isOn.ToString());
			Debug.Log ("Slots = " + int.Parse(slots.value.ToString()));

			panelStartServer.SetActive (false);
		}

	}
}