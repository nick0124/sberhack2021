using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatingRow : MonoBehaviour
{
	[SerializeField]
	private TMP_Text placeText;

	[SerializeField]
	private TMP_Text nameText;

	[SerializeField]
	private TMP_Text scoreText;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetData(RatingData ratingData) {
		placeText.text = ratingData.place.ToString();
		nameText.text = ratingData.name;
		scoreText.text = ratingData.score.ToString();
	}
}
