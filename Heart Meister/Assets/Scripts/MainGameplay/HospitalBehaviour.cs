using UnityEngine;
using System.Collections;

public class HospitalBehaviour : MonoBehaviour {
    public GameObject Bar1;
    public GameObject Bar2;
    public GameObject Progress1;
    public GameObject Progress2;
    private Vector3 tempPos;
    public GUIText p1;
    public GUIText p2;
    public GUIText pLv1;
    public GUIText pLv2;
    public GUIText ppercent1;
    public GUIText ppercent2;

    private string patient1;
    private string patient2;
    private string patientLv1;
    private string patientLv2;
    private string percentText1;
    private string percentText2;
    private float hospitalProgress1;
    private float hospitalProgress2;
    private float percentage1;
    private float percentage2;

    private float counter = 0;

	// Use this for initialization
	void Start ()
    {
        tempPos = new Vector3(0.75f, 0.75f);
        Bar1.transform.position = Camera.main.ViewportToWorldPoint(tempPos);
        tempPos = Bar1.transform.position;
        tempPos.z = 0f;
        Bar1.transform.position = tempPos;

        tempPos = new Vector3(0.75f, 0.65f);
        Progress1.transform.position = Camera.main.ViewportToWorldPoint(tempPos);
        tempPos = Progress1.transform.position;
        tempPos.z = 0f;
        Progress1.transform.position = tempPos;
        percentage1 = 0f;

        tempPos = new Vector3(0.75f, 0.25f);
        Bar2.transform.position = Camera.main.ViewportToWorldPoint(tempPos);
        tempPos = Bar2.transform.position;
        tempPos.z = 0f;
        Bar2.transform.position = tempPos;

        tempPos = new Vector3(0.75f, 0.15f);
        Progress2.transform.position = Camera.main.ViewportToWorldPoint(tempPos);
        tempPos = Progress2.transform.position;
        tempPos.z = 0f;
        Progress2.transform.position = tempPos;
        percentage2 = 0f;

        DataInput();
        p1.text = patient1;
        p2.text = patient2;
        pLv1.text = patientLv1;
        pLv2.text = patientLv2;

        p1.transform.position = new Vector3(0.75f, 0.8f);
        tempPos = p1.transform.position;
        tempPos.z = 0f;
        p1.transform.position = tempPos;

        pLv1.transform.position = new Vector3(0.9f, 0.8f);
        tempPos = pLv1.transform.position;
        tempPos.z = 0f;
        pLv1.transform.position = tempPos;

        ppercent1.transform.position = new Vector3(0.9f, 0.675f);
        tempPos = ppercent1.transform.position;
        tempPos.z = 0f;
        ppercent1.transform.position = tempPos;

        p2.transform.position = new Vector3(0.75f, 0.3f);
        tempPos = p2.transform.position;
        tempPos.z = 0f;
        p2.transform.position = tempPos;

        pLv2.transform.position = new Vector3(0.9f, 0.3f);
        tempPos = pLv2.transform.position;
        tempPos.z = 0f;
        pLv2.transform.position = tempPos;

        ppercent2.transform.position = new Vector3(0.9f, 0.175f);
        tempPos = ppercent2.transform.position;
        tempPos.z = 0f;
        ppercent2.transform.position = tempPos;
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter += Time.deltaTime;
        percentText1 = (percentage1).ToString() + "%";
        percentText2 = (percentage2).ToString() + "%";
        ppercent1.text = percentText1;
        ppercent2.text = percentText2;
        Progress1.transform.localScale = new Vector3(percentage1 * 15 / 1000, 1.5f);
        Progress2.transform.localScale = new Vector3(percentage2 * 15 / 1000, 1.5f);
        if (counter >= 1)
        {
            if (percentage1 < 100f)
            {
                percentage1 += 10f;
            }
            else
            {
                percentage1 = 100f;
            }
            if (percentage2 < 100f)
            {
                percentage2 += 10f;
            }
            else
            {
                percentage1 = 100f;
            }
            counter = 0;
        }
	}

    private void DataInput()
    {
        //inputs data from database
        patient1 = "Pati";
        patient2 = "Tia";
        patientLv1 = "63";
        patientLv2 = "36";
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 1 / 8, Screen.height * 1 / 8, Screen.width * 4 / 16, Screen.height * 24 / 32), "Back"))
        {
            Application.LoadLevel("HomeSceneTemp");
        }
    }
}
