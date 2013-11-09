using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
public int gridWidth = 8;
public int gridHeight =5;
public GameObject aCube;
public GameObject[,] cubes;
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
	
	}
}
