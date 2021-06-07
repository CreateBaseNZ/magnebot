using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectiveGroup : MonoBehaviour
{
    public ObjectiveProgress objectiveProgress;
    private int _initialObjectives;
    private int _numberOfObjectives;

    // Start is called before the first frame update
    void Start()
    {
        _initialObjectives = GetComponentsInChildren<Objective>().Select(s => s.transform.parent.gameObject).Count();
        _numberOfObjectives = _initialObjectives;
        objectiveProgress.UpdateText((_initialObjectives - _numberOfObjectives), _initialObjectives);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveObjective(Objective obj)
    {
        obj.gameObject.SetActive(false);
        _numberOfObjectives--;

        objectiveProgress.UpdateText(_initialObjectives - _numberOfObjectives, _initialObjectives);

        if (_numberOfObjectives == 0)
        {
            GameController.Instance.GameWin();
        }
    }
}
