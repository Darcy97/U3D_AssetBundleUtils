using UnityEngine;

namespace Libs
{
    public class Log
    {

        public static void Print (string message, string details = "")
        {
            if (GameConstants.IS_DEBUG_LOG)
            {
                if (details != "")
                    Debug.Log (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " + message + " >> " + details);
                else
                    Debug.Log (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " + message);
            }
        }

        public static void Error (string message, string details = "")
        {
            if (GameConstants.IS_DEBUG_LOG)
            {
                if (details != "")
                    Debug.LogError (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " + message + " >> " + details);
                else
                    Debug.LogError (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " + message);
            }
        }
    }
}