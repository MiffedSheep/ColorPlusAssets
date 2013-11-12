using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
public int gridWidth = 8;
public int gridHeight =5;
public int colorCode;
public float timer, timer2;
public GameObject aCube;
public GameObject[,] cubes;
public GameObject[] nextCube;
private CubeBehavior cubeBehavior;
private Cube cube;
	// Use this for initialization
	void Start () {
	
	cubes = new GameObject [gridWidth, gridHeight];
	nextCube= new GameObject[1];
	nextCube[0]= (GameObject)Instantiate (aCube, new Vector3 (-7.022398f, 2.852758f,10),Quaternion.identity);		
	for(int x = 0; x<gridWidth; x++){
		for(int y = 0; y<gridHeight;y++){
		cubes [x, y] = (GameObject)Instantiate (aCube, new Vector3 (x * 2 - 14, y * 2 - 8, 10), Quaternion.identity);		
		cubes [x, y].GetComponent<CubeBehavior> ().x = x;
		cubes [x, y].GetComponent<CubeBehavior> ().y = y;		
			
			}
		}
	
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timer2 += Time.deltaTime;
		if(timer2>=60f){
		 //Switch to Score Script	
		}
		if(timer >=2f){
		
		colorCode= (Random.Range (1,5));
		
			if(colorCode==1){
				nextCube[0].renderer.material.color=Color.black;
				nextCube[0].tag="Black";
			}
			else if(colorCode==2){
				nextCube[0].renderer.material.color=Color.blue;
				nextCube[0].tag="Blue";
			}	
			else if(colorCode==3){
				nextCube[0].renderer.material.color=Color.green;
				nextCube[0].tag="Green";
			}
			else if(colorCode==4){
				nextCube[0].renderer.material.color=Color.red;
				nextCube[0].tag="Red";
			}
			else if(colorCode==5){
				nextCube[0].renderer.material.color=Color.yellow;
				nextCube[0].tag="Yellow";
			}
			
		timer=0;		
			
		}
		
		
		
	//Input Script	
	if(Input.GetKey (KeyCode.Keypad1)){
		}
	if(Input.GetKey (KeyCode.Keypad2)){
		}
	if(Input.GetKey (KeyCode.Keypad3)){
		}
	if(Input.GetKey (KeyCode.Keypad4)){
		}
	if(Input.GetKey (KeyCode.Keypad5)){
		}
	}
	void OnMouseDown(){
		if (cube.Active==false){
			cube.Active=true;
		}
	}
	
	
}
