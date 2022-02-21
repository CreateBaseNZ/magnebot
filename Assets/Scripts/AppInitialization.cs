using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppInitialization : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("quality", PlayerPrefs.GetInt("quality", 2));
        PlayerPrefs.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0.2f));
        PlayerPrefs.SetFloat("simulationSpeed", PlayerPrefs.GetFloat("simulationSpeed", 1));

#if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = false;
            PlayerPrefs.SetString("p_focus", "0");
#endif
    }
}
