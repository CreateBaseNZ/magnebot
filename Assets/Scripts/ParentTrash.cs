using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ParentTrash : MonoBehaviour
{
    public List<GameObject> trashBags;
    public float timeOn;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOn)
        {
            trashBags.ForEach(f => f.transform.parent = null);
        }
    }
}
