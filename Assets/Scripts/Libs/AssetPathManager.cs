/*
 * @Descripttion: AssetPathManager
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-18 11:53:31
 * @LastEditTime: 2019-07-18 15:11:26
 */
using UnityEngine;
namespace Libs
{
    public class AssetPathManager
    {
        public static string GetAssetBundleOutPutPath ()
        {
            return Application.streamingAssetsPath;
        }

    }
}