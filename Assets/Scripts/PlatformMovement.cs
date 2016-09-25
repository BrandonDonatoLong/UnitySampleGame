using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour 
{
    public float StartingX;
    public float EndingX;
    public float StartingY;
    public float EndingY;
    public float Speed = 0;
    public float TimeBetweenPoints = 1000;
    private Vector2 endPoint;

    // Use this for initialization
    IEnumerator Start ()
    {
        endPoint = new Vector2 (EndingX, EndingY);
        Vector2 pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine (MoveObject (transform, pointA, endPoint, TimeBetweenPoints));
            yield return StartCoroutine (MoveObject (transform, endPoint, pointA, TimeBetweenPoints));
        }
    }
    void OnTriggerEnter2D (Collider2D collider)
    {
        collider.gameObject.transform.parent = transform;
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        Debug.Log ("OnTriggerExit");
        collider.gameObject.transform.parent = transform.parent;
    }

   	// Update is called once per frame
	void Update () 
    {   
	}

    // Moves the object
    IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = Speed / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp (startPos, endPos, i);
            yield return null;
        }
    }
}