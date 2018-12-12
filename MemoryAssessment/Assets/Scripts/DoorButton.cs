using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
using System;

public class DoorButton : MonoBehaviour
{
    GameObject door, player;
    Transform playerVRComponent;
    DataRecording recordData;
    int roomNumber, passcode, currentPasscodeOption;
    AudioSource audioSource;
    passcodeController passController;

    public void Start()
    {
        if (!passController) {
            passController = GameObject.FindWithTag("PasscodeController").GetComponent<passcodeController>();            
        }

        player = GameObject.FindWithTag("Player");
        playerVRComponent= player.transform.GetChild(0);

        roomNumber = Convert.ToInt32(transform.parent.transform.parent.gameObject.tag[4].ToString());        
        recordData = GameObject.FindWithTag("Player").GetComponent<DataRecording>();
        audioSource = GetComponent<AudioSource>();
        
        passcode = passController.passcodeIdOrder[roomNumber - 1];        
        string currentPasscodeString = gameObject.name.Substring(8);
        currentPasscodeOption = Convert.ToInt32(currentPasscodeString);

        
        //Debug.Log("Room no. " + roomNumber + ", passcode: " + passcode + ", currentPasscodeOption: " + currentPasscodeOption);


    }
    public void OnButtonDown(Hand fromHand)
    {
       

        //Debug.Log("Room no. " + roomNumber +", passcode: " + passcode + ", currentPasscodeOption: " + currentPasscodeOption);
        

        recordData.writeToFile(Time.time+","+ roomNumber + ","+ passcode+","+ currentPasscodeOption);

        if (currentPasscodeOption == passcode)
        {
            ColorSelf(Color.green);
            fromHand.TriggerHapticPulse(50000);
            StartCoroutine(slideForSeconds());
            //StartCoroutine(movePlayer());
            Invoke("movePlayer", 2.0f);
            audioSource.Play();
        }
       

    }

    public void OnButtonUp(Hand fromHand)
    {
        ColorSelf(Color.white);
    }

    public void OnButtonStay(Hand fromHand)
    {
        if (currentPasscodeOption == passcode)
        {
            ColorSelf(Color.green);
        }
        else
        {
            ColorSelf(Color.red);
        }
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponents<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }

    IEnumerator slideForSeconds() 
    {
        float time = 2;
        
        door = passController.doors[roomNumber - 1];
        while (time > 0)    
        {
            door.transform.Translate(new Vector3(0.008f, 0, 0));           
            time -= Time.deltaTime;     
            yield return null;   
        }

        while (time < 0 && time > -2)
        {
            door.transform.Translate(new Vector3(-0.008f, 0, 0));            
            time -= Time.deltaTime;
            yield return null;
        }
    }

    void movePlayer() {
        Debug.Log("player: "+ player.transform.position + ", "+ passController.footSteps[roomNumber-1].position);
        player.transform.position = passController.footSteps[roomNumber-1].position;
        playerVRComponent.transform.localPosition = new Vector3(0, 0, 0);
        //Vector3.Lerp(player.transform.position, passController.footSteps[roomNumber].position, 2.0f);
     
    }
}
