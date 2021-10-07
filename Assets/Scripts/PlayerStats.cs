using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	[SerializeField]
	private Slider ptp;

	[SerializeField]
	private Slider att;

	[SerializeField]
	private Slider acw;

	[SerializeField]
	private Slider refuse;

	public void updateData(PlayerData playerData) {
		ptp.value = playerData.ptp;
		att.value = playerData.att;
		acw.value = playerData.acw;
		refuse.value = playerData.refuse;
	}
}
