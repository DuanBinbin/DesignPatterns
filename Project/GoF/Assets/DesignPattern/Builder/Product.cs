/*==============================
* author:		Duanbin
* time:			$time$  
* description:	
* function:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildPattern
{
    /// <summary>
    /// 产品
    /// 必须提供方法让Builder类可以将各个部位功能设置给Product
    /// </summary>
    public class Product
    {

        private List<string> _part = new List<string>();

        public Product()
        {

        }

        public void AddPart(string part)
        {
            _part.Add(part);
        }

        public void ShowProduct()
        {
            foreach (string part in _part)
            {
                Debug.Log(GetType() + " -->" + part);               
            }
        }
    }
}


