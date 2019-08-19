/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 19:31:21
 * @LastEditTime: 2019-08-19 20:24:06
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Libs;
using UnityEngine;

namespace OperationListener
{

	public class PlayerOperationListener : OperationListener
	{

		public const string OperationListenerKey = "Operation";

		#region Instance Field
		public static PlayerOperationListener Instance
		{
			get
			{
				return Singleton<PlayerOperationListener>.Instance;
			}
		}

		private PlayerOperationListener () { }
		#endregion
		

		protected override void NotifyObserver (OperationMessage message, IOperationObserver observer, OperationType opType)
		{
			if (message == null)
				return;
			if (observer == null)
				return;

			switch (opType)
			{
				case OperationType.Purchase:
					var obPurchase = observer as IOperationObserverPurchase;
					obPurchase.ObserverUpdatePurchase (message as OperationMessagePurchase);
					break;
				case OperationType.Spin:
					var obSpin = observer as IOperationObserverSpin;
					obSpin.ObserverUpdateSpin (message as OperationMessageSpin);
					break;
			}
		}

		protected override List<OperationType> ParseOperationTypeOfObserver (IOperationObserver observer)
		{
			if (observer == null)
				return null;

			List<OperationType> result = new List<OperationType> ();

			if (observer is IOperationObserverSpin)
				result.Add (OperationType.Spin);

			if (observer is IOperationObserverPurchase)
				result.Add (OperationType.Purchase);

			if (result == null)
				Debug.LogError ("请添加对应类型判断");

			return result;
		}
	}
}