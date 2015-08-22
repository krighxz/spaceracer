using UnityEngine;
using System.Collections;

public class LaserMove : MonoBehaviour {

	bool mustKill = false;
	float randOffset = 0.0f;
	// Use this for initialization
	void Start () {
		randOffset = Random.value*100.0f;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position += this.transform.forward * 2.4f;
		this.transform.LookAt (this.transform.position + (this.transform.forward*4.0f + this.transform.up*Mathf.Cos (Time.time*10.0f + randOffset)*0.1f + this.transform.right*Mathf.Cos (Time.time*10.0f + randOffset)*0.1f));//new Vector3(Mathf.Cos (Time.time*10.0f + randOffset)*0.1f, Mathf.Sin (Time.time*10.0f +randOffset)*0.1f, Mathf.Sin (Time.time*10.0f +randOffset)*0.1f)) );

		GameObject playerLoc = GameObject.Find ("playerAndCockpit");
	
		if (Vector3.Distance (this.transform.position, playerLoc.transform.position) > 300.0f) {
			mustKill = true;	
			Destroy (this.gameObject);
		}
	}


}
