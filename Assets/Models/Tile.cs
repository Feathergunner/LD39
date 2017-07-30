using UnityEngine;
using System.Collections;

public class Tile {

	/*
	World world;
	int pos_x;
	int pos_y;
	*/
	int type;
	
	/*
	tpye = 0: floor
	type = 1: energy
	type = 2: data
	*/
	
	//public Tile(World world, int pos_x, int pos_y, int type)
	public Tile(int type)
	{
		/*
		this.world = world;
		this.pos_x = pos_x;
		this.pos_y = pos_y;
		*/
		this.type = type;
	}
	
	public int get_type()
	{
		return type;
	}
	
	public void reset_type()
	{
		type = 0;
	}
}
