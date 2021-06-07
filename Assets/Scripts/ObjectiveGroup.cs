using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices;

public class ObjectiveGroup : MonoBehaviour
{
    public ObjectiveProgress objectiveProgress;
    private int _initialObjectives;
    private int _numberOfObjectives;

    [DllImport("__Internal")]
    private static extern void GetProgressState(float progress);

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

        var progress = (_initialObjectives - _numberOfObjectives) / (float)_initialObjectives;

#if !UNITY_EDITOR && UNITY_WEBGL
        GetProgressState(progress);
#endif

        if (_numberOfObjectives == 0)
        {
            GameController.Instance.GameWin();
        }
    }

}
