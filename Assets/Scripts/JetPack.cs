using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour 
{

    public bool JetPackOperable;
    public float fuel;
    private bool coolDown;

    void Awake ()
    {
        fuel = 100;
        coolDown = false;
        JetPackOperable = true;
    }

	// Use this for initialization
	void Start () 
    {
	
	}

    public void RunJetPack ()
    {
        if (fuel > 0)
        {
            fuel -= 1f;
            if (!coolDown)
            {
                JetPackOperable = true;
            }
            gameObject.SetActive (true);
            Debug.Log (fuel);
            if (fuel <= 0)
            {
                JetPackOperable = false;
                Debug.Log ("Jet Pack FlameOut!");
                coolDown = true;
            }
        }
    }

    public void RechargeingFuel ()
    {
        if (fuel < 100)
        {
            if (coolDown == true && fuel >= 20)
            {
                JetPackOperable = true;
                coolDown = false;
                Debug.Log ("Jet Pack is back Online!");
            }
            fuel += 0.2f;
            gameObject.SetActive (false);
            Debug.Log (fuel);
        }
    }
	// Update is called once per frame
	void Update () 
    {
        
	
	}
}
