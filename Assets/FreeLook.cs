using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class FreeLook : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	Transform myShip;
	float rotationY = 0F;

//	AudioSource laserFireSound;

	void Start ()
	{
		//if(!networkView.isMine)
		//enabled = false;
		myShip = transform.parent;//GameObject.Find ("SpaceshipPrefab
		// Make the rigid body not change rotation
		//if (rigidbody)
		//rigidbody.freezeRotation = true;
//		laserFireSound = GameObject.Find ("laserFire").GetComponent<AudioSource> ();
	}

	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}

//		if (Input.GetMouseButtonDown (0)) {
//			//spawn lazor
//			GameObject l = Instantiate(Resources.Load ("lazorColl"), myShip.position - myShip.up*0.0f,this.transform.rotation) as GameObject;
//			//raycast
//			Vector3 forwardPoint = this.transform.position + this.transform.forward*1000.0f;
//			l.transform.LookAt(forwardPoint);
//			l.GetComponent<LaserMove>().setInitialVelocityMagnitude( GetComponentInParent<SpaceshipController>().getFinalVelocity());
//
//			laserFireSound.pitch = Random.value + 0.5f;
//			laserFireSound.Play();
//
//			//pew pew!
//
//
//		}
	}
	

}