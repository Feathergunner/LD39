using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject panel_right;
	public GameObject panel_top;
	public GameObject panel_main;
	
	int panel_top_width;
	int panel_top_height;
	
	int panel_right_width;
	int panel_right_height;
	
	int panel_main_width;
	int panel_main_height;
	
	GameObject go_panel_gameover;
	
	GameObject go_text_energy;
	GameObject go_text_data;
	GameObject go_text_points;
	
	GameObject go_slider_light;
	GameObject go_button_nextturn;
	GameObject go_text_title;
	GameObject go_text_walking;
	GameObject go_text_light;
	GameObject go_toggle_scanner;
	GameObject go_toggle_ui;
	GameObject go_text_energyneed;
	GameObject go_toggle_submit;
	
	int energy_walking;
	int energy_light;
	int energy_submit;

	// Use this for initialization
	void Start () {
		/*
		int screen_width = 800;
		int screen_height = 600;
		Screen.SetResolution(screen_width, screen_height, true);
		*/
		
		energy_walking = 0;
		energy_light = 50;
		energy_submit = 0;
		
		/*
		INITIALIZE TOP PANEL
		*/
		
		panel_top_width = 4*Screen.width/5;
		panel_top_height = Screen.height/8;
		panel_top.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_top_width, panel_top_height);
		panel_top.GetComponent<RectTransform>().transform.Translate(0, 7*panel_top_height, -1);
		
		go_text_energy = panel_top.transform.Find("Text_ENERGY").gameObject;
		go_text_data = panel_top.transform.Find("Text_DATA").gameObject;	
			
		go_text_energy.transform.Translate(panel_top_width/20, 3*panel_top_height/5, -1);
		go_text_energy.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_top_width/3, panel_top_height/5);
		go_text_energy.GetComponent<Text>().text = "ENERGY:";
		go_text_energy.GetComponent<Text>().fontSize = panel_top_height/6;
		
		go_text_data.transform.Translate(panel_top_width/20, panel_top_height/5, -1);
		go_text_data.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_top_width/3, panel_top_height/5);
		go_text_data.GetComponent<Text>().text="DATA:";
		go_text_data.GetComponent<Text>().fontSize = panel_top_height/6;
		
		go_text_points = panel_top.transform.Find("Text_POINTS").gameObject;
		go_text_points.transform.Translate(4*panel_top_width/5, panel_top_height/4, -1);
		go_text_points.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_top_width/5, panel_top_height/2);
				
		/*
		INITIALIZE RIGHT PANEL
		*/
		
		panel_right_width = Screen.width/5;
		panel_right_height = Screen.height;
		
		panel_right.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_right_width, panel_right_height);
		panel_right.GetComponent<RectTransform>().transform.Translate(4*panel_right_width, 0, -1);
		
		go_slider_light = panel_right.transform.Find("Slider_LIGHT").gameObject;
		go_slider_light.transform.Translate(panel_right_width/6, 10*panel_right_height/20,-1);
		go_slider_light.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_right_width/10, 5*panel_right_height/20);
		
		go_button_nextturn = panel_right.transform.Find("Button_NEXTTURN").gameObject;
		go_button_nextturn.transform.Translate(panel_right_width/4, panel_right_height/20, -1);
		go_button_nextturn.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_right_width/2, panel_right_height/20);
		
		go_text_title = panel_right.transform.Find ("Text_TITLE").gameObject;
		go_text_title.transform.Translate(0, 18*panel_right_height/20, -1);
		go_text_title.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_right_width, panel_right_height/20);
		
		go_text_walking = panel_right.transform.Find ("Text_WALKING").gameObject;
		go_text_walking.transform.Translate(panel_right_width/4, 16*panel_right_height/20, -1);
		go_text_walking.GetComponent<RectTransform>().sizeDelta = new Vector2(3*panel_right_width/4, panel_right_height/20);
		go_text_walking.GetComponent<Text>().text = "WALKING: 0";
		
		go_text_light = panel_right.transform.Find ("Text_LIGHT").gameObject;
		go_text_light.transform.Translate(2*panel_right_width/6, 12*panel_right_height/20, -1);
		go_text_light.GetComponent<RectTransform>().sizeDelta = new Vector2(3*panel_right_width/4, panel_right_height/20);
		go_text_light.GetComponent<Text>().text = "LIGHTING: 50";
		
		go_text_energyneed = panel_right.transform.Find("Text_ENERGYTOTAL").gameObject;
		go_text_energyneed.transform.Translate(panel_right_width/4, 3*panel_right_height/20, -1);
		go_text_energyneed.GetComponent<RectTransform>().sizeDelta = new Vector2(3*panel_right_width/4, panel_right_height/20);
		go_text_energyneed.GetComponent<Text>().text = "TOTAL: 50";
		
		go_toggle_submit = panel_right.transform.Find("Toggle_SUBMIT").gameObject;
		go_toggle_submit.transform.Translate(panel_right_width/6, 5*panel_right_height/20, -1);
		go_toggle_submit.GetComponent<RectTransform>().sizeDelta = new Vector2(3*panel_right_width/4, panel_right_height/20);
		
		go_toggle_scanner = panel_right.transform.Find("Toggle_SCANNER").gameObject;
		go_toggle_ui = panel_right.transform.Find("Toggle_UI").gameObject;
		
		/*
		INITIALIZE MAIN PANEL
		*/
		
		panel_main_width = Screen.width;
		panel_main_height = Screen.height;
		
		panel_main.GetComponent<RectTransform>().sizeDelta = new Vector2(panel_main_width, panel_main_height);
		go_panel_gameover = panel_main.transform.Find("Panel_GAMEOVER").gameObject;
		go_panel_gameover.GetComponent<RectTransform>().sizeDelta = new Vector2(9*Screen.width/10, 9*Screen.height/10);
		close_gameover_panel();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void set_energy_bar(int value, int max)
	{
		go_text_energy.GetComponent<Text>().text = "ENERGY: "+value+"/"+max;
		panel_top.transform.Find("Panel_ENERGY").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(value*panel_top_width/(2*max), panel_top_height/5);
		panel_top.transform.Find("Panel_ENERGY").localPosition = new Vector3(panel_top_width/4, 3*panel_top_height/5, -1);
	}
	
	void set_data_bar(int value, int max)
	{
		go_text_data.GetComponent<Text>().text="DATA: "+value+"/"+max;
		panel_top.transform.Find("Panel_DATA").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(value*panel_top_width/(2*max), panel_top_height/5);
		panel_top.transform.Find("Panel_DATA").localPosition = new Vector3(panel_top_width/4, panel_top_height/5, -1);
	}
	
	public int get_light_slider_value()
	{
		return (int)go_slider_light.GetComponent<Slider>().value;
	} 
	
	public Vector2 get_gamewindow_size()
	{
		/*
		Debug.Log ("Screensize");
		Debug.Log(Screen.width);
		Debug.Log(Screen.width - panel_right_width);
		Debug.Log(Screen.height);
		Debug.Log(Screen.height - panel_top_height);
		*/
		return new Vector2(Screen.width - panel_right_width, Screen.height - panel_top_height);
	}
	
	public void update_text_energy_light(int value)
	{
		energy_light = value;
		go_text_light.GetComponent<Text>().text = "LIGHTING: "+value;
		update_text_energy_total();
	}
	
	public void update_text_energy_walking(int value)
	{
		energy_walking = value;
		go_text_walking.GetComponent<Text>().text = "WALKING: "+value;
		update_text_energy_total();
	}
	
	public void update_text_energy_submit(int value)
	{
		//Debug.Log ("Update text_energy_submit "+value);
		energy_submit = value;
		go_toggle_submit.transform.Find("Label").GetComponent<Text>().text = "SUBMIT\nDATA: "+value;
		
		update_text_energy_total();
	}
	
	void update_text_energy_total()
	{
		int totalenergy = energy_light+energy_walking+energy_submit;
		go_text_energyneed.GetComponent<Text>().text = "TOTAL: "+totalenergy;	
	}
	
	public void update_player_bars(int energy, int data, int points, int max_energy, int max_data)
	{
		set_energy_bar(energy, max_energy);
		set_data_bar(data, max_data);
		update_text_points(points);
	}
	
	public void close_gameover_panel()
	{
		go_panel_gameover.SetActive(false);
	}
	
	public void close_menu_panel()
	{
		panel_main.SetActive(false);
	}
	
	public void display_gameover_infos(int points, int turns)
	{
		panel_main.SetActive(true);
		go_panel_gameover.SetActive(true);
		go_panel_gameover.transform.Find("Text_STATISTICS").gameObject.GetComponent<Text>().text="TOTAL DATA SECURED: "+points+"\nTURNS SURVIVED: "+turns;
	}
	
	public void reset_toggles()
	{
		go_toggle_submit.GetComponent<Toggle>().isOn = false;
	}
	
	public void update_text_points(int points)
	{
		go_text_points.GetComponent<Text>().text = "POINTS: "+points;
	}
	
	public void update_text_difficulty(int diff)
	{
		panel_main.transform.Find ("Text_DIFFICULT").gameObject.GetComponent<Text>().text = "DIFFICULTY: "+diff;
	}
	
	public int get_difficulty()
	{
		return (int)panel_main.transform.Find ("Slider_DIFFICULT").gameObject.GetComponent<Slider>().value;
	}
	
}
