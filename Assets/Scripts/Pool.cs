using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PooledObject
{
    public GameObject Object;
    public string Key;
}

public class Pool : MonoBehaviour
{
    #region Singleton
    public static Pool Instance { get { return _instance; } }
    private static Pool _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    public PooledObject[] Objects;
    private Dictionary<string, List<GameObject>> pool;

    void Start()
    {
        GameObject temp;
        pool = new Dictionary<string, List<GameObject>>();

        for (int i = 0; i < Objects.Length; i++)
        {
            temp = Instantiate(Objects[i].Object);
            temp.SetActive(false);
            temp.transform.parent = transform;

            if (!pool.ContainsKey(Objects[i].Key))
            {
                pool.Add(Objects[i].Key, new List<GameObject>());
            }
            pool[Objects[i].Key].Add(temp);
        }

    }
    
    public GameObject Activate(string key, Vector3 position, bool overrideY = false)
    {
        var filteredPool = pool[key].Where(w => !w.activeInHierarchy).ToList();
        if (filteredPool.Count == 0)
        {
            GameObject temp;

            for (int i = 0; i < Objects.Length; i++)
            {
                if(Objects[i].Key == key)
                {
                    temp = Instantiate(Objects[i].Object);
                    temp.SetActive(false);
                    temp.transform.parent = transform;
                    pool[key].Add(temp);
                    filteredPool.Add(temp);
                }
            }

        }

        GameObject obj = filteredPool[Random.Range(0, filteredPool.Count)];
        obj.SetActive(true);
        if (overrideY)
        {
            obj.transform.position = new Vector3(position.x, position.y, obj.transform.position.z);
        }
        else
        {
            obj.transform.position = new Vector3(position.x, obj.transform.position.y, obj.transform.position.z);
        }
        return obj;
    }

    public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
    }
}