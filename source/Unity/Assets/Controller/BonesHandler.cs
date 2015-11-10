using UnityEngine;
using System.Collections;

public class BonesHandler {

	// Bone Objects

	public Vector3 eyebrowLeftRootInitPosition, eyebrowRightRootInitPosition;

	// Eyebrows
	public Transform eyebrowLeftRoot, eyebrowLeft10, eyebrowLeft11, eyebrowLeft20, eyebrowLeft21;
	public Transform eyebrowRightRoot, eyebrowRight10, eyebrowRight11, eyebrowRight20, eyebrowRight21;

	// Mouth
	public Transform mouthDownLeft, mouthDownRight;
	public Transform mouthUpLeft0, mouthUpLeft1, mouthUpLeft2, mouthUpLeft3, mouthUpLeft4;
	public Transform mouthDownMiddleLeft2, mouthUpMiddleLeft3;
	public Transform mouthDownMiddleRight2, mouthUpMiddleRight3;
	public Transform mouthUpRight0, mouthUpRight1, mouthUpRight2, mouthUpRight3, mouthUpRight4;
	public Transform lipLeft1, lipLeft4;
	public Transform lipRight1, lipRight4;
	
	// Eyes
	public Transform eyeLeftDown1, eyeLeftDown2, eyeLeftDown3, eyeLeftDown4, eyeLeftDown5, eyeLeftDown6;
	public Transform eyeLeftUp1, eyeLeftUp2, eyeLeftUp3, eyeLeftUp4, eyeLeftUp5, eyeLeftUp6;

	public Transform eyeRightDown1, eyeRightDown2, eyeRightDown3, eyeRightDown4, eyeRightDown5, eyeRightDown6;
	public Transform eyeRightUp1, eyeRightUp2, eyeRightUp3, eyeRightUp4, eyeRightUp5, eyeRightUp6;

	// TODO Nose
	// TODO Jaw

