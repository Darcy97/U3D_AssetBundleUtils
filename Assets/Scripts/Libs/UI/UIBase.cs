/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-26 20:08:16
 * @LastEditTime: 2019-07-26 20:40:55
 */
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Libs
{
    public class UIBase : UIBehaviour
    {

        protected RectTransform m_RectTransForm;
        protected object m_Data;

        #region Mono Func
        protected override void Awake ()
        {
            m_RectTransForm = transform as RectTransform;
        }

        protected override void Start ()
        {

        }

        protected override void OnDestroy ()
        {

        }

        protected override void OnEnable ()
        {

        }

        #endregion

        #region External Func

        /// <summary>
        /// set data
        /// 默认刷新
        /// </summary>
        /// <param name="data"></param>
        /// <param name="needRefresh"></param>
        public virtual void SetData (object data, bool needRefresh = true)
        {
            m_Data = data;
            if (needRefresh)
                Refresh ();

        }

        public virtual void Refresh ()
        {

        }

        #endregion

        #region Internal Func
        protected virtual void OnButtonClickHandler (GameObject button)
        {
            //* tobe override */
            //* 统一处理按钮事件 */

            //* 延迟处理下一次点击 */
            WaitForNextClick ();
        }

        protected float waitSecond = 0.5f;
        private void WaitForNextClick ()
        {
            EventSystem.current.enabled = false;
            CoroutineUtil.DoDelayAction (waitSecond,
                () =>
                {
                    EventSystem.current.enabled = true;
                });
        }

        protected virtual void onToggleSelect(GameObject toggle,bool isSelect)
		{
            //*统一处理 toggle 事件 */
		}

        #endregion

    }
}