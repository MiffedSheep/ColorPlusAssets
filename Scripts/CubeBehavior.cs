using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
public int x,y;
public bool Active;
private Cube cube;
private CubeBehavior cubeBehavior;
public GameObject aCube;
	// Use this for initialization
	void Start () {
		cubeBehavior = GameObject.Find ("aCube").GetComponent<CubeBehavior>();
		cube = new Cube(cube.Active,cube.Black,cube.Blue,cube.Green,cube.Red,cube.Yellow,cube.locX,cube.locY);
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
