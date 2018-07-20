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

namespace BuildPattern
{
    /// <summary>
    /// 功能实现者
    /// </summary>
    public abstract class Builder
    {
        public abstract void BuildPart1(Product theProduct);
        public abstract void BuildPart2(Product theProduct);
    }
}


