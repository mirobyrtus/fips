using UnityEngine;
using System.Collections;

public class Face {
	
	EyeBrow eyebrowL, eyebrowR;
	EyeLid eyeLidLUp, eyeLidRUp, eyeLidLDown, eyeLidRDown;
	Nose nose;
	Chin chin; // not needed anymore
	Mouth mouthUpperOuter, mouthLowerOuter;
	Jaw jaw;
	MouthCorner mouthCornerL, mouthCornerR;
	NoseWing noseWingL, noseWingR;

	Vector2 initialFaceCenter = Vector2.zero;
	float centerTolerance = 50f;
	// Vector2 initialDimension = Vector2.zero;
	// float dimensionTolerance = 3f;

	public Face() {
		// init all organs

		eyebrowL = new EyeBrow (Organ.LEFT);
		eyebrowR = new EyeBrow (Organ.RIGHT);

		eyeLidLUp = new EyeLid (Organ.LEFT, Organ.UP);
		eyeLidRUp = new EyeLid (Organ.RIGHT, Organ.UP);
		eyeLidLDown = new EyeLid (Organ.LEFT, Organ.DOWN);
		eyeLidRDown = new EyeLid (Organ.RIGHT, Organ.DOWN);

		nose = new Nose (); // nose is int the center of face - good pivot organ
		chin = new Chin (); // Represents the center of the face!!! Calculate scale and rotation according to this

		mouthUpperOuter = new Mouth (Organ.UP, Organ.OUT);
		mouthLowerOuter = new Mouth (Organ.DOWN, Organ.OUT);

		jaw = new Jaw (); // tracking only the lowest point

		mouthCornerL = new MouthCorner (Organ.LEFT);
		mouthCornerR = new MouthCorner (Organ.RIGHT);

		/*
		noseWingL = new NoseWing (Organ.LEFT);
		noseWingR = new NoseWing (Organ.RIGHT);
		*/
	}

	public Vector2 getFaceDimensions(ref Vector2[] shape) {
		int faceLeftIndex = 0;
		int faceRightIndex = 16;
		int faceTopIndex = 19; // top of left eyebrow. Does not have to been top accurate, needed just for size change check.
		int faceBottomIndex = 8;

		float width = shape[faceRightIndex].x - shape[faceLeftIndex].x;
		float height = shape[faceBottomIndex].y - shape[faceTopIndex].y;

		return new Vector2 (width, height);
	}

	public void correctHeadCenter(ref Vector2[] shape, Vector2 move) {
		for (int i = 0; i < shape.Length; i++) {
			shape[i] -= move;
		}
	}

	public void setShifts(ref Vector2[] shape) {

		/* TODO not working as expected
		// NEUTRALIZE WHOLE-HEAD MOVEMENT (X/Y)
		Vector2 actualCenter = nose.getOrganCenter (ref shape);
		if (initialFaceCenter.Equals (Vector2.zero)) {
			initialFaceCenter = actualCenter;
		} else {
			Vector2 headCenterMove = actualCenter - initialFaceCenter;
			float xbefore = nose.getOrganCenter (ref shape).x;

			if (headCenterMove.magnitude > centerTolerance) {
				correctHeadCenter(ref shape, headCenterMove);
			}

			Debug.Log("BEFORE: x = " + xbefore + 
			          ", after: x = " + nose.getOrganCenter (ref shape).x + 
			          " (INITIAL = " + initialFaceCenter.x + ")");
		}
		*/ 

		/*
		// NEUTRALIZE WHOLE-HEAD MOVEMENT (Z)
		Vector2 actualDimension = getFaceDimensions (ref shape);
		if (initialDimension.Equals (Vector2.zero)) {
			initialDimension = actualDimension;
		} else {
			if (Vector2.Distance(actualDimension, initialDimension) > dimensionTolerance) {
				// TODO what to do now? 
				// * re-initialize Whole mask?
				// * addapt shape?
			}
		}
		*/

		eyebrowL.getShift (ref shape, nose, Organ.UP);  
		eyebrowR.getShift (ref shape, nose, Organ.UP);

		// CANNOT USE EYEBROW AS REFERENCE BECAUSE ITS NOT STATIC! use NOSE instead

		// TODO 2 one up, second down - recalculate Y center of eyes itself, without reference
		eyeLidLUp.getShift (ref shape, nose, Organ.DOWN); 
		eyeLidRUp.getShift (ref shape, nose, Organ.DOWN); 
		eyeLidLDown.getShift (ref shape, nose, Organ.UP); 
		eyeLidRDown.getShift (ref shape, nose, Organ.UP); 

		// TODO UP in order to revert direction. Other way is to implement one more method, extra for reverting directions (usable when open/closable organs)
		mouthUpperOuter.getShift  (ref shape, nose, Organ.DOWN);
		mouthLowerOuter.getShift (ref shape, nose, Organ.UP);

		jaw.getShift (ref shape, nose, Organ.DOWN);

		mouthCornerL.getShift (ref shape, nose, Organ.DOWN); // UP - to revert shift ? here we want to move on X axis
		mouthCornerR.getShift (ref shape, nose, Organ.DOWN);

		/* only in the original holmen
		noseWingL.getShift (ref shape, nose, Organ.DOWN);
		noseWingR.getShift (ref shape, nose, Organ.DOWN);
		*/
	}
		
	public void unsetNeutralShifts() {

		initialFaceCenter = Vector2.zero;
		// initialDimension = Vector2.zero;

		// For each organ
		eyebrowL.unsetNeutralShift ();
		eyebrowR.unsetNeutralShift ();

		eyeLidLUp.unsetNeutralShift ();
		eyeLidRUp.unsetNeutralShift ();
		eyeLidLDown.unsetNeutralShift ();
		eyeLidRDown.unsetNeutralShift ();

		mouthUpperOuter.unsetNeutralShift ();  
		mouthLowerOuter.unsetNeutralShift ();

		jaw.unsetNeutralShift ();

		mouthCornerL.unsetNeutralShift ();
		mouthCornerR.unsetNeutralShift ();

		/*
		noseWingL.unsetNeutralShift ();
		noseWingR.unsetNeutralShift ();
		*/

		// FUTURE WORK: apply smoothing (the 3D head is Shaking because 2D is shaking)
	}

	public void shiftOrgans() {
		eyebrowL.applyShift ();
		eyebrowR.applyShift ();
			
		eyeLidLUp.applyShift ();
		eyeLidRUp.applyShift ();
		eyeLidLDown.applyShift ();
		eyeLidRDown.applyShift ();

		mouthUpperOuter.applyShift ();
		mouthLowerOuter.applyShift ();

		jaw.applyShift ();

		mouthCornerL.applyShift ();
		mouthCornerR.applyShift ();

		/*
		noseWingL.applyShift ();
		noseWingR.applyShift ();
		*/
	}
	
}
