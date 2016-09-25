using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public Vector2 PlayerSpeed = new Vector2 (50, 50);

    public GameObject JetPack;

    private Vector2 playerMovement;


	// Use this for initialization
	void Start () 
    {
        JetPack.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        float inputX = Input.GetAxis ("Horizontal");
        JetPack jetPackScript = JetPack.GetComponent<JetPack> ();
        if (Input.GetKey (KeyCode.Space) && jetPackScript.JetPackOperable)
        {
            PlayerSpeed.y = 3;
            jetPackScript.RunJetPack ();
        }
        else
        {
            PlayerSpeed.y = -3;
            jetPackScript.RechargeingFuel();
        }

        playerMovement = new Vector2 (PlayerSpeed.x * inputX,PlayerSpeed.y);
	}

    void FixedUpdate ()
    {
        rigidbody2D.velocity = playerMovement;
    }
}
