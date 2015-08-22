using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

//[RequireComponent (typeof (MotionBlur))]
//[RequireComponent (typeof (Fisheye))]
//[RequireComponent (typeof (DepthOfField))]
[RequireComponent (typeof (SpaceshipController))]
public class CameraEffectController : MonoBehaviour {

	//public GameObject parentSpaceship;
	SpaceshipController spaceshipController;

	MotionBlur motionBlurFilter;
	Fisheye fisheye;
	DepthOfField depthOfField;

	// Use this for initialization
	void Start () {

		motionBlurFilter = Camera.main.GetComponent<MotionBlur>();
		fisheye = Camera.main.GetComponent<Fisheye>();
		depthOfField = Camera.main.GetComponent<DepthOfField>();
		spaceshipController = GetComponent<SpaceshipController>();

	}
	
	// Update is called once per frame
	void Update () {

		motionBlurFilter.blurAmount = spaceshipController.getBoostVelNormalized() * 0.5f;
		fisheye.strengthX = spaceshipController.getBoostVelNormalized() * 0.5f;
		fisheye.strengthY = fisheye.strengthX;
		depthOfField.focalLength = map (spaceshipController.getBoostVelNormalized()
		                                ,0,1
		                                ,0.3f,0.1f);
		depthOfField.aperture = map (spaceshipController.getBoostVelNormalized()
		                             ,0,1
		                             ,5,7.5f);

	}

	float map(float x, float in_min, float in_max, float out_min, float out_max)
	{
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}
