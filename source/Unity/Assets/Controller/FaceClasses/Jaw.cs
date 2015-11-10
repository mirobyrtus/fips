using UnityEngine;
using System.Collections;

public class Jaw : Organ {

	public Jaw() : base("def_jaw") 
	{
		shape_start = 8;
		shape_size = 1;

		shiftRatio = 0.01f;
	}

}
