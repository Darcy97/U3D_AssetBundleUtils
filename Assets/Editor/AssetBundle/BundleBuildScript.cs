/*
 * @Descripttion: Bundle Build
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-18 11:43:33
 * @LastEditTime: 2019-07-18 15:11:48
 */

using System.IO;
using UnityEditor;
using UnityEngine;
using Libs;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;
using System.Linq;

namespace AssetBundleLibs
{
    public class BundleBuildScript
    {

        public static void BuildAssetBundlesAll ()
        {
            string outputPath = AssetPathManager.GetAssetBundleOutPutPath ();
            if (!Directory.Exists (outputPath))
                Directory.CreateDirectory (outputPath);

             BuildAssetBundleOptions option = BuildAssetBundleOptions.DeterministicAssetBundle;
             BuildPipeline.BuildAssetBundles (outputPath, option, BuildTarget.iOS);
             AssetDatabase.Refresh();
        }
    }
}