using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	[SerializeField]
	private Player player;

	[SerializeField]
	private PlayerData playerData;

	[SerializeField]
	private PlayerData[] playersData;

	[SerializeField]
	private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
		//InvokeRepeating("LoadData", 10f, 10f);
		//FirstLoad();

		string url = "http://hakasb.ru/getPlayer.php";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	void FirstLoad() {
		string json = "{\"id\":\"1\"," +
			"\"name\":\"Иванов Иван Иванович\"," +
			"\"currentWaypoint\":\"3\"," +
			"\"ptp\":\"0.1\"," +
			"\"att\":\"0.4\"," +
			"\"acw\":\"1\"," +
			"\"refuse\":\"0.8\"}";

		playerData = JsonUtility.FromJson<PlayerData>(json);
		//spawner.SpawnPlayer(playerData.currentWaypoint);
		player.SetPlayerData(playerData);
		player.SetPos(playerData.currentWaypoint);
		playerStats.updateData(playerData);
	}

	void LoadData() {
		//Debug.Log("a");
		string json = "{\"id\":\"1\"," +
			"\"name\":\"Иванов Иван Иванович\"," +
			"\"currentWaypoint\":\"1\"," +
			"\"ptp\":\"1\"," +
			"\"att\":\"2\"," +
			"\"acw\":\"2\"," +
			"\"refuse\":\"3\"}";

		playerData = JsonUtility.FromJson<PlayerData>(json);
	}

	public void MakeMove() {
		string json = "{\"id\":\"1\"," +
			"\"name\":\"Иванов Иван Иванович\"," +
			"\"currentWaypoint\":\"4\"," +
			"\"ptp\":\"1\"," +
			"\"att\":\"2\"," +
			"\"acw\":\"2\"," +
			"\"refuse\":\"3\"}";

		playerData = JsonUtility.FromJson<PlayerData>(json);
		player.SetPlayerData(playerData);
		playerStats.updateData(playerData);
	}

	IEnumerator WaitForRequest(WWW www) {
		yield return www;

		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Result!: " + www.text);// contains all the data sent from the server
			playersData = JsonHelper.getJsonArray<PlayerData>(www.text);
			player.SetPlayerData(playersData[0]);
			player.SetPos(playersData[0].currentWaypoint);
			playerStats.updateData(playersData[0]);
		} else {
			Debug.Log("WWW Error: " + www.error);
		}
	}


	//public int id;
	//public string name;
	//public int currentWaypoint;

	//public float ptp;
	//public float att;
	//public float acw;
	//public float refuse;


	//[{"id":"1",
	//"currentWaypoint":"3",
	//"ptp":"0.1",
	//"att":"0.4",
	//"acw":"1",
	//"refuse":"0.8"},
	//{"id":"2",
	//"currentWaypoint":"3",
	//"ptp":"0.1",
	//"att":"0.4",
	//"acw":"1",
	//"refuse":"0.8"}]
}
