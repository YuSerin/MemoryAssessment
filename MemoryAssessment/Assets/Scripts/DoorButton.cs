using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
using System;

public class DoorButton : MonoBehaviour
{
    public GameObject door, hinges;
    public RotateDial passcodeSelect;
    DataRecording recordData;
    int buttonId, passcode, currentPasscodeOption;
    AudioSource audioSource; 

    public void Start()
    {
        buttonId = Convert.ToInt32(gameObject.tag[6].ToString());
        door = GameObject.FindWithTag("Door"+buttonId);
        recordData = GameObject.FindWithTag("Player").GetComponent<DataRecording>();
        audioSource = GetComponent<AudioSource>();
    
    }
    public void OnButtonDown(Hand fromHand)
    {
        passcode = passcodeSelect.passcodes[buttonId - 1];
        currentPasscodeOption = passcodeSelect.currentOption;

        recordData.writeToFile(Time.time+","+ buttonId+","+ passcode+","+ currentPasscodeOption);

        if (currentPasscodeOption == passcode)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            StartCoroutine(RotateForSeconds());
            audioSource.Play();
        }
       

    }

    public void OnButtonUp(Hand fromHand)
    {
        ColorSelf(Color.white);
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }

    IEnumerator RotateForSeconds() 
    {
        float time = 2;     

        while (time > 0)    
        {
            door.transform.Rotate(new Vector3(0, 40 * Time.deltaTime, 0));
            //door.transform.RotateAround(hinges.GetComponent<Renderer>().bounds.center, hinges.transform.up, 20 * Time.deltaTime);
            time -= Time.deltaTime;     
            yield return null;   
        }

    }
}
