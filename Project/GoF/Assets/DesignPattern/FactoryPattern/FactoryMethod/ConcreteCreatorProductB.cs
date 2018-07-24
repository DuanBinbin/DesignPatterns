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

namespace FactoryMethodPattern{
	public class ConcreteCreatorProductB : Factory {
        public ConcreteCreatorProductB()
        {
            Debug.Log(GetType() + "ConcreteCreatorProductB");
        }

        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}


