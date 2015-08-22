using UnityEngine;
using System.Collections;

public class BgEnvironmentController : MonoBehaviour {

	public GameObject planet;

	const int numPlanets = 1;
	GameObject[] planets;
	Vector3[] planetPositions;

	// Use this for initialization
	void Awake () {

		planets = new GameObject[numPlanets];
		planetPositions = new Vector3[numPlanets];

		for(int p=0;p<numPlanets;p++)	{
			planets[p] = Instantiate(planet) as GameObject;
			planetPositions[p] = new Vector3( 0, -1025, 0 );
			planets[p].transform.position = planetPositions[p];
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {

		for(int p=0;p<numPlanets;p++)	{
			planets[p].transform.position = new Vector3( planetPositions[p].x + transform.position.x
			                                            , planetPositions[p].y
			                                            , planetPositions[p].z + transform.position.z );
		}

	}
}
