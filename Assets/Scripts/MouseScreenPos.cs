using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScreenPos : MonoBehaviour
{
	private Vector2 pixelsToPercents;
	private Vector2 mouseScreenPos;

	public Vector2 screenPosInPercents;

	void Start() {
		pixelsToPercents = new Vector2((float)Screen.width / 100, (float)Screen.height / 100);
	}

	void Update() {
		mouseScreenPos = Input.mousePosition;
		screenPosInPercents = new Vector2(mouseScreenPos.x / pixelsToPercents.x, mouseScreenPos.y / pixelsToPercents.y);
	}
}