	private void holmanAdvancedSetup() {
		if (eyebrowLeftRoot == null) eyebrowLeftRoot = GameObject.Find ("eyebrow2_L").transform;
		eyebrowLeftRootInitPosition = eyebrowLeftRoot.position;
		if (eyebrowLeft10 == null) eyebrowLeft10 = GameObject.Find ("def_eyebrow10_L").transform;
		if (eyebrowLeft11 == null) eyebrowLeft11 = GameObject.Find ("def_eyebrow11_L").transform;
		if (eyebrowLeft20 == null) eyebrowLeft20 = GameObject.Find ("def_eyebrow20_L").transform;
		if (eyebrowLeft21 == null) eyebrowLeft21 = GameObject.Find ("def_eyebrow21_L").transform;

		if (eyebrowRightRoot == null) eyebrowRightRoot = GameObject.Find ("eyebrow2_R").transform;
		eyebrowRightRootInitPosition = eyebrowRightRoot.position; 
		if (eyebrowRight10 == null) eyebrowRight10 = GameObject.Find ("def_eyebrow10_R").transform;
		if (eyebrowRight11 == null) eyebrowRight11 = GameObject.Find ("def_eyebrow11_R").transform;
		if (eyebrowRight20 == null) eyebrowRight20 = GameObject.Find ("def_eyebrow20_R").transform;
		if (eyebrowRight21 == null) eyebrowRight21 = GameObject.Find ("def_eyebrow21_R").transform;
		
		if (mouthDownLeft == null) mouthDownLeft = GameObject.Find ("def_mouthdown1_L").transform;
		if (mouthDownRight == null) mouthDownRight = GameObject.Find ("def_mouthdown1_R").transform;
		if (mouthUpLeft0 == null) mouthUpLeft0 = GameObject.Find ("def_mouthup0_L").transform;
		if (mouthUpLeft1 == null) mouthUpLeft1 = GameObject.Find ("def_mouthup1_L").transform;
		if (mouthUpLeft2 == null) mouthUpLeft2 = GameObject.Find ("def_mouthup2_L").transform;
		if (mouthUpLeft3 == null) mouthUpLeft3 = GameObject.Find ("mch_lip3_L").transform;
		if (mouthUpLeft4 == null) mouthUpLeft4 = GameObject.Find ("mch_lip4_L").transform;
		if (mouthDownMiddleLeft2 == null) mouthDownMiddleLeft2 = GameObject.Find ("def_mouthdown2_L").transform;
		if (mouthUpMiddleLeft3 == null) mouthUpMiddleLeft3 = GameObject.Find ("def_mouthup3_L").transform;
		if (mouthDownMiddleRight2 == null) mouthDownMiddleRight2 = GameObject.Find ("def_mouthdown2_R").transform;
		if (mouthUpMiddleRight3 == null) mouthUpMiddleRight3 = GameObject.Find ("def_mouthup3_R").transform;
		if (mouthUpRight0 == null) mouthUpRight0 = GameObject.Find ("def_mouthup0_R").transform;
		if (mouthUpRight1 == null) mouthUpRight1 = GameObject.Find ("def_mouthup1_R").transform;
		if (mouthUpRight2 == null) mouthUpRight2 = GameObject.Find ("def_mouthup2_R").transform;
		if (mouthUpRight3 == null) mouthUpRight3 = GameObject.Find ("mch_lip3_R").transform;
		if (mouthUpRight4 == null) mouthUpRight4 = GameObject.Find ("mch_lip4_R").transform;
		if (lipLeft1 == null) lipLeft1 = GameObject.Find ("def_lip1_L_001").transform;
		if (lipLeft4 == null) lipLeft4 = GameObject.Find ("def_lip4_L").transform;
		if (lipRight1 == null) lipRight1 = GameObject.Find ("def_lip1_R_001").transform;
		if (lipRight4 == null) lipRight4 = GameObject.Find ("def_lip4_R").transform;

		if (eyeLeftDown1 == null) eyeLeftDown1 = GameObject.Find ("def_eye1d_L").transform;
		if (eyeLeftDown2 == null) eyeLeftDown2 = GameObject.Find ("def_eye2d_L").transform;
		if (eyeLeftDown3 == null) eyeLeftDown3 = GameObject.Find ("def_eye3d_L").transform; 
		if (eyeLeftDown4 == null) eyeLeftDown4 = GameObject.Find ("def_eye4d_L").transform;
		if (eyeLeftDown5 == null) eyeLeftDown5 = GameObject.Find ("def_eye5d_L").transform;
		if (eyeLeftDown6 == null) eyeLeftDown6 = GameObject.Find ("def_eye6d_L").transform;
		if (eyeLeftUp1 == null) eyeLeftUp1 = GameObject.Find ("def_eye1u_L").transform;
		if (eyeLeftUp2 == null) eyeLeftUp2 = GameObject.Find ("def_eye2u_L").transform;
		if (eyeLeftUp3 == null) eyeLeftUp3 = GameObject.Find ("def_eye3u_L").transform;
		if (eyeLeftUp4 == null) eyeLeftUp4 = GameObject.Find ("def_eye4u_L").transform;
		if (eyeLeftUp5 == null) eyeLeftUp5 = GameObject.Find ("def_eye5u_L").transform;
		if (eyeLeftUp6 == null) eyeLeftUp6 = GameObject.Find ("def_eye6u_L").transform;
	
		if (eyeRightDown1 == null) eyeRightDown1 = GameObject.Find ("def_eye1d_R").transform;
		if (eyeRightDown2 == null) eyeRightDown2 = GameObject.Find ("def_eye2d_R").transform;
		if (eyeRightDown3 == null) eyeRightDown3 = GameObject.Find ("def_eye3d_R").transform;
		if (eyeRightDown4 == null) eyeRightDown4 = GameObject.Find ("def_eye4d_R").transform;
		if (eyeRightDown5 == null) eyeRightDown5 = GameObject.Find ("def_eye5d_R").transform;
		if (eyeRightDown6 == null) eyeRightDown6 = GameObject.Find ("def_eye6d_R").transform;
		if (eyeRightUp1 == null) eyeRightUp1 = GameObject.Find ("def_eye1u_R").transform;
		if (eyeRightUp2 == null) eyeRightUp2 = GameObject.Find ("def_eye2u_R").transform;
		if (eyeRightUp3 == null) eyeRightUp3 = GameObject.Find ("def_eye3u_R").transform;
		if (eyeRightUp4 == null) eyeRightUp4 = GameObject.Find ("def_eye4u_R").transform;
		if (eyeRightUp5 == null) eyeRightUp5 = GameObject.Find ("def_eye5u_R").transform;
		if (eyeRightUp6 == null) eyeRightUp6 = GameObject.Find ("def_eye6u_R").transform;
	}

