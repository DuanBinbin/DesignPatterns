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

namespace PrototypePattern
{
    public class TestPrototypePattern
    {

        public static void execute()
        {
            ConcretePrototypeA cpA = new ConcretePrototypeA("A");
            ConcretePrototypeA _cpA = (ConcretePrototypeA)cpA.Clone();
            Debug.Log("TestPrototypePattern:ConcretePrototypeA id = " + _cpA.Id);

            ConcretePrototypeB cpB = new ConcretePrototypeB("B");
            ConcretePrototypeB _cpB = (ConcretePrototypeB)cpB.Clone();
            Debug.Log("TestPrototypePattern: ConcretePrototypeB id = " + _cpB.Id);
        }
    }
}


