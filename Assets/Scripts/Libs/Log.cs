using UnityEngine;

namespace Libs
{
    public class Log
    {

        public static void Print (string message)
        {
            if (GameConstants.IsDebugLog)
                Debug.Log(message);
        }

        public static void Error(string error){
            if(GameConstants.IsDebugLog){
                Debug.Log(error);
            }
        }
    }
}