	// TODO not needed
	public void resetEyebrows() {
		// Rise eyebrows up
		eyebrowLeftRoot.Translate (eyebrowLeftRoot.position - eyebrowLeftRootInitPosition);
		eyebrowRightRoot.Translate (eyebrowRightRoot.position - eyebrowRightRootInitPosition);
	}

	public void updateEyebrows(float shift) {
		eyebrowLeftRoot.position = eyebrowLeftRootInitPosition;
		eyebrowLeftRoot.position += new Vector3 (0f, (shift * 0.1f), 0f);
	}

	public void riseEyebrows() {
		// Rise eyebrows up
		eyebrowLeftRoot.Translate (Vector3.forward * 0.1f);
		eyebrowRightRoot.Translate (Vector3.forward * 0.1f);
	}

	void openMouth() {
		// Open mouth - TODO Fix Mouth
		mouthDownLeft.Translate (Vector3.back * 0.1f); 
		mouthDownRight.Translate (Vector3.back * 0.1f);
		
		mouthUpLeft0.Translate (Vector3.forward * 0.1f); 
		mouthUpLeft1.Translate (Vector3.forward * 0.1f); 
		mouthUpLeft2.Translate (Vector3.forward * 0.1f); 
		mouthUpLeft3.Translate (Vector3.forward * 0.1f); 
		mouthUpLeft4.Translate (Vector3.forward * 0.1f);
		mouthUpRight0.Translate (Vector3.forward * 0.1f); 
		mouthUpRight1.Translate (Vector3.forward * 0.1f); 
		mouthUpRight2.Translate (Vector3.forward * 0.1f); 
		mouthUpRight3.Translate (Vector3.forward * 0.1f); 
		mouthUpRight4.Translate (Vector3.forward * 0.1f);
		lipLeft1.Translate (Vector3.forward * 0.1f); 
		lipLeft4.Translate (Vector3.forward * 0.1f);
		lipRight1.Translate (Vector3.forward * 0.1f);
		lipRight4.Translate (Vector3.forward * 0.1f);
		
		mouthDownMiddleLeft2.Translate (Vector3.back * 0.1f); 
		mouthDownMiddleRight2.Translate (Vector3.back * 0.1f); 
		
		mouthUpMiddleLeft3.Translate (Vector3.forward * 0.1f); 
		mouthUpMiddleRight3.Translate (Vector3.forward * 0.1f); 
	}

	void closeEyes() {
		float eyeRatio = 0.01f;
		eyeLeftDown1.Translate (Vector3.back * eyeRatio);
		eyeLeftDown2.Translate (Vector3.back * eyeRatio);
		eyeLeftDown3.Translate (Vector3.back * eyeRatio);
		eyeLeftDown4.Translate (Vector3.back * eyeRatio);
		eyeLeftDown5.Translate (Vector3.back * eyeRatio);
		eyeLeftDown6.Translate (Vector3.back * eyeRatio);
		eyeLeftUp1.Translate (Vector3.forward * eyeRatio);
		eyeLeftUp2.Translate (Vector3.forward * eyeRatio);
		eyeLeftUp3.Translate (Vector3.forward * eyeRatio);
		eyeLeftUp4.Translate (Vector3.forward * eyeRatio); 
		eyeLeftUp5.Translate (Vector3.forward * eyeRatio);
		eyeLeftUp6.Translate (Vector3.forward * eyeRatio);
		
		eyeRightDown1.Translate (Vector3.back * eyeRatio);
		eyeRightDown2.Translate (Vector3.back * eyeRatio);
		eyeRightDown3.Translate (Vector3.back * eyeRatio);
		eyeRightDown4.Translate (Vector3.back * eyeRatio);
		eyeRightDown5.Translate (Vector3.back * eyeRatio);
		eyeRightDown6.Translate (Vector3.back * eyeRatio);
		eyeRightUp1.Translate (Vector3.forward * eyeRatio);
		eyeRightUp2.Translate (Vector3.forward * eyeRatio);
		eyeRightUp3.Translate (Vector3.forward * eyeRatio); 
		eyeRightUp4.Translate (Vector3.forward * eyeRatio);
		eyeRightUp5.Translate (Vector3.forward * eyeRatio);
		eyeRightUp6.Translate (Vector3.forward * eyeRatio);
	}
	
	public void init() {
		holmanAdvancedSetup ();
	}
}
