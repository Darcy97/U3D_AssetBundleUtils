/*
 * @Descripttion: Bundle Build
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-18 11:43:33
 * @LastEditTime: 2019-07-19 20:05:49
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Libs;
using UnityEditor;
using UnityEngine;

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
            //*该方法会自动检查目标路径下是否存在需要 build 的 bundle 已经存在的不会重新打包 不是单纯的名字检查 会检查bundle与要打得bundle是否符合*/
            AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles (outputPath, option, BuildTarget.iOS);
            Log.Print ("Build succeed", manifest.GetAllAssetBundles().ToString());
            AssetDatabase.Refresh ();
        }

        public static bool DeleteAllFile ()
        {
            string fullPath = AssetPathManager.GetAssetBundleOutPutPath ();
            //获取指定路径下面的所有资源文件  然后进行删除
            if (Directory.Exists (fullPath))
            {
                DirectoryInfo direction = new DirectoryInfo (fullPath);
                FileInfo[] files = direction.GetFiles ("*", SearchOption.AllDirectories);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith (".meta"))
                    {
                        continue;
                    }
                    string FilePath = fullPath + "/" + files[i].Name;

                    File.Delete (FilePath);
                }
                return true;
            }
            return false;
        }
    }
}