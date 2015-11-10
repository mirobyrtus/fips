using UnityEngine;
using System.Collections;

public class EyeLid : Organ {

	//	 	37 38			   43 44		//
	//	 36       39 		42       45		//
	//	    41 40  	 		   47 46		//


	public EyeLid(int leftRight, int upDown) : base(
//		"mch_eye" + (upDown == Organ.UP ? "top" : "down") + "_" + (leftRight == LEFT ? "L" : "R")) 
		"def_eyelid_" + (upDown == Organ.UP ? "up" : "down") + "_" + (leftRight == LEFT ? "l" : "r")) 
	{
		if (leftRight == LEFT && upDown == UP) { // LEFT TOP
			shape_start = 37;
			shape_size = 2;
		} else if (leftRight == RIGHT && upDown == UP) { // RIGHT TOP
			shape_start = 43;
			shape_size = 2;
		} else if (leftRight == LEFT && upDown == DOWN) { // LEFT DOWN
			shape_start = 40;
			shape_size = 2;
		} else if (leftRight == RIGHT && upDown == DOWN) { // RIGHT DOWN
			shape_start = 46;
			shape_size = 2;
		}

		shiftRatio = 0.04f;
	}

}
