using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passcodeController : MonoBehaviour {
    public int numberOfRooms;
    public int[] passcodeIdOrder = new int[6];
    int passcodeId, shapeId, colorId;

    public GameObject[] passcodes;
    public Material[] colors;
    public GameObject[] shapes;
    

    void Start () {
        numberOfRooms = Random.Range(1, 4) * 2;  
        Debug.Log("Number of Rooms: "+ numberOfRooms);

        for (int i = 0; i < numberOfRooms; i++) {
            passcodeId= Random.Range(0, 15);
            passcodeIdOrder[i] = passcodeId;
            colorId = passcodeId / 4;
            shapeId = passcodeId % 4;           
            Instantiate(shapes[shapeId], passcodes[i].transform.position, Quaternion.Euler(new Vector3(0,0,90))).transform.GetChild(0).GetComponent<Renderer>().material = colors[colorId];
            Debug.Log("item: " + (i + 1) + " is " + colors[colorId].name + " " + shapes[shapeId].name);
        }
    }
	
	
}
