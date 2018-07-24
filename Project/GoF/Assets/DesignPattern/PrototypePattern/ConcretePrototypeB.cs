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
    /// 原型具体实现类B
    /// </summary>
    public class ConcretePrototypeB : Prototype
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        public ConcretePrototypeB(string id) : base(id)
        {
        }

        /// <summary>
        /// 实现父类的抽象方法
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}


