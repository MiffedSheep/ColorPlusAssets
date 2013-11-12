using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
public int x,y;
public bool Active,Black,Blue,Green,Red,Yellow,boomBool;
private Cube cube;
private GameController gameController;
public GameObject aCube;
	// Use this for initialization
	void Start () {
		gameController= GameObject.Find ("GameController").GetComponent<GameController>();
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
