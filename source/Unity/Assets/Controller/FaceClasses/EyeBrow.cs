using UnityEngine;
using System.Collections;

public class EyeBrow : Organ {

	public EyeBrow(int leftRight) : base("BROWN11_" + (leftRight == LEFT ? "l" : "r")) {
	// public EyeBrow(int leftRight) : base("eyebrow2_" + (leftRight == LEFT ? "L" : "R")) {
		shape_size = 5;

		if (leftRight == LEFT) { // LEFT
			shape_start = 17;		
		} else { // RIGHT
			shape_start = 22;		
		}

		shiftRatio = 0.01f;
	}

}
