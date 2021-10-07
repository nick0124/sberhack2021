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
		FirstLoad();
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


}
