using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    public Queue tiles = new Queue();
    float tileOffset = 2f;
    public GameObject tile;
    GameObject gameControllerObject;
    GameController gameController;
    GameObject currentLast;
    public Sprite[] shopSprites = new Sprite[5];
    GameObject lastCreated;

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
        lastCreated = newTile;
        tiles.Enqueue(newTile);

        //Random shop
        int rando = (int) Random.Range(0f, 4.9999f);
        newTile.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = shopSprites[rando];

        //Random obstacles
        bool canLeft = true;
        if (lastCreated.transform.GetChild(4).gameObject.activeSelf == true || lastCreated.transform.GetChild(6).gameObject.activeSelf == true)
        {
            canLeft = false;
        }
        rando = (int) Random.Range(0f, 100f);
        Debug.Log(rando);
        if (rando < gameController.obstacleOccurence * 100f)
        {
            if (canLeft)
                rando = (int)Random.Range(0f, 3.9999f);
            else
                rando = (int)Random.Range(2f, 3.9999f);
            switch (rando)
            {
                case 0:
                    newTile.transform.GetChild(3).gameObject.SetActive(false);
                    newTile.transform.GetChild(5).gameObject.SetActive(false);
                    newTile.transform.GetChild(6).gameObject.SetActive(false);
                    break;
                case 1:
                    newTile.transform.GetChild(3).gameObject.SetActive(false);
                    newTile.transform.GetChild(4).gameObject.SetActive(false);
                    newTile.transform.GetChild(5).gameObject.SetActive(false);
                    break;
                case 2:
                    newTile.transform.GetChild(4).gameObject.SetActive(false);
                    newTile.transform.GetChild(5).gameObject.SetActive(false);
                    newTile.transform.GetChild(6).gameObject.SetActive(false);
                    break;
                case 3:
                    newTile.transform.GetChild(3).gameObject.SetActive(false);
                    newTile.transform.GetChild(4).gameObject.SetActive(false);
                    newTile.transform.GetChild(6).gameObject.SetActive(false);
                    break;
            }
        }
        else
        {
            newTile.transform.GetChild(3).gameObject.SetActive(false);
            newTile.transform.GetChild(4).gameObject.SetActive(false);
            newTile.transform.GetChild(5).gameObject.SetActive(false);
            newTile.transform.GetChild(6).gameObject.SetActive(false);
        }
    }
}
