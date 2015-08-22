using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour {

	float vel = 0.0f;
	float accel = 1000.0f;
	float deccel = 0.98f;
	float maxVel = 1000.0f;

	float sideVel = 0.0f;
	float sideAccel = 1000.0f;
	float sideDeccel = 0.95f;

	float boostVel = 0.0f;
	float boostAccel = 100.0f;
	float boostDeccel = 0.9f;
	bool boost = false;

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

//		if(Input.GetKeyDown("w") && vel <= 100 && vel >= -100)	{
//			vel += 300;
//		}

		// BOOST

		boost = false;
		if(Input.GetKey (KeyCode.Space))	{
			boost = true;
			boostVel += boostAccel;
		}

		boostVel *= boostDeccel;

		// FORWARD / BACKWARD MVMT

		if(Input.GetKey ("w"))	{
			vel += Time.deltaTime * accel;
		} else if(Input.GetKey ("s"))	{
			vel -= Time.deltaTime * accel;
		} else {
			vel *= deccel;
		}

		if(vel>=maxVel)
			vel = maxVel;
		if(vel<=maxVel*-1.0f)
			vel = maxVel * -1.0f;

		transform.Translate(transform.forward*Time.deltaTime*(vel+boostVel*(vel/maxVel)));

		// SIDE MVMT

		if(Input.GetKey ("d"))	{
			sideVel += Time.deltaTime * sideAccel;
		}
		if(Input.GetKey ("a"))	{
			sideVel -= Time.deltaTime * sideAccel;
		}

		sideVel *= sideDeccel;

		float maxSideVel = 1000;

		if(sideVel>=maxSideVel)
			sideVel = maxSideVel;
		if(sideVel<=maxSideVel * -1.0f)
			sideVel = maxSideVel * -1.0f;


//		transform.Translate (transform.right * Time.deltaTime * sideVel);

		transform.Translate ( Vector3.right * Time.deltaTime * sideVel, Space.World);

		transform.rotation = Quaternion.Euler(0,0,sideVel/maxSideVel * -60.0f);

	}

	public bool isBoosting()	{
		return boost;
	}

	public float getBoostVelNormalized()	{
		return (boostVel*(vel/maxVel))/1000.0f;
//		return boostVel / 1000.0f;
	}

}
























