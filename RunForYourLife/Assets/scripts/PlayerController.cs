using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool actionPressed = false;
    public bool acting = false;
    public float jumpHeight = 0.3f;
    public float crouchHeight = -0.1f;
    float actionTimer = 0f;
    string action = "none";

    Animator playerAnimator;
    GameObject gameControllerObject;
    GameController gameController;

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

	// Update is called once per frame
	void Update () {
        if (gameController.gameRunning == true)
        {
            //actions buttons down
            if (Input.GetButtonDown("Jump") && (acting == false))
            {
                actionPressed = true;
                action = "jumping";
            }
              if (Input.GetButtonDown("Crouch") && (acting == false))
            {
                actionPressed = true;
                action = "crouching";
            }
            //actions buttons up
            if (Input.GetButtonUp("Jump") && (acting == false))
            {
                actionPressed = false;
                acting = true;
                transform.Translate(new Vector3(0f, jumpHeight, 0f));
            }
            if (Input.GetButtonUp("Crouch") && (acting == false))
            {
                actionPressed = false;
                acting = true;
                transform.Translate(new Vector3(0f, crouchHeight, 0f));
            }

            if (acting)
            {
                    playerAnimator.SetBool(action, true);
                    actionTimer -= Time.deltaTime;
                    if (actionTimer <= 0f)
                    {
                        if (action == "jumping")
                            transform.Translate(new Vector3(0f, -jumpHeight, 0f));
                        if (action == "crouching")
                            transform.Translate(new Vector3(0f, -crouchHeight, 0f));
                        acting = false;
                        actionTimer = 0f;
                        playerAnimator.SetBool(action, false);
                    }
                }
            }
        }

    void FixedUpdate()
    {
        if (actionPressed)
            actionTimer += Time.fixedDeltaTime;
    }

    public void run(bool run)
    {
        if (run)
            playerAnimator.SetBool("running", true);
        else
        {
            playerAnimator.SetBool("running", false);
        }
    }
}
