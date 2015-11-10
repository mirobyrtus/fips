using UnityEngine;
using System.Collections;

public class NoseWing : Organ {

	public NoseWing(int leftRight) : base("def_nosewing1_" + (leftRight == LEFT ? "L" : "R")) {
		shape_size = 2;
		
		if (leftRight == LEFT) { // LEFT
			shape_start = 31;		
		} else { // RIGHT
			shape_start = 34;		
		}
	}

}
