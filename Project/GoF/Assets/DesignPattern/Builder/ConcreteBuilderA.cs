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

namespace BuildPattern{
    /// <summary>
    /// 具体功能实现A
    /// </summary>
	public class ConcreteBuilderA : Builder
    {
        public override void BuildPart1(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderA_Part1");
        }

        public override void BuildPart2(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderA_Part2");
        }
    }
}


