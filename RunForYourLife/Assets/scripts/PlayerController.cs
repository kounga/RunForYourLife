using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool jumpingPressed = false;
    public bool jumping = false;
    float jumpTimer = 0f;

	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Jump"))
            jumpingPressed = true;
        if (Input.GetButtonUp("Jump"))
        {
            jumpingPressed = false;
            jumping = true;
        }
        if (jumping)
        {
            gameObject.GetComponent<"">
        }
	}

    void FixedUpdate()
    {
        if (jumpingPressed)
            jumpTimer += Time.fixedDeltaTime;
    }
}
