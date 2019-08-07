/*
 * @Descripttion: GameConstant
 * @version: 0.0.1
 * @Author: Darcy
 * @Date: 2019-07-18 14:21:42
 * @LastEditTime: 2019-08-07 12:06:04
 */
using System;
using UnityEngine;
namespace Libs
{
    public static class GameConstants
    {

        public const string BUNDLE_DOWNLOAD_URL = "http://127.0.0.1/Bundles";

        public const Boolean IS_DEBUG_LOG = true;

        public const string VERSION = "0.0.1";

        public static string[] WYS_IMG_NAME_ARRAY = {
            "WYS_0",
            "WYS_1",
            "WYS_2",
            "WYS_3",
            "WYS_4",
            "WYS_5",
            "WYS_6",
            "WYS_7",
            "WYS_8",
            "WYS_9",
            "WYS_10",
            "WYS_11",
            "WYS_12",
            "WYS_13",
            "WYS_14",
        };

        public static string[] IRVUE_IMG_NAME_ARRAYs = {
            "Irvue_0",
            "Irvue_1",
            "Irvue_2",
            "Irvue_3",
            "Irvue_4",
            "Irvue_5",
            "Irvue_6",
            "Irvue_7",
            "Irvue_8",
            "Irvue_9",
            "Irvue_10",
            "Irvue_11",
            "Irvue_12",
            "Irvue_13",
            "Irvue_14",
        };

        public const String WYS_SCENE_NAME = "WYSImage";
        public const string IRVUE_SCENE_NAME = "IrvueImage";
        public const string MAIN_SCENE_NAME = "MainScene";

        public static WaitForSeconds Wait2In10Second = new WaitForSeconds (0.2f);
        public static WaitForSeconds WaitTwoIn100Second = new WaitForSeconds (0.002f);
        public static WaitForSeconds WaitTwoSecond = new WaitForSeconds (2f);
        public static WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();

    }
}