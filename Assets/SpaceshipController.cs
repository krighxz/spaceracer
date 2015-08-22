using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class SpaceshipController : NetworkBehaviour {

	float vel = 0.0f;
	float accel = 100.0f;
	float deccel = 0.98f;
	float maxVel = 100.0f;
	float finalVel = 0;

	float sideVel = 0.0f;
	float sideAccel = 1000.0f;
	float sideDeccel = 0.95f;

	float boostVel = 0.0f;
	float boostAccel = 100.0f;
	float boostDeccel = 0.9f;
	bool boost = false;

	AudioSource engineSound;
	AudioSource engineBeep;


	// Use this for initialization
	void Start () {


		engineSound = GameObject.Find ("engineSound").GetComponent<AudioSource> ();
		engineBeep = GameObject.Find ("engineBeep").GetComponent<AudioSource> ();

		if (isLocalPlayer) {
			Camera.main.transform.position = transform.position - new Vector3(0,-5,5);
			Camera.main.transform.SetParent(transform);
		}
	}


	// Update is called once per frame
	void FixedUpdate () {

		if (isLocalPlayer) {

			boost = false;
			if (Input.GetKey (KeyCode.Space)) {
				boost = true;
				boostVel += boostAccel;
			}

			boostVel *= boostDeccel;

			// FORWARD / BACKWARD MVMT

			if (Input.GetKey ("w")) {
				vel += Time.deltaTime * accel;
			} else if (Input.GetKey ("s")) {
				vel -= Time.deltaTime * accel;
			} else {
				vel *= deccel;
			}

			if (vel >= maxVel)
				vel = maxVel;
			if (vel <= maxVel * -1.0f)
				vel = maxVel * -1.0f;

			finalVel = (vel + boostVel * (vel / maxVel));

			engineSound.volume = finalVel / 1000f;
			engineSound.pitch = finalVel / 200f + 0.5f;
			transform.Translate (transform.forward * Time.deltaTime * finalVel);

			engineBeep.volume = Mathf.Pow (finalVel / 2500f, 2f);
			engineBeep.pitch = finalVel / 500f + 0.5f;
			transform.Translate (transform.forward * Time.deltaTime * finalVel);

			// SIDE MVMT

			if (Input.GetKey ("d")) {
				sideVel += Time.deltaTime * sideAccel;
			}
			if (Input.GetKey ("a")) {
				sideVel -= Time.deltaTime * sideAccel;
			}

			sideVel *= sideDeccel;

			float maxSideVel = 1000;

			if (sideVel >= maxSideVel)
				sideVel = maxSideVel;
			if (sideVel <= maxSideVel * -1.0f)
				sideVel = maxSideVel * -1.0f;


//		transform.Translate (transform.right * Time.deltaTime * sideVel);

			transform.Translate (Vector3.right * Time.deltaTime * sideVel, Space.World);

			transform.rotation = Quaternion.Euler (0, 0, sideVel / maxSideVel * -60.0f);
		}
	}

	public bool isBoosting()	{
		return boost;
	}

	public float getBoostVelNormalized()	{
		return (boostVel*(vel/maxVel))/1000.0f;
//		return boostVel / 1000.0f;
	}

	public float getFinalVelocity()	{
		return finalVel;
	}

}
























