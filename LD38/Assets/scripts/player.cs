using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float fuckYouAntron = 1.0f;
    private Rigidbody2D rigidboyd;

    // Use this for initialization
    void Start () {
        rigidboyd = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidboyd.AddForce(Vector2.left * fuckYouAntron, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidboyd.AddForce(Vector2.right * fuckYouAntron, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //rigidboyd.velocity = Vector3.ClampMagnitude(rigidboyd.velocity, 7.5f);
    }
}
