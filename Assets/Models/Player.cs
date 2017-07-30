using UnityEngine;
using System.Collections;

using System;
using Random = UnityEngine.Random;


public class Player{
	
	World w;
	
	int pos_x;
	int pos_y;
	
	int target_x;
	int target_y;
	
	int energy;
	int data;
	int points;
	
	int max_energy = 1000;
	int max_data = 100;
	
	int view_distance;
	int view_level;
	int difficulty;
	
	bool submit;
	
	public Player(int pos_x, int pos_y, World w, int diff)
	{
		this.pos_x = pos_x;
		this.pos_y = pos_y;
		this.w = w;
		target_x = pos_x;
		target_y = pos_y;
		
		submit = false;
		
		view_distance = 5;
		view_level = 1;
		
		energy = 1000;
		data = 0;
		points = 0;
		difficulty = diff;
	}
	
	public int get_view_distance(){
		return view_distance;
	}
	
	public int get_visibility_level(int tile_x, int tile_y){
		if (Math.Abs(tile_x-pos_x) + Math.Abs(tile_y-pos_y) - 1 < view_distance)
		{
			//Debug.Log("cell "+tile_x+","+tile_y+"can be seen");
			return view_level;
		}
		else
		{
			//Debug.Log("cell "+tile_x+","+tile_y+"is dark");
			return -1;
		}
		
	}
	
	public void set_view_distance(int level)
	{
		if (level >= 0 && level <= 5)
		{
			view_distance = level;
		}
	}
	
	public void set_target(int t_x, int t_y)
	{
		target_x = t_x;
		target_y = t_y;
	}
	
	public void move()
	{		
		apply_energy_costs(get_walking_costs());
		
		pos_x = target_x;
		pos_y = target_y;
	}
	
	public int get_walking_costs()
	{
		int travel_distance = Math.Abs (pos_x-target_x) + Math.Abs (pos_y-target_y);
		
		return travel_distance * 10;
	}
	
	public int get_light_costs()
	{
		return (difficulty-1)*5+view_distance*view_distance*view_level*2;
	}
	
	public int get_submit_costs()
	{
		return 40+(10*difficulty)+(1+difficulty)*data;
	}
	
	void apply_light_costs()
	{
		apply_energy_costs(get_light_costs());
	}
	
	void apply_energy_costs(int costs)
	{
		energy -= costs;
	}
	
	public void award_points(int award)
	{
		points += award;
	}
	
	public Vector3 get_position()
	{
		return new Vector3(pos_x, pos_y, -1);
	}
	
	void submit_data()
	{
		if (energy > get_submit_costs())
		{
			points += data;
			apply_energy_costs(get_submit_costs());
			data = 0;
		}
	}
	
	public void update_at_end_of_turn()
	{
		/*
		Debug.Log ("Current position is: "+pos_x+","+pos_y);
		Debug.Log ("Target position is: "+target_x+","+target_y);
		Debug.Log ("Target tile has type: "+target_tile_type);
		*/
		move();
		apply_light_costs();
		if (w.get_tile_type_at(pos_x, pos_y) == 1)
		{
			//Debug.Log ("Refill energy");
			energy += Random.Range(80, 100);
			if (energy > max_energy)
				energy = max_energy;
		}
		else if (w.get_tile_type_at(pos_x, pos_y)  == 2)
		{
			//Debug.Log ("Gather data");
			data += Random.Range(3, 10);
			if (data > max_data)
				data = max_data;
		}
		
		if (submit)
			submit_data();		
	}
	
	public bool check_player_energy()
	{
		if (energy > 0)
			return true;
		else
			return false;
	}
	
	public int get_energy()
	{
		return energy;
	}
	
	public int get_max_energy()
	{
		return max_energy;
	}
	
	public int get_data()
	{
		return data;
	}
	
	public int get_max_data()
	{
		return max_data;
	}
		
	public int get_points()
	{
		return points;
	}
	
	public bool get_toggle_submit()
	{
		return submit;
	}
	
	public void toggle_submit()
	{
		if (submit)
			submit = false;
		else
			submit = true;
	}
}
