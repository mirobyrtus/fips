using UnityEngine;
using System.Collections;

public class FaceShape {

	const int points_count = 66;

	const int chin_size = 17;
	const int chin_start = 0;

	const int EYEBROW_LEFT = 1, EYEBROW_RIGHT = 2;
	const int eyebrow_size = 5;
	const int eyebrow_start_left = chin_start + chin_size;
	const int eyebrow_start_right = eyebrow_start_left + eyebrow_size;

	const int nose_size = 4;
	const int nose_start = eyebrow_start_right + eyebrow_size;

	const int nose_bottom_size = 5;
	const int nose_bottom_start = nose_start + nose_size;

	const int EYE_LEFT = 5, EYE_RIGHT = 6;
	const int eye_size = 6;
	const int eye_start_left = nose_bottom_start + nose_bottom_size;
	const int eye_start_right = eye_start_left + eye_size;

	const int MOUTH = 7;
	const int mouth_size_outer = 12;
	const int mouth_start_outer = eye_start_right + eye_size;
	const int mouth_size_inner = 6;
	const int mouth_start_inner = mouth_size_outer + mouth_start_outer;

	Vector2[] eyebrowLeft;
	Vector2[] eyebrowRight;

	int getOrganShapeCount(int organCode) {
		switch (organCode) {
			// TODO chin & nose
			case EYEBROW_LEFT: 	return eyebrow_size;	
			case EYEBROW_RIGHT: return eyebrow_size; 
			case EYE_LEFT: 	return eye_size;	
			case EYE_RIGHT: return eye_size;
			case MOUTH: return mouth_size_inner + mouth_size_outer; // TODO 
		}
		return 0;
	}

	int getOrganShapeStart(int organCode) {
		switch (organCode) {
			// TODO chin & nose
			case EYEBROW_LEFT: 	return eyebrow_start_left;	
			case EYEBROW_RIGHT: return eyebrow_start_right; 
			case EYE_LEFT: 	return eye_start_left;	
			case EYE_RIGHT: return eye_start_right;
			case MOUTH: return mouth_start_outer; // TODO 
		}
		return 0;
	}

	Vector2 getOrganCenter(ref Vector2[] shape, int organCode) {
		float centerX = 0, centerY = 0;

		for (int i = 0; i < getOrganShapeCount(organCode); i++) {
			Vector2 v = shape[getOrganShapeStart(organCode) + i];
			centerX += v.x;
			centerY += v.y;
		}

		centerX /= getOrganShapeCount(organCode);
		centerY /= getOrganShapeCount(organCode);

		return new Vector2 (centerX, centerY);
	}

	const float SHIFT_RATIO = 0.1f;

	public float getLeftEyebrowShiftY(ref Vector2[] shape) {
		Vector2 leftEyeCenter = getOrganCenter (ref shape, EYE_LEFT);
		Vector2 leftEyeBrowCenter = getOrganCenter (ref shape, EYEBROW_LEFT);

		// Debug.Log ("Center = " + leftEyeBrowCenter.y + " - " + leftEyeCenter.y );

		// Mind the 2D Coordinate system - Eyebrow is over eye, but has lower y!
		float leftEyeLeftEyebrowDiffY = leftEyeCenter.y - leftEyeBrowCenter.y;

		return leftEyeLeftEyebrowDiffY * SHIFT_RATIO;
	}

}
