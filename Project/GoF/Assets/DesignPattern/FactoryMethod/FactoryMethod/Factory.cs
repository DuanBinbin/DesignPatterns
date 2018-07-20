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
    /// 工厂接口
    /// 说明：负责定义创建产品对象的公共接口
    /// </summary>
	public abstract class Factory  {

        public abstract Product FactoryMethod();
		
	}
}


