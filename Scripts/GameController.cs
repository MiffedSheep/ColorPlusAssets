using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
public int gridWidth = 8;
public int gridHeight =5;
public GameObject aCube;
public GameObject[,] cubes;
public GameObject[] NextCube;
private CubeBehavior cubeBehavior;
private Cube cube;
	// Use this for initialization
	void Start () {
	cubes = new GameObject [gridWidth, gridHeight];
		
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
