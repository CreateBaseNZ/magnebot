using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader : MonoBehaviour
{
    private AssetBundle bundle;

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject cube = bundle.LoadAsset<GameObject>("RoboticArm 1");
            Instantiate(cube);
        }
    }
    IEnumerator InstantiateObject()
    {
        string url = "https://raw.githubusercontent.com/CreateBaseNZ/cb-simulation-model/main/assets/assetbundletest/arm";
        var request = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.SendWebRequest();
        bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(request);
        
        request.Dispose();
    }

}
