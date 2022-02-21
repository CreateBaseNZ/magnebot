using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Bin"))
        {
            gameObject.SetActive(false);
        }
    }

}
