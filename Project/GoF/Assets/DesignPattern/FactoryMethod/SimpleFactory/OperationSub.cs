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
    public class OperationSub : Operation
    {
        public override float GetResult()
        {
            return numberA - numberB;
        }
    }
}


