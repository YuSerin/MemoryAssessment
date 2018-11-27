using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class DoorButton : MonoBehaviour
{
    public GameObject door, hinges;
    public RotateDial passwordSelect;

    public void OnButtonDown(Hand fromHand)
    {
        

        if (passwordSelect.currentOption == passwordSelect.passowrd)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            StartCoroutine(RotateForSeconds());
        }
        // door.transform.Rotate(new Vector3(0, 20, 0));

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
