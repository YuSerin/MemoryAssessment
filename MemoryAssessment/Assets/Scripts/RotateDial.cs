using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotateDial : MonoBehaviour {

    SteamVR_Behaviour_Pose trackedObj;
    //public GameObject rotatingCylinder;
  
    // this determine the options that we have. For the given situation, we have 4 colors x 4 shapes = 16 options
    int segments = 16;
    public int currentOption = 0;
    float rotationAngle = 0;
    float eachSegmentAngles;
    public int[] passcodes;  

    List<string> shapeOption = new List<string>();
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        shapeOption.Add("Red Rhombus");

        shapeOption.Add("Blue Triangle");
        shapeOption.Add("Blue Square");
        shapeOption.Add("Blue Circle");
        shapeOption.Add("Blue Rhombus");

        shapeOption.Add("Green Triangle");
        shapeOption.Add("Green Square");
        shapeOption.Add("Green Circle");
        shapeOption.Add("Green Rhombus");

        shapeOption.Add("Yellow Triangle");
        shapeOption.Add("Yellow Square");
        shapeOption.Add("Yellow Circle");
        shapeOption.Add("Yellow Rhombus");

        shapeOption.Add("Red Triangle");
        shapeOption.Add("Red Square");
        shapeOption.Add("Red Circle");

        eachSegmentAngles = 360 / segments;

        passcodes = new int[] {0,1,2,3,4,5};
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotationAngle = transform.rotation.eulerAngles.z;
        currentOption = (int) (rotationAngle / eachSegmentAngles);
        currentOption = (currentOption > 15) ? 0 : currentOption;
        //Debug.Log("Angle: "+ rotationAngle +" currentOption: "+currentOption+" "+shapeOption[currentOption]);

    }

  

}
