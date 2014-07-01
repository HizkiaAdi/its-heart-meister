using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class RepeatedButtonScript : MonoBehaviour 
{
    public GameObject target;
    public string functionName;
    public string functionParam;
    bool isPressed;

	// Use this for initialization
	void Start () 
    {
        isPressed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(isPressed)
        {
            target.SendMessage(functionName, functionParam);
        }
	}

    void OnMouseDown()
    {
        isPressed = true;

        HOTween.To(transform, 0.2f, new TweenParms()
            .Prop("localScale", new Vector3(0.8f, 0.8f)));

        HOTween.To(transform, 0.2f, new TweenParms()
            .Prop("localScale", new Vector3(1f, 1f))
            .Delay(0.2f));
    }

    void OnMouseUp()
    {
        isPressed = false;

        HOTween.To(transform, 0.2f, new TweenParms()
            .Prop("localScale", new Vector3(1f, 1f))
            .Delay(0.2f));
    }
}
