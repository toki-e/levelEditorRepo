using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using System.IO; //need system io for level editing

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 

	public GameObject playerPrefab;
	public GameObject wallPrefab;
	public GameObject doorPrefab;

	public float tileWidth = 2f;
	public float tileHeight = 3f;

	public string levelString = "xooopx";
	public string levelFile = "level1.txt";

	// Use this for initialization
	void Start () {

		string levelString = File.ReadAllText (Application.dataPath + Path.DirectorySeparatorChar + levelFile);

		string[] levelLines = levelString.Split ('\n');
		int width = 0;

		//makes sure unity can recognize the rows and columns in the txt file
		for (int row = 0; row < levelLines.Length; row++) {
			string currentLine = levelLines [row];
			width = currentLine.Length;

			for (int col = 0; col < currentLine.Length; col++) {
				char currentChar = currentLine [col];
				if (currentChar == 'x') {
					GameObject wallObj = Instantiate (wallPrefab);
					wallObj.transform.position = new Vector3 (col * tileWidth, -row * tileHeight, 0);
				} else if (currentChar == 'p') {
					GameObject playerObj = Instantiate (playerPrefab);
					playerObj.transform.position = new Vector3 (col * tileWidth, -row * tileHeight, 0);
				} else if (currentChar == 'd') {
					if(Random.value <= 0.5f){
						GameObject enemyObj = Instantiate (doorPrefab);
						enemyObj.transform.position = new Vector3 (col * tileWidth, -row * tileHeight, 0);
					}
				}
			}
		}

		//makes sure unity reads the text file in the right order
		float myX = -(width * tileWidth)/2f + tileWidth/2f;
		float myY = (levelLines.Length*tileHeight)/2f - tileHeight/2f;
		transform.position = new Vector3 (myX, myY, 0);

	if (instance == null) {
		DontDestroyOnLoad(gameObject);
		instance = this;
	}
	else {
		Destroy(gameObject);
	}
}

// Update is called once per frame
	void Update () {

	}
}
