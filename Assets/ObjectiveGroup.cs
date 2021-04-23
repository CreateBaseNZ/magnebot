using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectiveGroup : MonoBehaviour
{
    public int initialObjectiveNumber;
    private List<Objective> _objectives;

    // Start is called before the first frame update
    void Start()
    {
        _objectives = GetComponentsInChildren<Objective>().ToList();
        initialObjectiveNumber = _objectives.Count();
    }

    // Update is called once per frame
    void Update()
    {
        _objectives.Select(s => s.isActiveAndEnabled).Count();
    }

    public void RemoveObjective(Objective obj)
    {
        obj.gameObject.SetActive(false);
        _objectives.Remove(obj);
    }

    public float GetObjectiveNumber()
    {
        return _objectives.Count();
    }
}
