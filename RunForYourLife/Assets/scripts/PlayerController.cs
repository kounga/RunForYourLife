using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool jumpingPressed = false;
    public bool jumping = false;
    public float jumpHeight = 0.3f;
    float jumpTimer = 0f;
    Animator playerAnimator = null;
    GameObject player = null;

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Jump"))
            jumpingPressed = true;
        if (Input.GetButtonUp("Jump"))
        {
            jumpingPressed = false;
            jumping = true;
            transform.Translate(new Vector3(0f, jumpHeight, 0f));
        }
        if (jumping)
        {
            playerAnimator.SetBool("jumping", true);
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                transform.Translate(new Vector3(0f, -jumpHeight, 0f));
                jumping = false;
                jumpTimer = 0f;
                playerAnimator.SetBool("jumping", false);
            }
        }
	}

    void FixedUpdate()
    {
        if (jumpingPressed)
            jumpTimer += Time.fixedDeltaTime;
    }
}
