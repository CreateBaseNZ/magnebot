using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(InstantiateObject());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator InstantiateObject()
    {
        string url = "http://localhost:5000/assets/assetbundletest/arm";
        var request = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.SendWebRequest();
        AssetBundle bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);
        GameObject cube = bundle.LoadAsset<GameObject>("roboticarm");
        Instantiate(cube);
        request.Dispose();
    }

}
