using UnityEngine;
using System.Collections;

public class Cube {
	public bool Active,Black, Blue, Green, Red, Yellow;
	public int locX, locY;
	private CubeBehavior cubeBehavior;
	public GameObject aCube;
	public GameObject[,] cubes;

	// Use this for initialization
	void Start () {
	cubes = new GameObject[8, 5];
	cubeBehavior = aCube.GetComponent<CubeBehavior> ();
	for (int x = 0; x < 8; x++) {
			for (int y = 0; y < 5; y++) {
				cubes [x, y].GetComponent<CubeBehavior> ().x = x;
				cubes [x, y].GetComponent<CubeBehavior> ().y = y;					
			}		
		}
		
	
	}
	public Cube(){
		
	}
	// Method to track how 
	public Cube(bool Active, bool Black,bool Blue, bool Green, bool Red, bool Yellow, int locX, int locY){ 
	Black=false;
	Blue=false;
	Green=false;
	Red=false;
	Yellow=false;
	Active=false;
	locX = cubeBehavior.x;
	locY = cubeBehavior.y;
	}
	// Update is called once per frame
	void Update () {
		
	
	}
}
