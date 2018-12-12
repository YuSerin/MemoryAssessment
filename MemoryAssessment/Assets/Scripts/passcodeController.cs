using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passcodeController : MonoBehaviour {
    public int numberOfRooms;
    public Text numberOfRoomsText;
    public int[] passcodeIdOrder = new int[6];
    int passcodeId, shapeId, colorId;
   
    public GameObject[] passcodes;
    public Material[] colors;
    public GameObject[] shapes;
    public GameObject[] rooms, doors;
    public Transform[] footSteps;
    public GameObject outsideArea;
    void Start () {
        for (int i = 2; i < 6; i++)
        {
            rooms[i].SetActive(false);
        }
        numberOfRooms = Random.Range(1, 4) * 2;
        numberOfRoomsText.text = numberOfRooms + " rooms.";
        Debug.Log("Number of Rooms: "+ numberOfRooms);

        for (int i = 0; i < numberOfRooms; i++) {
            passcodeId= Random.Range(0, 15);
            passcodeIdOrder[i] = passcodeId;
            colorId = passcodeId / 4;
            shapeId = passcodeId % 4;           
            Instantiate(shapes[shapeId], passcodes[i].transform.position, Quaternion.Euler(new Vector3(0,0,90))).transform.GetChild(0).GetComponent<Renderer>().material = colors[colorId];
            //Debug.Log("item: " + (i + 1) + " is " + colors[colorId].name + " " + shapes[shapeId].name);
            rooms[i].SetActive(true);
            
        }

        outsideArea.transform.localPosition= new Vector3(-2.88f, 0, -7.3f + ((6- numberOfRooms) *3));
    }
	
	
}
