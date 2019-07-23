/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-22 12:57:09
 * @LastEditTime: 2019-07-23 19:36:40
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

		/// <summary>
		/// 延迟执行
		/// </summary>
		/// <param name="dTime">second</param>
		/// <param name="callback"></param>
		public static void DoDelayAction (float dTime, System.Action callback)
		{
			Instance.StartCoroutine (DelayAction (dTime, callback));
		}
	}
}