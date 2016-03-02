using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour {
	/// <summary>
	/// Public Variables
	public GameObject cubePreFab;
	public List<GameObject> cubeList;
	public int numCubes = 0;
	public float scalingFactor = 0.95f;
	/// </summary>

	void start(){
		cubeList = new List<GameObject> ();
	}
	void Update () {
		GameObject cube = Instantiate (cubePreFab) as GameObject;
		cubeList.Add (cube);
		numCubes++;
		cube.name = "Cube " + numCubes;
		Color color = new Color(Random.value, Random.value, Random.value);
		MeshRenderer gameObjectRenderer = cube.GetComponent<MeshRenderer> ();
		Material cubeMaterial = new Material (Shader.Find("Diffuse"));
		cubeMaterial.color = color;
		gameObjectRenderer.material = cubeMaterial;
		cube.transform.position = Random.insideUnitSphere;
		List<GameObject> removeCubeList = new List<GameObject>();
		foreach (GameObject cObj in cubeList){
			cObj.transform.localScale *= scalingFactor;
			if(cObj.transform.localScale.x<0.1f){
				removeCubeList.Add(cObj);
			}
		}
		foreach (GameObject gObj in removeCubeList) {
			cubeList.Remove(gObj);
			Destroy(gObj);
		}
	}
}
