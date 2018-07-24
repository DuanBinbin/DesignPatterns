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
    /// 具体产品A
    /// </summary>
	public class ConcreteProductA:Product {
        
        public ConcreteProductA()
        {
            Debug.Log(GetType() + "-->ConcreteProductA");
        }		
	}
}


