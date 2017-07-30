using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

public float move_speed = 10.0f;

	private bool is_moving;
	private Vector3 last_position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetMouseButton(1))
		 {
		 	if (is_moving)
			{
				Vector3 mouse_diff = Camera.main.ScreenToViewportPoint(last_position-Input.mousePosition);//Camera.main.ScreenToViewportPoint(Input.mousePosition-last_position);
				Vector3 movement = new Vector3(mouse_diff.x*move_speed, mouse_diff.y*move_speed, 0);
				Camera.main.transform.Translate(movement, Space.Self);
		 	}
			last_position = Input.mousePosition;
		 	is_moving = true;
		 }
		 else
		 {
			is_moving = false;
		 }
	
	}
}
