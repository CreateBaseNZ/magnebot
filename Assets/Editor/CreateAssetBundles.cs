using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateAssetBundles
{
    //Creates a new menu (Build Asset Bundles) and item (Normal) in the Editor
    [MenuItem("Assets/Build Asset Bundles/Normal")]
    static void BuildABsNone()
    {
        //Create a folder to put the Asset Bundle in.
        // This puts the bundles in your custom folder (this case it's "MyAssetBuilds") within the Assets folder.
        //Build AssetBundles with no special options
        //Build the AssetBundles in uncompressed build mode
        string assetBundleDirectory = "Assets/MyAssetBuilds";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.WebGL);
    }

    //Creates a new item (Chunk Based Compression) in the new Build Asset Bundles menu
    [MenuItem("Assets/Build Asset Bundles/Chunk Based Compression ")]
    static void BuildABsChunk()
    {
        //Build the AssetBundles in this mode
        string assetBundleDirectory = "Assets/MyAssetBuilds";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.WebGL);
    }

    //Creates a new item (Uncompressed) in the new Build Asset Bundles menu
    [MenuItem("Assets/Build Asset Bundles/Uncompressed ")]
    static void BuildABsUncompressed()
    {
        //Build the AssetBundles in uncompressed build mode
        string assetBundleDirectory = "Assets/MyAssetBuilds";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.WebGL);
    }
}