using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    public Queue tiles = new Queue();
    float tileOffset = 2f;
    public GameObject tile;
    GameObject gameControllerObject;
    GameController gameController;
    GameObject currentLast;

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

        foreach (GameObject tile in tiles)
        {
            tile.transform.Translate(new Vector3(-gameController.gameSpeed * Time.deltaTime, 0f, 0f));
        }
        Debug.Log(-gameController.gameSpeed);

        currentLast = (GameObject) tiles.Peek();
        if (currentLast.transform.position.x < -4f)
        {
            Vector3 offset = new Vector3(currentLast.transform.position.x + 4f, 0f, 0f);
            createTile(new Vector3(4f, 0f, 0f) + offset);
            Destroy((GameObject) tiles.Dequeue());
        }
        
	}

    void createTile(Vector3 vector)
    {
        GameObject newTile = Instantiate(tile, vector, Quaternion.identity) as GameObject;
        tiles.Enqueue(newTile);
    }
}
