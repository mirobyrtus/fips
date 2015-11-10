using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

public class FaceTrackerPlugin : MonoBehaviour {

	// private FaceShape faceShapeHelper = new FaceShape ();
	// private BonesHandler bonesHandler = new BonesHandler ();

	public bool debugFaceTracking = false;

	int classifiedExpressionLabel = 0;

	/* Plugin */
	[DllImport("FACE_TRACKER")]
	private static extern int getShape(ref IntPtr pointsX, ref IntPtr pointsY, ref int classified_label, bool showCamera);

	[DllImport("FACE_TRACKER")]
	private static extern bool initFaceTracker();

	[DllImport("FACE_TRACKER")]
	private static extern bool releaseFaceTracker();

	Vector2[] getShape () {
		Vector2[] result = null;

		IntPtr ptrPointsX = IntPtr.Zero;
		IntPtr ptrPointsY = IntPtr.Zero;
		int classifiedLabel = 0;
		
		int shapeSize = getShape (ref ptrPointsX, ref ptrPointsY, ref classifiedLabel, debugFaceTracking);
		if (shapeSize >= 0) {

			// Load the results into a managed array.
			float[] pointsX = new float[shapeSize];
			float[] pointsY = new float[shapeSize];

			Marshal.Copy (
				ptrPointsX, 
				pointsX, 
				0, 
				shapeSize
				);
			
			Marshal.Copy (
				ptrPointsY, 
				pointsY, 
				0, 
				shapeSize
				);

			result = new Vector2[shapeSize];
			for (int i = 0; i < shapeSize; i++) {
				result[i] = new Vector2(pointsX[i], pointsY[i]);
			}

			// Also save the classified Expression
			classifiedExpressionLabel = classifiedLabel;	

			// Debug.Log("Result -> " + result);

		} else { 
			// Debug.Log("UNSUCCESSFUL!!!"); 
		}

		return result;
	}

	private Face face;

	// Use this for initialization
	void Start () {
		initFaceTracker ();
		// bonesHandler.init ();
		face = new Face ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2[] shape = getShape (); // Also sets the expression label
		if (shape != null) {

			// setShifts also initializes the Mask
			face.setShifts(ref shape);
			face.shiftOrgans();

			Debug.Log("Recognized emotion = " + EmotionHelper.getLabelDescription(classifiedExpressionLabel));
			EmotionHelper.showEmotionColor(classifiedExpressionLabel);

		} else {

			// Face Lost -> RE/INITIALIZE MASK HERE! (Neutralize)
			face.unsetNeutralShifts();
		}
	}

	// TODO FixedUpdate?

	void OnDestroy() {
		releaseFaceTracker ();
	}

}