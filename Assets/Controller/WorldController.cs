using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

	public int world_size;
	
	public Sprite sprite_black;
	public Sprite sprite_ground;
	
	public Sprite sprite_energy;
	public Sprite sprite_data;
	
	public Sprite sprite_player;
	
	//public GameObject player_prefab;
	
	public UIController uic;
	
	World world;
	
	GameObject player_go;
	Player player;
	
	GameObject [,] tile_go;
	
	int turn;

	// Use this for initialization
	void Start () {
		world = new World(world_size, world_size, 4, 8);
		//player = new Player(10,10);
		
		turn = 0;
		
		// Create a Gameobject for each tile
		tile_go = new GameObject[world_size, world_size];
		for (int i_x=0; i_x<world_size; i_x++)
		{
			for (int i_y=0; i_y<world_size; i_y++)
			{
				tile_go[i_x, i_y] = new GameObject();
				
				tile_go[i_x, i_y].name = "Tile_"+i_x+"_"+i_y;
				tile_go[i_x, i_y].transform.position = new Vector3(i_x, i_y, 0);
				tile_go[i_x, i_y].AddComponent<SpriteRenderer>();
			}
		}
		
		//GameObject player_go = (GameObject)Instantiate(player_prefab, player_position, player_prefab.transform.rotation);
		
		player_go = new GameObject();
		player_go.name = "PLAYER";
		SpriteRenderer player_sr = player_go.AddComponent<SpriteRenderer>();
		player_sr.sprite = sprite_player;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void set_light(){
		player.set_view_distance(uic.get_light_slider_value());
		uic.update_text_energy_light(player.get_light_costs());
	}
	
	public void set_player_target(Vector3 cursor_select_position){
		if (cursor_select_position.x >= 0 && cursor_select_position.x < world_size && cursor_select_position.y >= 0 && cursor_select_position.y < world_size)
		{
			player.set_target((int)cursor_select_position.x, (int)cursor_select_position.y);
		}
		uic.update_text_energy_walking(player.get_walking_costs());
	}
	
	public void toggle_submit()
	{
		player.toggle_submit();
		if (player.get_toggle_submit())
			uic.update_text_energy_submit(player.get_submit_costs());
		else
			uic.update_text_energy_submit(0);
	}
	
	public void next_Turn(){
		turn++;
		
		player.update_at_end_of_turn();
		player_go.transform.position = player.get_position();
		
		uic.update_player_bars(player.get_energy(), player.get_data(), player.get_points(), player.get_max_energy(), player.get_max_data());
		uic.update_text_energy_walking(0);
		
		uic.reset_toggles();
		
		if (world.get_tile_type_at((int)player.get_position().x,(int)player.get_position().y) > 0)
			world.reset_tile_type_at((int)player.get_position().x,(int)player.get_position().y);
		
		render_world_tiles();
		
		if (!player.check_player_energy())
		{
			// RUNNING OUT OF ENERGY! GAME OVER!
			uic.display_gameover_infos(player.get_points(), turn);
		}
	}
	
	void render_world_tiles()
	{
		for (int i_x=0; i_x<world_size; i_x++)
		{
			for (int i_y=0; i_y<world_size; i_y++)
			{
				int tile_status = player.get_visibility_level(i_x, i_y);
				if (tile_status < 0)
				{
					tile_go[i_x, i_y].GetComponent<SpriteRenderer>().sprite = sprite_black;
				}
				else if (tile_status == 1)
				{
					if (world.get_tile_type_at(i_x, i_y) == 1)
						tile_go[i_x, i_y].GetComponent<SpriteRenderer>().sprite = sprite_energy;
					else if (world.get_tile_type_at(i_x, i_y) == 2)
						tile_go[i_x, i_y].GetComponent<SpriteRenderer>().sprite = sprite_data;
					else
						tile_go[i_x, i_y].GetComponent<SpriteRenderer>().sprite = sprite_ground;
				}
			}
		}
	}
	
	public void start_game()
	{
		uic.close_menu_panel();
		Vector3 player_position = new Vector3(world_size/2, world_size/2, -1);
		player_go.transform.position = player_position;
		player = new Player((int)player_position.x, (int)player_position.y, world);
		uic.update_player_bars(player.get_energy(), player.get_data(), player.get_points(), player.get_max_energy(), player.get_max_data());
		render_world_tiles();
	}
	
	public void button_quit_game()
	{
		Application.Quit ();
	}
}
