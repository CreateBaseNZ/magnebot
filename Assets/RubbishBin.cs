using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : MonoBehaviour
{
    public Objective objective;
    public GameObject binCollect;

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
        if(other.tag == tag)
        {
            other.gameObject.SetActive(false);
            objective.IncrementObjectiveCounter();
            Instantiate(binCollect, gameObject.transform);
        }
        else
        {
            GameController.Instance.GameLose("Rubbish put in wrong bin");
        }
    }
}
