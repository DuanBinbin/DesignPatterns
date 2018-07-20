/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		测试建造者模式
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildPattern{
	public class TestBuildPattern  {

		public static void execute()
        {          
            Director director = new Director();
            director.Construct(new ConcreteBuilderA());
            director.GetResult().ShowProduct();
            director.GetResult().GetType();
        }
	}
}


