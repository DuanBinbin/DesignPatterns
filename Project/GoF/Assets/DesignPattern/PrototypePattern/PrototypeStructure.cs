/*==============================
* author:		Duanbin
* time:			2018.07.27
* description:	
* function:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeStructure
{
    public class PrototypeStructure : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            ConcretePrototypeA cpA = new ConcretePrototypeA("A");
            ConcretePrototypeA _cpA = (ConcretePrototypeA)cpA.Clone();
            Debug.Log("TestPrototypePattern:ConcretePrototypeA id = " + _cpA.Id);

            ConcretePrototypeB cpB = new ConcretePrototypeB("B");
            ConcretePrototypeB _cpB = (ConcretePrototypeB)cpB.Clone();
            Debug.Log("TestPrototypePattern: ConcretePrototypeB id = " + _cpB.Id);
        }
    }

    public abstract class Prototype
    {

        private string id;

        public string Id
        {
            get
            {
                return id;
            }
        }

        public Prototype(string id)
        {
            this.id = id;
        }

        public abstract Prototype Clone();
    }

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