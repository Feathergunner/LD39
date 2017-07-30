using UnityEngine;
using System.Collections;

public class World{

	//WorldController wc;
	
	Tile[,] tiles;
	//int size_x;
	//int size_y;
	
	public World(int size_x, int size_y, int prob_energy, int prob_data)
	{
		//this.size_x = size_x;
		//this.size_y = size_y;
		
		tiles = new Tile[size_x, size_y];
		// Create world
		for (int i_x=0; i_x<size_x; i_x++)
		{
			for (int i_y=0; i_y<size_y; i_y++)
			{
				int type = 0;
				int dice_type = Random.Range (0, 100);
				if (dice_type < prob_energy)
					type = 1;
				else if (dice_type < prob_energy+prob_data)
					type = 2;
				tiles[i_x, i_y] =  new Tile(type);
			}
		}
		
		Vector3 cam_position = new Vector3(size_x/2, size_y/2, -10);
		Camera.main.transform.Translate(cam_position);
		Camera.main.orthographicSize = 7;
	}
	
	public int get_tile_type_at(int x, int y)
	{
		//Debug.Log ("Tile at "+x+","+y+" has type "+tiles[x, y].get_type());
		return tiles[x, y].get_type();
	}
	
	public void reset_tile_type_at(int x, int y)
	{
		tiles[x, y].reset_type();
	}
}
