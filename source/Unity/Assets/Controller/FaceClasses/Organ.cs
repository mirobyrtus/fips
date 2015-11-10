using UnityEngine;
using System.Collections;

public class Organ {

	Vector2 neutralShift = Vector2.zero;
	Vector2 actualShift = Vector2.zero;

	Transform rig;
	Vector3 initialPosition;
	int relativePositionToPivot;

	// Debug
	string name;

	protected int shape_size;
	protected int shape_start;
	protected float shiftRatio = 0.05f;

	public const int LEFT = 0;
	public const int RIGHT = 1;
	public const int UP = 2;
	public const int DOWN = 3;
	public const int IN = 4;
	public const int OUT = 5;

	// -------------------------------------------------------------

	public Organ(string rigName) {
		neutralShift = Vector2.zero;
		rig = GameObject.Find (rigName).transform;
		initialPosition = rig.position;

		// Debug 
		name = rigName;
	}

	public Organ() {
		// if organ not rigged
		rig = null;
	}

	// SHIFT 2 VERSION

	public bool neutralShifIsset() {
		return (! neutralShift.Equals(Vector2.zero));
	}
	
	public void unsetNeutralShift() {
		neutralShift = Vector2.zero;
	}
	
	public void setNeutralShift(Vector2 newNeutralShift) {
		neutralShift = newNeutralShift;
	}
	
	public void applyShift() {
		// Debug.Log ("(" + name + ") Actual shift = " + actualShift + " [neutral shift = " + neutralShift + "]");
		
		rig.position = initialPosition;
		Vector2 shift;
		if (relativePositionToPivot == UP) {
			shift = actualShift - neutralShift;
		} else {
			shift = neutralShift - actualShift;
		}

		shift *= shiftRatio;
		// shift *= shiftRatio * 2; // For 1st Holmen Model

		// Move only on x and y axis - the shape is only 2D and the 3D position is static
		rig.position += new Vector3 (shift.x, shift.y, 0f);
	}
	
	public void getShift(ref Vector2[] shape, Organ pivotOrgan, int upDown) {
		Vector2 thisCenter = getOrganCenter (ref shape);
		Vector2 pivotCenter = pivotOrgan.getOrganCenter (ref shape);
		
		relativePositionToPivot = upDown;
		
		if (relativePositionToPivot == UP) { // UP - pivot is under us -> bigger y
			actualShift = pivotCenter - thisCenter;
		} else if (relativePositionToPivot == DOWN) { // DOWN - pivot is above us -> smaller y
			actualShift = thisCenter - pivotCenter;
		}

		if (! neutralShifIsset()) {
			setNeutralShift(actualShift);
		}
	}
	
	public Vector2 getOrganCenter(ref Vector2[] shape) {
		Vector2 center = Vector2.zero;

		for (int i = 0; i < shape_size; i++) {
			center += shape[shape_start + i];
		}
		
		center /= shape_size;
		return center;
	}
	
}
