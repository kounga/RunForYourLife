using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    GameObject[] tiles;
    float tileOffset = 2f;
    int numTiles = 0;
    public GameObject tile;
    GameObject lastTile;
    GameObject gameControllerObject;
    GameController gameController;

    // Use this for initialization
    void Start () {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        createTile(new Vector3(-tileOffset, 0f, 0f));
        createTile(new Vector3(0f, 0f, 0f));
        createTile(new Vector3(tileOffset, 0f, 0f));
        createTile(new Vector3(2 * tileOffset, 0f, 0f));
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < numTiles; i++)
        {
            if (tiles[i].transform.position.x <= -2f)
                createTile(lastTile.transform.position + new Vector3(2f, 0f, 0f));
            tiles[i].transform.Translate(new Vector3(-gameController.gameSpeed * gameController.difficulty, 0f, 0f));
        }
	}

    void createTile(Vector3 vector)
    {
        GameObject newTile = Instantiate(tile, vector, Quaternion.identity) as GameObject;
        tiles[numTiles] = newTile;
        numTiles++;
        lastTile = newTile;
    }
}
