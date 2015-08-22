using UnityEngine;
using System.Collections;

public class ParticleGenerator : MonoBehaviour {

	// publics

	public GameObject particle;

	// privates :-o

	GameObject[] particles;
	const int maxParticles = 2000;
	Camera cam;
	Vector3 spawnPerimeter = new Vector3(1000,50,1000);
	float killDistance;

	// Use this for initialization
	void Start () {

		killDistance = Mathf.Sqrt( spawnPerimeter.x*spawnPerimeter.x
		                          + spawnPerimeter.y*spawnPerimeter.y
		                          + spawnPerimeter.z*spawnPerimeter.z );

		particles = new GameObject[maxParticles];
		cam = Camera.main;

		for(int p=0;p<maxParticles;p++)	{
			particles[p] = Instantiate (particle) as GameObject;
			placeParticleRandomly(p);
		}

	}
	
	// Update is called once per frame
	void Update () {

		for(int p=0;p<maxParticles;p++)	{
			float camDist = Vector3.Distance(cam.transform.position,particles[p].transform.position);
			//print (camDist + " " + killDistance);
			if(camDist >= killDistance)	{
				placeParticle(p);
			}
		}

	}

	private void placeParticleRandomly(int index)	{
		particles[index].transform.position = new Vector3(Random.Range(spawnPerimeter.x*-1.0f,spawnPerimeter.x)
		                                                  ,Random.Range(spawnPerimeter.y*-1.0f,spawnPerimeter.y)
		                                                  ,Random.Range(spawnPerimeter.z*-1.0f,spawnPerimeter.z));
	}

	private void placeParticle(int index)	{

		particles[index].transform.Rotate ( Random.Range (0.0f,360.0f)
		                                   ,Random.Range (0.0f,360.0f)
		                                   ,Random.Range (0.0f,360.0f));


		if(Vector3.Dot(cam.velocity,cam.transform.forward) > 0)	{
			particles[index].transform.position = cam.transform.position+cam.transform.forward * spawnPerimeter.z;
//			particles[index].transform.position = cam.transform.position+cam.velocity * spawnPerimeter.z;
		} else {
			particles[index].transform.position = cam.transform.position+cam.transform.forward * spawnPerimeter.z * -1.0f;
		}
		float randomX = Random.Range(-1.0f,1.0f);
		float randomY = Random.Range(-1.0f,1.0f);
		particles[index].transform.Translate (cam.transform.up * randomY*randomY*spawnPerimeter.y);
		particles[index].transform.Translate (cam.transform.right * randomX*randomX*spawnPerimeter.x);

		// FIXME: SPAWN STARS TO THE SIDE AS WELL

		//particles[index].transform.Translate (cam.velocity.x);

	}
}














