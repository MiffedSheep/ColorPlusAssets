using UnityEngine;
using System.Collections;

public class Cube {
	
	public int x,y;
	public int currentX,currentY;
	public bool Black, Blue, Green, Red, Yellow;
	public GameObject aCube;
	// Use this for initialization
	public Cube(){
		
	}
	
	public Cube(bool Black, bool Blue, bool Green, bool Red, bool Yellow, int x, int y){
		Black = false;
		Blue=false;
		Green=false;
		Red=false;
		Yellow=false;
		x=currentX;
		y=currentY;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
