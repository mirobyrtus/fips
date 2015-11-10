using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmotionHelper {

	// TODO Classify Emotions according WITHOUT THE CHIN? Because of the angle of captured face (Eyebrow under chinStart)

	// Labels
	const int EXPRESSION_NEUTRAL 	= 0;
	const int EXPRESSION_HAPPY 		= 1;
	const int EXPRESSION_SAD 		= 2;
	const int EXPRESSION_FEAR 		= 3;
	const int EXPRESSION_ANGER 		= 4;
	const int EXPRESSION_SURPRISE 	= 5;
	const int EXPRESSION_DISGUST 	= 6;

	static GameObject emotionSignalizer = null;
	static GameObject emotionLabel = null; 
	static GameObject emotionPrecissionLabel = null; 

	static string[] labelDescriptions = new string[] {
		"NEUTRAL", "HAPPY", "SAD", "FEAR", "ANGER", "SURPRISE", "DISGUST"
	};

	public static string getLabelDescription(int label) {
		return labelDescriptions[label];
	}

	static Color[] labelColor = new Color[] {
		Color.white, Color.green, Color.black, Color.red, Color.blue, Color.cyan, Color.yellow
	};

	// TODO refactor
	public static void showEmotionColor(int label) {

		/*
		if (emotionSignalizer == null) 
			emotionSignalizer = GameObject.Find ("EmotionSignalizer");
		
		emotionSignalizer.renderer.material.color = labelColor[label];
		*/

		if (emotionLabel == null) 
			emotionLabel = GameObject.Find ("EmotionLabel");

		Text emotionText = emotionLabel.GetComponent<Text> ();
		emotionText.text = getLabelDescription(label);
	}

}
