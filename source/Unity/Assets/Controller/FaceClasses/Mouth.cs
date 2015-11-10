using UnityEngine;
using System.Collections;

public class Mouth : Organ {

	// parent_moutopenbonesjaw - lower
	// parent_moutopenbones - upper

	// OUTERMOUTH!
	// TODO inner, corners
	// MOUTH1_UP was explicitly created by merging the MOUTH1_l && MOUTH1_r objects
	public Mouth(int upDown, int inOut) : base((upDown == UP ? "MOUTH1_UP" : "MOUTHDOWN_MIDDLE")) { // TODO r ?
	// public Mouth(int upDown, int inOut) : base("parent_moutopenbones" + (upDown == UP ? "" : "jaw")) {
		shape_size = 5;

		if (upDown == UP) { // UP
			shape_start = 49;
		} else { // DOWN
			shape_start = 55;
		}
		// TODO in / out ? 
		
		shiftRatio = 0.03f;
	}

}
