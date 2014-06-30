using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class ButtonScript : MonoBehaviour
{

    public GameObject target;
    public string functionName;
    public string functionParam;

    // Use this for initialization
    void Start()
    {

    }

    void OnMouseDown()
    {
        var audio = GetComponent<AudioSource>();
        audio.enabled = true;
        audio.Play();

        HOTween.To(transform, 0.2f, new TweenParms().Prop("localScale", new Vector3(0.5f, 0.5f)).OnComplete(target, functionName, functionParam, SendMessageOptions.DontRequireReceiver));
        HOTween.To(transform, 0.2f, new TweenParms().Prop("localScale", new Vector3(1f, 1f)).Delay(0.2f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
