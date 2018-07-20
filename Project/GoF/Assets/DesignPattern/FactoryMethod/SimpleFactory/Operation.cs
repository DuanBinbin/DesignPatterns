/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPattern
{
    /// <summary>
    /// 计算基类
    /// </summary>
	public abstract class Operation
    {
        public float numberA;
        public float numberB;

        public abstract float GetResult();      
    }	
}


