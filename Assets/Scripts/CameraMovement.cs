using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public enum CameraMode {
		Game,
		Menu
	};

	public float menuCameraRotationSpeed;

	public CameraMode cameraMode;

	public MouseScreenPos mouseScreenPos;

	private Vector2 mousePosOnPress;
	public Vector3 cameraAngOnPress;
	public bool mousePressed = false;

	public Vector2 deltaPos;

	// Update is called once per frame
	void Update() {
		if (cameraMode == CameraMode.Game) {
			if (Input.GetMouseButtonDown(0)) {
				mousePosOnPress = mouseScreenPos.screenPosInPercents;
				cameraAngOnPress = gameObject.transform.eulerAngles;
				mousePressed = true;
			}
			if (mousePressed) {
				deltaPos = new Vector2(mousePosOnPress.x - mouseScreenPos.screenPosInPercents.x, mousePosOnPress.y - mouseScreenPos.screenPosInPercents.y);
				gameObject.transform.eulerAngles = new Vector3(0, cameraAngOnPress.y - deltaPos.x, 0);
			}
			if (Input.GetMouseButtonUp(0)) {
				mousePosOnPress = Vector2.zero;
				deltaPos = Vector2.zero;
				mousePressed = false;
			}
		}
	}

	void FixedUpdate() {
		if (cameraMode == CameraMode.Menu) {
			gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y + menuCameraRotationSpeed, 0);
		}
	}

	private void OnDisable() {
		mousePressed = false;
		deltaPos = Vector2.zero;
	}
}
