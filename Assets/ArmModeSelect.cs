using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ArmModeSelect : MonoBehaviour
{
    public List<MonoBehaviour> scripts = new List<MonoBehaviour>(); 

    // Start is called before the first frame update
    void Start()
    {
        ActivateScript(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateScript(int index)
    {
        scripts.Select(s => s.enabled = false);
        scripts[index].enabled = true;
    }
}
