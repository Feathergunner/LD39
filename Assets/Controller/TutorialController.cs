using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public GameObject tut_image_display;
	
	public Sprite tut_img_01;
	public Sprite tut_img_02;
	public Sprite tut_img_03;
	public Sprite tut_img_04;
	public Sprite tut_img_05;
	
	int current_tut_img;
	// Use this for initialization
	void Start () {
		current_tut_img = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void start_tutorial(){
		tut_image_display.SetActive(true);
		current_tut_img = 1;
		tut_image_display.GetComponent<Image>().sprite = tut_img_01;
	}
	
	public void next_tutorial(){
		if (current_tut_img == 1)
			tut_image_display.GetComponent<Image>().sprite = tut_img_02;
		else if (current_tut_img == 2)
			tut_image_display.GetComponent<Image>().sprite = tut_img_03;
		else if (current_tut_img == 3)
			tut_image_display.GetComponent<Image>().sprite = tut_img_04;
		else if (current_tut_img == 4)
			tut_image_display.GetComponent<Image>().sprite = tut_img_05;
		else if (current_tut_img == 5)
			tut_image_display.SetActive(false);
		current_tut_img++;
	}
	
}
