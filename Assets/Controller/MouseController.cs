using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public GameObject cursor;
	public GameObject cursor_select;
	
	public WorldController wc;
	
	Vector3 last_cursor_position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 curr_frame_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 cursor_position = new Vector3((int)(curr_frame_position.x), (int)(curr_frame_position.y+1), -1);
		
		if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
		{
			if (cursor_position != last_cursor_position)
			{
				if (cursor_position.x >= 0 && cursor_position.x < wc.world_size && cursor_position.y >= 0 && cursor_position.y < wc.world_size)
				{
					cursor.transform.position = cursor_position;
					//tile_under_cursor = wc.get_world().get_tile_at((int)Mathf.Floor(cursor_position.x), (int)Mathf.Floor(cursor_position.y));
				}
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (cursor_position.x >= 0 && cursor_position.x < wc.world_size && cursor_position.y >= 0 && cursor_position.y < wc.world_size)
				{
					//Debug.Log ("Selected position "+cursor_position.x+","+cursor_position.y);
					cursor_select.transform.position = cursor_position;
					wc.set_player_target(cursor_position);
				}
			}
		}
		
	}
	
	public Vector2 get_selection_position()
	{
		return new Vector2(cursor_select.transform.position.x, cursor_select.transform.position.y);
	}
}
