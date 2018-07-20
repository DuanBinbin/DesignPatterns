/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using UnityEngine;
using SimpleFactoryPattern;

namespace FactoryPattern
{    
    public class TestFactoryPattern  {
          
        public static void TestSimpleFactoryPattern()
        {
            Operation operation = OperationFactory.createOperate("*");
            operation.numberA = 2;
            operation.numberB = 3;
            float result = operation.GetResult();
            Debug.Log("SimpleFactoryPattern result = " + result);           
        }   
	}
}


