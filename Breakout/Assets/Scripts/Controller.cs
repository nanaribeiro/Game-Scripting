using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//get current screen position of mouse from input
		Vector3 mousePos2D = Input.mousePosition;
		
		//cameras z position sets how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z;
		
		//convert the point from 2D screen into 3D gameworld space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		
		//move the x position of the paddle to the pos of the mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

}

}