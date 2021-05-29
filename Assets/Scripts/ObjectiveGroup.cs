using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectiveGroup : MonoBehaviour
{
    private int _numberOfObjectives;

    // Start is called before the first frame update
    void Start()
    {
        _numberOfObjectives = GetComponentsInChildren<Objective>().Select(s => s.transform.parent.gameObject).Count();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveObjective(Objective obj)
    {
        obj.gameObject.SetActive(false);
        _numberOfObjectives--;
        if(_numberOfObjectives == 0)
        {
            GameController.Instance.GameWin();
        }
    }
}
