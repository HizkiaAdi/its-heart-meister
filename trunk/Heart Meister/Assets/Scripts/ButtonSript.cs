using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class ButtonSript : MonoBehaviour 
{
    public GameObject target;
    public string functionName;
    public string functionParam;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void OnMouseDown()
    {
        HOTween.To(transform, 0.2f, new TweenParms()
            .Prop("localScale", new Vector3(0.8f, 0.8f))
            .OnComplete(target, functionName, functionParam, SendMessageOptions.DontRequireReceiver));

        HOTween.To(transform, 0.2f, new TweenParms()
            .Prop("localScale", new Vector3(1f, 1f))
            .Delay(0.2f));
    }
}
