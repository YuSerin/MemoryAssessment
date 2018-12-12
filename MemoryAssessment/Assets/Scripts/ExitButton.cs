using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System;

public class ExitButton : MonoBehaviour {

    public void OnButtonDown(Hand fromHand)
    {       
        fromHand.TriggerHapticPulse(50000);       

    }

    public void OnButtonUp(Hand fromHand)
    {
        ColorSelf(Color.white);
        AppHelper.Quit();
    }

    public void OnButtonStay(Hand fromHand)
    {
       
       ColorSelf(Color.red);
      
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }
}

public static class AppHelper
{
#if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "http://google.com";
#endif
    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }
}

