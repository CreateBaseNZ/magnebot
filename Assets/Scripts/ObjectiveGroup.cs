using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectiveGroup : MonoBehaviour
{
    private int _initialObjectiveNumber;
    private List<GameObject> _objectives;

    // Start is called before the first frame update
    void Start()
    {
        _objectives = GetComponentsInChildren<Objective>().Select(s => s.transform.parent.gameObject).ToList();
        _initialObjectiveNumber = _objectives.Count();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveObjective(Objective obj)
    {
        obj.gameObject.SetActive(false);
    }

    public float GetObjectiveNumber()
    {
        return _objectives.Select(s => s.activeSelf).Count();
    }
}
