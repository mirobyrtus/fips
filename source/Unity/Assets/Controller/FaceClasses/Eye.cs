using UnityEngine;
using System.Collections;

public class Eye : Organ {

	// TODO 
	// "mch_eyedown_L"
	// "mch_eyetop_L"

	// TODO this class is not used anymore - noe EyeLid used

	public Eye(int flag) : base("mch_eyetop_" + (flag == LEFT ? "L" : "R")) { // TODO ! 
		shape_size = 6;
		
		if (flag == Organ.LEFT) { // LEFT
			shape_start = 36;		
		} else { // RIGHT
			shape_start = 42;		
		}
	}
	
}
