/*
 * @Descripttion: UnityRelatived
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-20 10:20:15
 * @LastEditTime: 2019-07-20 11:32:55
 */

using UnityEngine;
public class UnityUtil
{
    public static string persistentDataPath
    {
        get
        {
            return Application.persistentDataPath;
        }
    }
}