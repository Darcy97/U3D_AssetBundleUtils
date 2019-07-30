/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 17:58:23
 * @LastEditTime: 2019-07-30 18:06:02
 */
 using UnityEngine;
 using UnityEngine.UI;
namespace DesignPattern{
    public static class DesignPatternsHelper {
        
        public static Button GetStartButton(Transform patternTrans){
            return patternTrans.Find("Canvas/Start").GetComponent<Button>();
        }

    }
}