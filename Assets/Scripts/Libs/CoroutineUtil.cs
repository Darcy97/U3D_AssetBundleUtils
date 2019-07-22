/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-22 12:57:09
 * @LastEditTime: 2019-07-22 12:58:48
 */
using System.Collections;
using UnityEngine;

namespace Libs
{
	public class CoroutineUtil : MonoBehaviour
	{
		static private CoroutineUtil _instance = null;

		static public CoroutineUtil Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameObject ("YieldUtil", typeof (CoroutineUtil)).GetComponent<CoroutineUtil> ();
					_instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
					DontDestroyOnLoad (_instance.gameObject);
				}
				return _instance;
			}
		}
		public static IEnumerator DelayAction (float dTime, System.Action callback)
		{
			yield return new WaitForSeconds (dTime);
			callback ();
		}

		public static void DoDelayAction (float dTime, System.Action callback)
		{
			Instance.StartCoroutine (DelayAction (dTime, callback));
		}
	}
}