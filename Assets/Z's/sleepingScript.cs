using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepingScript : MonoBehaviour
{
    public GameObject Z;
    public List<GameObject> instantiatedZ;
    public Vector3 testmovement;
    public int count;
    [RangeAttribute(0, 2)] public float testscalespeed;
    public float opacitylvl;
    public float timeOn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeTheZs", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOn )
        {
            CancelInvoke("MakeTheZs");
            foreach (var item in instantiatedZ)
            {
                Destroy(item);
            }
            instantiatedZ.Clear();
            Invoke("TurnOff", 5);
        }
        if (instantiatedZ.Count > count)
        {
            Destroy(instantiatedZ[0]);
            instantiatedZ.RemoveAt(0);
        }
        for (int i = 0; i < Mathf.Min(instantiatedZ.Count, count); i++)
        {
            instantiatedZ[i].transform.position += testmovement * Time.deltaTime;
            instantiatedZ[i].transform.localScale += Vector3.one * testscalespeed * Time.deltaTime;
            instantiatedZ[i].GetComponent<TextMesh>().color -= new Color(0, 0, 0, opacitylvl) * Time.deltaTime;
        }
    }

    void MakeTheZs()
    {
        instantiatedZ.Add(Instantiate(Z));
    }

    void TurnOff()
    {
        enabled = false;
    }
}
