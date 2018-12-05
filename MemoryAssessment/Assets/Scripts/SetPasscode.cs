using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPasscode : MonoBehaviour {
    int numberOfRooms;
    List<int> passcodeIndex = new List<int>();
    List<string> shapeOption = new List<string>();

    // Use this for initialization
    void Start () {

        shapeOption.Add("Red Triangle");
        shapeOption.Add("Red Square");
        shapeOption.Add("Red Circle");
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

        numberOfRooms = Random.Range(1, 3);             

        for (int i = 0; i < numberOfRooms * 2; i++) {
            passcodeIndex.Add(Random.Range(0, 15));
            Debug.Log("Chosen key: " + shapeOption[passcodeIndex[i]]);
        }


        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
