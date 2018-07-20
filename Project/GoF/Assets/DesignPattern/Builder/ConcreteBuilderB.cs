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
    public class ConcreteBuilderB : Builder
    {
        public override void BuildPart1(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderB_Part1");
        }

        public override void BuildPart2(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderB_Part2");
        }
    }
}


