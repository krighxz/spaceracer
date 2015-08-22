using UnityEngine;
using System.Collections;

public class PlanetOrbit : MonoBehaviour {
	GameObject parentPlanet;

	// Use this for initialization
	void Start () {
		parentPlanet = GameObject.Find ("bigPlanet");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (Mathf.Cos (Time.time*0.1f) * 159.0f, 0f, Mathf.Sin (Time.time*0.1f)*150f);
		this.transform.position += parentPlanet.transform.position;
	}
}
