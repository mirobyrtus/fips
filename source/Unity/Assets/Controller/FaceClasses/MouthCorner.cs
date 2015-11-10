using UnityEngine;
using System.Collections;

public class MouthCorner : Organ {

	public MouthCorner(int leftRight) : base("MOUTHCORNER_" + (leftRight == LEFT ? "l" : "r")) {
	// public MouthCorner(int leftRight) : base("def_lip1_" + (leftRight == LEFT ? "L" : "R") + "_001") {
		shape_size = 1;
		
		if (leftRight == LEFT) { // LEFT
			shape_start = 48;		
		} else { // RIGHT
			shape_start = 54;		
		}

		// TODO shiftRatioY ?
		shiftRatio = 0.01f;
	}

}
