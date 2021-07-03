using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ObjectSelection : MonoBehaviour
{
    private List<GameObject> _objects;

    // Start is called before the first frame update
    void Start()
    {
        _objects = GetComponentsInChildren<RectTransform>()
            .Where(w => w.parent == gameObject.GetComponent<RectTransform>())
            .Select(s => s.gameObject)
            .ToList();

        _objects.ForEach(f => f.SetActive(false));
        _objects[PlayerPrefs.GetInt("backgroundId")].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectObject(int id)
    {
        _objects.ForEach(f => f.SetActive(false));
        _objects[id].SetActive(true);
        PlayerPrefs.SetInt("backgroundId", id);
    }
}
