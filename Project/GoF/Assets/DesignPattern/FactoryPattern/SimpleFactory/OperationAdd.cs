/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPattern
{
    /// <summary>
    /// 加法操作
    /// </summary>
    public class OperationAdd : Operation
    {
        public override float GetResult()
        {
            return numberA + numberB;
        }
    }
}


