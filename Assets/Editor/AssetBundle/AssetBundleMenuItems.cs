/*
 * @Descripttion: AssetBundleMenuItems
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-18 11:36:09
 * @LastEditTime: 2019-07-18 15:11:51
 */

using UnityEngine.UI;
using UnityEditor;
using UnityEngine;
using Libs;

//todo 添加单独物体或者场景打bundle
namespace AssetBundleLibs
{
    public class AssetBundleMenuItems
    {
        
        [MenuItem ("Libs/AssetBundles/Build AssetBundles")]
        static public void BuildAssetBundles ()
        {

            Log.Print("test");
            BundleBuildScript.BuildAssetBundlesAll ();
        }
    }
}