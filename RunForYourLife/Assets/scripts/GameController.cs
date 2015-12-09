using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float gameSpeed = 0f;
    float gameTime = 0f;
    public bool gameRunning = false;
    public float difficulty = 0.4f; //Between 0 and 1
    public float obstacleOccurence = 0.1f;

    GameObject player;
    PlayerController playerController;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameRunning)
        {
            //Set game speed
            gameTime += Time.deltaTime;
            gameSpeed = Mathf.Sqrt(gameTime * difficulty);
        }
	}

    //Probably remove this
    void Update()
    {
        if (Input.GetButtonDown("Start_Game"))
        {
            if (!gameRunning) StartGame();
            else StopGame();
        }
    }

    void StartGame()
    {
        gameRunning = true;
        playerController.run(true);
    }

    void StopGame()
    {
        gameRunning = false;
        playerController.run(false);
        gameSpeed = 0f;
    }

}
