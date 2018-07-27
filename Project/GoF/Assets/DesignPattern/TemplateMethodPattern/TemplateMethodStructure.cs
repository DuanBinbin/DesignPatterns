/*==============================
* author:		Duanbin
* time:			2018.07.27
* description:	定义一个操作算法的框架，而将一些具体步骤延迟到子类中。使得子类可以不改变
*               一个算法的结构即可重定义该算法的某些特定步骤。
* function:		定义一个抽象类规定一些列抽象方法，在子类中去实现
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TemplateMethodStructure
{
    public class TemplateMethodStructure : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();
        }
    }

    /// <summary>
    /// 定义完整算法的各个步骤及执行顺序
    /// </summary>
    public abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Debug.Log(GetType() + "TemplateMethod");
        }
    }

    /// <summary>
    /// 具体实现A
    /// </summary>
    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Debug.Log(GetType() + "ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Debug.Log(GetType() + "ConcreteClassA.PrimitiveOperation2()");
        }
    }

    /// <summary>
    /// 具体实现B
    /// </summary>
    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Debug.Log(GetType() + "ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Debug.Log(GetType() + "ConcreteClassB.PrimitiveOperation2()");
        }
    }
}




