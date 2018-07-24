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


namespace PrototypePattern
{
    /// <summary>
    /// 具体原型类A
    /// </summary>
    public class ConcretePrototypeA : Prototype
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        public ConcretePrototypeA(string id) : base(id)
        {

        }

        /// <summary>
        /// 抽象方法实现
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

}



