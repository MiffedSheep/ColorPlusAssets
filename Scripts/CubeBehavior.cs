using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour
{
	public int x, y;
	public bool Active, ActiveAndInput, Black, Blue, Green, Red, Yellow, boomBool;
	private Cube cube;
	private GameController gameController;
	public GameObject aCube;

	// Use this for initialization
	void Start ()
	{
		ActiveAndInput = false;
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{

			
	}

	void OnMouseDown ()
	{
		if (this.gameObject.GetComponent<CubeBehavior> ().ActiveAndInput == false && this.gameObject.GetComponent<CubeBehavior> ().Active == true) {
			
			for (int x2 = 0; x2<8; x2++) {
				for (int y2 = 0; y2<5; y2++) {	
					gameController.cubes [x2, y2].GetComponent <CubeBehavior> ().ActiveAndInput = false;
					gameController.DirectionalLightArray [x2, y2].light.enabled = false;
					
				}
			}
			this.gameObject.GetComponent<CubeBehavior> ().ActiveAndInput = true;
			gameController.DirectionalLightArray [x, y].light.enabled = true;
			
			
			
		} else if (this.gameObject.GetComponent<CubeBehavior> ().ActiveAndInput == true) {
			this.gameObject.GetComponent<CubeBehavior> ().ActiveAndInput = false;
			gameController.DirectionalLightArray [x, y].light.enabled = false;
		}
		if((this.gameObject.GetComponent<CubeBehavior>().Active==true && 
			this.gameObject.GetComponent<CubeBehavior>().ActiveAndInput==false) &&( 
			gameController.cubes[x+1,y+1].GetComponent<CubeBehavior>().ActiveAndInput==true || 
			gameController.cubes[x+1,y-1].GetComponent<CubeBehavior>().ActiveAndInput==true ||
			gameController.cubes[x-1,y+1].GetComponent<CubeBehavior>().ActiveAndInput==true ||
			gameController.cubes[x-1,y-1].GetComponent<CubeBehavior>().ActiveAndInput==true ||
			gameController.cubes[x+1,y].GetComponent<CubeBehavior>().ActiveAndInput==true ||
			gameController.cubes[x-1,y].GetComponent<CubeBehavior>().ActiveAndInput==true ||
			gameController.cubes[x,y+1].GetComponent<CubeBehavior>().ActiveAndInput==true ||
			gameController.cubes[x,y-1].GetComponent<CubeBehavior>().ActiveAndInput==true))
		{
			gameController.cubes[x+1,y+1].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x+1,y-1].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x-1,y+1].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x-1,y-1].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x+1,y].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x-1,y].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x,y+1].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x,y-1].GetComponent<CubeBehavior>().ActiveAndInput=false;
			gameController.cubes[x,y].GetComponent<CubeBehavior>().ActiveAndInput=true;
		}
		/*if (this.gameObject.GetComponent<CubeBehavior>().ActiveAndInput == false && this.gameObject.GetComponent<CubeBehavior>().Active) {  
			for (int x2 = 0; x2<8; x2++) {
				for (int y2 = 0; y2<5; y2++) {	
					if (gameController.cubes [x2, y2].GetComponent<CubeBehavior> ().ActiveAndInput == true) {
						gameController.cubes [x2, y2].renderer.material.color = Color.white;
						
					}
				}
				
			}*/
		
			/*
		if(the cube is not active, activate it. use a seperate bool in CubeBehavior if this is where you're going to track the secondary active status){
		Find an active cube in the array and deactivate it
		then activate the clicked cube, and add an effect to it to signify that it's active. 
		Perhaps make 5 alternative colors that are rendered depending on what type of cube is active.
		
		}
		if(an adjacent cube is active && the clicked cube is innactive){
		deactivate the adjacent cube and make the clicked cube active.
		}																*/
		
		}
	}
