using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float gameSpeed = 1f;
    float gameTime = 0f;
    public bool gameRunning = false;
    public float difficulty = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameRunning)
        {
            //Set game speed
            gameTime += Time.deltaTime;
            gameSpeed = Mathf.Sqrt(gameTime * 0.1f);
        }
	}

    //Probably remove this
    void Update()
    {
        if (Input.GetButtonDown("Start_Game"))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameRunning = true;
    }


}
