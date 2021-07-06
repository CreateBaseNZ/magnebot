using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ObjectSelection : MonoBehaviour
{
    public string playerPrefsKey;
    private List<GameObject> _objects;

    // Start is called before the first frame update
    void Start()
    {
        if (transform)
        {
            _objects = GetComponentsInChildren<Transform>(true)
                .Where(w => w.parent == gameObject.GetComponent<Transform>())
                .Select(s => s.gameObject)
                .ToList();
        }
        else
        {
            _objects = GetComponentsInChildren<RectTransform>(true)
                .Where(w => w.parent == gameObject.GetComponent<RectTransform>())
                .Select(s => s.gameObject)
                .ToList();
        }

        _objects.ForEach(f => f.SetActive(false));
        _objects[PlayerPrefs.GetInt(playerPrefsKey)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectObject(int id)
    {
        _objects.ForEach(f => f.SetActive(false));
        _objects[id].SetActive(true);
        PlayerPrefs.SetInt(playerPrefsKey, id);
    }
}
