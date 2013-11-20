using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public int gridWidth = 8;
	public int gridHeight = 5;
	public int colorCode, turnCount, randomInt, randomInt2,score, x2,y2,ActiveCubes,previousCubeX, previousCubeY;
	public bool onePerTurnBool,score1,score2,score3,renderMe,Active;
	public string colorString;
	public float timer, timer2;
	public GameObject aCube;
	public GameObject[,] cubes;
	public GameObject[] nextCube;
	public GameObject DirectionalLight;
	public GameObject[,] DirectionalLightArray;
	Color[] colorList; // This is for a color array attached to the score script
	private CubeBehavior cubeBehavior;
	private Cube cubeScript;
	
	
	// Use this for initialization
	void Start ()
	{
		colorCode = (Random.Range (1, 5));
		cubes = new GameObject [gridWidth, gridHeight];
		DirectionalLightArray = new GameObject [gridWidth, gridHeight];
		nextCube = new GameObject[1];
		nextCube [0] = (GameObject)Instantiate (aCube, new Vector3 (-7.022398f, 2.852758f, 10), Quaternion.identity);		
		for (int x = 0; x<gridWidth; x++) {
			for (int y = 0; y<gridHeight; y++) {
				cubes [x, y] = (GameObject)Instantiate (aCube, new Vector3 (x * 2 - 14, y * 2 - 8, 10), Quaternion.identity);		
				cubes [x, y].GetComponent<CubeBehavior> ().x = x;
				cubes [x, y].GetComponent<CubeBehavior> ().y = y;		
				DirectionalLightArray[x,y] = (GameObject)Instantiate (DirectionalLight, new Vector3 (x * 2 - 14, y * 2 - 8, -4), Quaternion.identity);
				DirectionalLightArray[x,y].light.enabled=false;

			}
		}
		colorList = new Color [5];
		colorList[0] = Color.black;
		colorList[1] = Color.blue;
		colorList[2] = Color.green;
		colorList[3] = Color.red;
		colorList[4] = Color.yellow;
		//All the other colors
		
	
	}
	
	
	
	private bool CheckForPlus (int x, int y) {
				if(cubes[x+1,y].GetComponent<CubeBehavior>().Active &&
				  cubes[x-1,y].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y+1].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y-1].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y].GetComponent<CubeBehavior>().Active)
				{ 
					cubes[x,y].GetComponent<CubeBehavior>().Active=false;
					cubes[x+1,y].GetComponent<CubeBehavior>().Active=false;	
					cubes[x-1,y].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y+1].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y-1].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y].GetComponent<CubeBehavior>().ActiveAndInput=false;
					cubes[x+1,y].GetComponent<CubeBehavior>().ActiveAndInput=false;	
					cubes[x-1,y].GetComponent<CubeBehavior>().ActiveAndInput=false;
					cubes[x,y+1].GetComponent<CubeBehavior>().ActiveAndInput=false;
					cubes[x,y-1].GetComponent<CubeBehavior>().ActiveAndInput=false;
					cubes[x+1,y].renderer.material.color=Color.gray;
					cubes[x-1,y].renderer.material.color=Color.gray;
					cubes[x,y+1].renderer.material.color=Color.gray;
					cubes[x,y-1].renderer.material.color=Color.gray;
					cubes[x,y].renderer.material.color=Color.gray;
					
				}
		return true;
	}

	private void CheckScore(){
		
		// Check every cube in the grid
		for(int x = 1; x<gridWidth-1; x++){
			for(int y = 1; y<gridHeight-1;y++){
				CheckForPlus (x,y);
				if ( CheckForPlus(x, y) == true) {
					score+=5;	
					
				}
				else if ( CheckForPlus(x, y) == true && score1 ) {
					score+=5;
					
				}
				else if ( CheckForPlus(x, y) == true && score2 ) {
					score+=10;
				
				}
				 
			}
		}
	}		
	

	// Update is called once per frame
	void Update ()
	{
		/*Script that says:
		 * 
		 * for(int x = 0; x<gridWidth; x++){
				for(int y = 0; y<gridHeight;y++){
		 * if(*there are cubes in the postions +x/+y,+x/-y,-x/-y,-x/+y* of the same color){
		 * points and grey and cube deactivation and yadda yadda
		 * }
		 *  
		 * else if(*as seen above* and the surrounding cubes are one of the four colors it is not.
		 * while being it's own color among the five.){
		 * points and grey and cube deactivation and yadda yadda
		 * }
		 *  
		 * else if(logic for the cubes being in a double cross){
		 * cubes turn grey and you get more points
		 * }
		 * 
		 * 
		 * 		}
		 * }
		 *  	
		 
						if(cubes[x+1,y].GetComponent<CubeBehavior>().Active &&
				  cubes[x-1,y].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y+1].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y-1].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y].GetComponent<CubeBehavior>().Active)
				{ 
					cubes[x,y].GetComponent<CubeBehavior>().Active=false;
					cubes[x+1,y].GetComponent<CubeBehavior>().Active=false;	
					cubes[x-1,y].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y+1].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y-1].GetComponent<CubeBehavior>().Active=false;
				}												* */
	for (int x = 0; x<gridWidth; x++) {
			for (int y = 0; y<gridHeight; y++) {	
				CheckScore ();
				
				
			}
		}
		
		
			
				
				
		timer += Time.deltaTime;
		timer2 += Time.deltaTime;
		if (timer2 >= 60f) {
			//Switch to Score Script	
		}
		if (timer >= 2f) {
			turnCount += 1;
			colorCode = (Random.Range (1, 5));
		
			if (colorCode == 1) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.black;
				nextCube [0].tag = "Black";
				colorString = "Black";
			} else if (colorCode == 2) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.blue;
				nextCube [0].tag = "Blue";
				colorString = "Blue";
			} else if (colorCode == 3) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.green;
				nextCube [0].tag = "Green";
				colorString = "Green";
			} else if (colorCode == 4) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.red;
				nextCube [0].tag = "Red";
				colorString = "Red";
			} else if (colorCode == 5) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.yellow;
				nextCube [0].tag = "Yellow";
				colorString = "Yellow";
				
			}
			/*if(a player hasn't pressed a key){
		  activeCubes[(Random.Range(0, numberOfActiveCubes)].boomBool=false;
		}		
		*/
			onePerTurnBool = false;
			timer = 0;		
			
		}
		
		
		
		//Input Script	HEY I NEED HELP TURNING ALL OF THIS DIFFICULT GOBBLEYGOOK INTO A METHOD SO I CAN CODE EASILY
		
		
		
		

		if (Input.GetKeyDown (KeyCode.Keypad1) && onePerTurnBool == false) {
			nextCube [0].renderer.enabled = false;
			randomInt = Random.Range (0, 8);
			randomInt2 = Random.Range (0, 8);
			if (colorString == "Black") {
				if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 0].renderer.material.color = Color.black;
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 0].renderer.material.color = Color.black;
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Blue") {
				if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 0].renderer.material.color = Color.blue;
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 0].renderer.material.color = Color.blue;
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Green") {
				if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 0].renderer.material.color = Color.green;
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 0].renderer.material.color = Color.green;
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Red") {
				if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 0].renderer.material.color = Color.red;
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 0].renderer.material.color = Color.red;
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Yellow") {
				if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 0].renderer.material.color = Color.yellow;
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 0].renderer.material.color = Color.yellow;
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			}
			onePerTurnBool = true;
		}
		
	
		if (Input.GetKeyDown (KeyCode.Keypad2) && onePerTurnBool == false) {
			nextCube [0].renderer.enabled = false;
			randomInt = Random.Range (0, 8);
			if (colorString == "Black") {
				if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 1].renderer.material.color = Color.black;
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 1].renderer.material.color = Color.black;
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Blue") {
				if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 1].renderer.material.color = Color.blue;
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 1].renderer.material.color = Color.blue;
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Green") {
				if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 1].renderer.material.color = Color.green;
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 1].renderer.material.color = Color.green;
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Red") {
				if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 1].renderer.material.color = Color.red;
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 1].renderer.material.color = Color.red;
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Yellow") {
				if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 1].renderer.material.color = Color.yellow;
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 1].renderer.material.color = Color.yellow;
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			}
			onePerTurnBool = true;		
		}
		if (Input.GetKeyDown (KeyCode.Keypad3) && onePerTurnBool == false) {
			nextCube [0].renderer.enabled = false;
			randomInt = Random.Range (0, 8);
			if (colorString == "Black") {
				if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 2].renderer.material.color = Color.black;
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 2].renderer.material.color = Color.black;
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Blue") {
				if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 2].renderer.material.color = Color.blue;
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 2].renderer.material.color = Color.blue;
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Green") {
				if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 2].renderer.material.color = Color.green;
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 2].renderer.material.color = Color.green;
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Red") {
				if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 2].renderer.material.color = Color.red;
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 2].renderer.material.color = Color.red;
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Yellow") {
				if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 2].renderer.material.color = Color.yellow;
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 2].renderer.material.color = Color.yellow;
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			}
			onePerTurnBool = true;
		}
		if (Input.GetKeyDown (KeyCode.Keypad4) && onePerTurnBool == false) {
			nextCube [0].renderer.enabled = false;
			randomInt = Random.Range (0, 8);
			if (colorString == "Black") {
				if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 3].renderer.material.color = Color.black;
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 3].renderer.material.color = Color.black;
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Blue") {
				if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 3].renderer.material.color = Color.blue;
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 3].renderer.material.color = Color.blue;
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Green") {
				if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 3].renderer.material.color = Color.green;
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 3].renderer.material.color = Color.green;
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Red") {
				if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 3].renderer.material.color = Color.red;
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 3].renderer.material.color = Color.red;
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Yellow") {
				if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 3].renderer.material.color = Color.yellow;
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 3].renderer.material.color = Color.yellow;
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			}
			onePerTurnBool = true;
		}
		if (Input.GetKeyDown (KeyCode.Keypad5) && onePerTurnBool == false) {
			randomInt = Random.Range (0, 8);
			if (colorString == "Black") {
				if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 4].renderer.material.color = Color.black;
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 4].renderer.material.color = Color.black;
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Blue") {
				if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 4].renderer.material.color = Color.blue;
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 4].renderer.material.color = Color.blue;
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Green") {
				if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 4].renderer.material.color = Color.green;
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 4].renderer.material.color = Color.green;
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Red") {
				if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 4].renderer.material.color = Color.red;
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 4].renderer.material.color = Color.red;
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			} else if (colorString == "Yellow") {
				if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 4].renderer.material.color = Color.yellow;
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 4].renderer.material.color = Color.yellow;
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
			}
			onePerTurnBool = true;
		}
	
	
	}
	private void/*tobeint*/ ProcessMyCubes (int x2, int y2, Color colorList, bool boomBool, bool Active, bool renderMe){
			
			
		}

	
	
	
}
