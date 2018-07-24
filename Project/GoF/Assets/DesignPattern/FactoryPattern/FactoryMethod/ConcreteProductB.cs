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

namespace FactoryMethodPattern{
    /// <summary>
    /// 具体产品B
    /// </summary>
	public class ConcreteProductB : Product
    {
        public ConcreteProductB()
        {
            Debug.Log(GetType() + "--> ConcreteProductB");
        }
		
	}
}


