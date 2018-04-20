using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scor_board : MonoBehaviour {

		public static int score;        // The player's score.
		public GameObject player;


		Text text;                      // Reference to the Text component.


		void Awake ()
		{
			// Set up the reference.
			text = GetComponent <Text> ();

			// Reset the score.
			score = 0;
		}


		void Update ()
		{
		if (player != null) {
			score++;
		}
			// Set the displayed text to be the word "Score" followed by the score value.
			text.text = "Score: " + score;
		if (player == null) {
			SceneManager.LoadScene ("EndScreen");
		}
		}
	}

