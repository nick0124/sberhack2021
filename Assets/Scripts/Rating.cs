using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
	[SerializeField]
	private Transform container;

	[SerializeField]
	private GameObject rowPrefab;

	[SerializeField]
	private RatingData[] ratingData;

	// Start is called before the first frame update
	void Start()
    {
		//FirstLoad();

		string url = "http://hakasb.ru/scoreboard.php";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void FirstLoad() {
		string json = "[{\"id\":\"1\"," +
			"\"place\":\"1\"," +
			"\"name\":\"Иванов Иван Иванович\"," +
			"\"score\":\"1\"}," +
			"{\"id\":\"2\"," +
			"\"place\":\"2\"," +
			"\"name\":\"Петров Петр Петрович\"," +
			"\"score\":\"2\"}," +
			"{\"id\":\"3\"," +
			"\"place\":\"3\"," +
			"\"name\":\"Сидоров Егор Сергеевич\"," +
			"\"score\":\"3\"}]";
		ratingData = JsonHelper.getJsonArray<RatingData>(json);
		for (int i = 0; i < ratingData.Length; i++) {
			GameObject ratingRowInstance = Instantiate(rowPrefab, container.transform);
			ratingRowInstance.GetComponent<RatingRow>().SetData(ratingData[i]);
		}

		//playerData = JsonUtility.FromJson<PlayerData>(json);
		////spawner.SpawnPlayer(playerData.currentWaypoint);
		//player.SetPlayerData(playerData);
		//player.SetPos(playerData.currentWaypoint);
		//playerStats.updateData(playerData);
	}

	IEnumerator WaitForRequest(WWW www) {
		yield return www;

		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Result!: " + www.text);// contains all the data sent from the server
			ratingData = JsonHelper.getJsonArray<RatingData>(www.text);
			for (int i = 0; i < ratingData.Length; i++) {
				GameObject ratingRowInstance = Instantiate(rowPrefab, container.transform);
				ratingRowInstance.GetComponent<RatingRow>().SetData(ratingData[i]);
			}
		} else {
			Debug.Log("WWW Error: " + www.error);
		}
	}


}
