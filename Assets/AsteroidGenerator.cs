using UnityEngine;
using System.Collections;

public class AsteroidGenerator : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	bool[] vertexStatus;
	float threshold = 0.5f;

	float rangeX = 0.1f;
	float rangeY = 0.1f;
	float rangeZ = 0.1f;

	// Use this for initialization
	void Start () {

		rangeX = Random.Range (0.0f,1.0f);
		rangeX *= rangeX;
		rangeY = Random.Range (0.0f,1.0f);
		rangeY *= rangeY;
		rangeZ = Random.Range (0.0f,1.0f);
		rangeZ *= rangeZ;

		mesh = GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;
		vertexStatus = new bool[vertices.Length];

//		vertices[0].x += Random.Range(-0.1f,0.10f)*vertices[0].x;
//		vertices[0].y += Random.Range(-0.1f,0.10f)*vertices[0].y;
//		vertices[0].z += Random.Range(-0.1f,0.10f)*vertices[0].z;
		for (int i=0; i<vertices.Length; i++)	{
			vertexStatus[i] = false;
		}
		for (int i=0; i<vertices.Length; i++)	{
			float rx = Random.Range(rangeX * -1.0f,rangeX);
			float ry = Random.Range(rangeY * -1.0f,rangeY);
			float rz = Random.Range(rangeZ * -1.0f,rangeZ);
//			vertices[i].x += Random.Range(-0.1f,0.10f)*vertices[i].x;
//			vertices[i].y += Random.Range(-0.1f,0.10f)*vertices[i].y;
//			vertices[i].z += Random.Range(-0.1f,0.10f)*vertices[i].z;
			int j=0;
			while(j<vertices.Length)	{
				if( withinThreshold(vertices[i].x, vertices[j].x - threshold, vertices[j].x + threshold)
				   && withinThreshold(vertices[i].y, vertices[j].y - threshold, vertices[j].y + threshold)
				   && withinThreshold(vertices[i].z, vertices[j].z - threshold, vertices[j].z + threshold)
				   && !vertexStatus[j])	{
					print ("found equal vertex");

					vertices[j].x += (rx*vertices[j].x);
					vertices[j].y += (ry*vertices[j].y);
					vertices[j].z += (rz*vertices[j].z);

					vertexStatus[j] = true;
				}
				j++;
			}
		}

		mesh.vertices = vertices;
		mesh.RecalculateBounds();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool withinThreshold(float input, float min, float max)	{

		return ( input <= max && input >= min);

	}
}
