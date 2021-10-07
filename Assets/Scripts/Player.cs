using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent agent;

	[SerializeField]
	private PlayerData playerData = null;

	[SerializeField]
	private Transform[] points;

	void Update() {
		if (playerData.currentWaypoint != 0) {
			agent.SetDestination(points[playerData.currentWaypoint - 1].position);
		}
	}

	public void SetPlayerData(PlayerData playerData) {
		this.playerData = playerData;
	}

	public void SetPos(int pointNumber) {
		transform.position = points[pointNumber-1].position;
	}
}
