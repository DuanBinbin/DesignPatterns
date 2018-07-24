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
using FactoryPattern;
using UnityEngine;

namespace FactoryPattern
{
    public class DivFactory : IFactory
    {

        public Operation CreateOperation()
        {
            return new OperationDiv();
        }
    }
}


