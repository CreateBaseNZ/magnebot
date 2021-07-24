using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppInitialization : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            WebGLInput.captureAllKeyboardInput = false;
            PlayerPrefs.SetString("p_focus", "0");
#endif
    }

}
