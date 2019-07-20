/*
 * @Descripttion: AssetPathManager
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-18 11:53:31
 * @LastEditTime: 2019-07-20 17:13:36
 */
using UnityEditor;

using UnityEngine;
namespace Libs
{
    public class AssetPathManager
    {
        public static string GetAssetBundleOutPutPath ()
        {
            return Application.streamingAssetsPath;
        }

        public static string GetPlatformName ()
        {
#if UNITY_EDITOR
            return GetPlatformForBundles (EditorUserBuildSettings.activeBuildTarget);
#else
            return GetPlatformForBundles (Application.platform);
#endif
        }

        private const string PLATFROM_ANDROID = "Android";
        private const string PLATFROM_IOS = "iOS";
        private const string PLATFROM_WEB_GL = "WebGL";
        private const string PLATFROM_WEB_PLAYER = "WebPlayer";
        private const string PLATFROM_WINDOWS = "Windows";
        private const string PLATFROM_OSX = "OSX";

#if UNITY_EDITOR
        private static string GetPlatformForBundles (BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return PLATFROM_ANDROID;
                case BuildTarget.iOS:
                    return PLATFROM_IOS;
                case BuildTarget.WebGL:
                    return PLATFROM_WEB_GL;
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return PLATFROM_WINDOWS;
                case BuildTarget.StandaloneOSX:
                    return PLATFROM_OSX;
                    // Add more build targets for your own.
                    // If you add more targets, don't forget to add the same platforms to GetPlatformForBundles(RuntimePlatform) function.
                default:
                    Log.Error ("Please add new buildtarget for your selected target", target.ToString ());
                    return null;
            }
        }
#endif
        private static string GetPlatformForBundles (RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                    return PLATFROM_ANDROID;
                case RuntimePlatform.IPhonePlayer:
                    return PLATFROM_IOS;
                case RuntimePlatform.WebGLPlayer:
                    return PLATFROM_WEB_GL;
                case RuntimePlatform.WindowsPlayer:
                    return PLATFROM_WINDOWS;
                case RuntimePlatform.OSXPlayer:
                    return PLATFROM_OSX;
                    // Add more build targets for your own.
                    // If you add more targets, don't forget to add the same platforms to GetPlatformForBundles(EditorBuildTarget) function.
                default:
                    Log.Error ("Please add new buildtarget for your current platform", platform.ToString ());
                    return null;
            }
        }

    }
}