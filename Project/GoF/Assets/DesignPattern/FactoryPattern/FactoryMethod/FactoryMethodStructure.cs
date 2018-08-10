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

namespace FactoryMethodStructure
{
    using FactoryMethodStructure_Base;
    using FactoryMethodStructure_Subclass;
    using FactoryMethodStructure_MethodType;
    using FactoryMethodStructure_GenericClass;
    using FactoryMethodStructure_GenericMethod;

    public class FactoryMethodStructure : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Debug.Log("第一种方式：由子类产生");
            Factory factory1 = new ConcreteCreatorProductA();
            factory1.FactoryMethod();
            Factory factory2 = new ConcreteCreatorProductB();
            factory2.FactoryMethod();                    

            Debug.Log("\n ---------------------------------- \n");

            Debug.Log("第二种方式：在FactoryMethod 增加参数");
            ConcreteCreator_MethodType creator_methodType = new ConcreteCreator_MethodType();
            Product product_MethodType = creator_methodType.FactoryMethod(2);

            Debug.Log("\n ---------------------------------- \n");

            Debug.Log("第三种方式：Creator 泛型类");
            Creator_GenericClass<ConcreteProductB> creator_GenericClass = new Creator_GenericClass<ConcreteProductB>();
            creator_GenericClass.FactoryMethod();

            Debug.Log("\n ---------------------------------- \n");

            Debug.Log("第四种方式：FactoryMethod 泛型方法");
            ConcreteCreator_GenericMethod creator_GenericMethod = new ConcreteCreator_GenericMethod();
            creator_GenericMethod.FactoryMethod<ConcreteProductB>();
        }
    }
}

namespace FactoryMethodStructure_Subclass
{
    using FactoryMethodStructure_Base;
    /// <summary>
    /// 工厂接口
    /// 说明：负责定义创建产品对象的公共接口
    /// </summary>
    public abstract class Factory
    {
        public abstract Product FactoryMethod();
    }

    /// <summary>
    /// 产生ProductA的工厂
    /// 说明：负责生成具体的产品对象，目的是将产品类的实例化操作延迟到工厂子类去完成，
    /// 即通过工厂子类来确定究竟应该实例化哪一个具体产品类
    /// </summary>
    public class ConcreteCreatorProductA : Factory
    {
        public ConcreteCreatorProductA()
        {
            Debug.Log(GetType() + " --> ConcreteCreatorProductA");
        }

        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// 产生ProductB的工厂
    /// </summary>
    public class ConcreteCreatorProductB : Factory
    {
        public ConcreteCreatorProductB()
        {
            Debug.Log(GetType() + " --> ConcreteCreatorProductB");
        }

        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }    
}

/// <summary>
/// 在FactoryMethod 增加参数
/// </summary>
namespace FactoryMethodStructure_MethodType
{
    using System;
    using FactoryMethodStructure_Base;

    public abstract class Creator_MethodType
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator_MethodType : Creator_MethodType
    {
        public ConcreteCreator_MethodType()
        {
            Debug.Log(GetType() + "--> 产生工厂  ConcreteCreator_MethodType");
        }

        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                case 1:
                    return new ConcreteProductA();
                case 2:
                    return new ConcreteProductB();
                default:
                    Debug.Log("Type[" + type + "]无法产生对象");
                    return null;
            }
        }
    }
}

namespace FactoryMethodStructure_GenericClass
{
    using FactoryMethodStructure_Base;

    public class Creator_GenericClass<T> where T : Product, new()
    {
        public Creator_GenericClass()
        {
            Debug.Log("产生工厂:Creator_GenericClass<" + typeof(T).ToString() + ">");
        }

        public Product FactoryMethod()
        {
            return new T();
        }
    }
}

namespace FactoryMethodStructure_GenericMethod
{
    using System;
    using FactoryMethodStructure_Base;

    public interface Creator_GenericMethod
    {
        Product FactoryMethod<T>() where T : Product, new();
    }

    public class ConcreteCreator_GenericMethod : Creator_GenericMethod
    {
        public ConcreteCreator_GenericMethod()
        {
            Debug.Log(GetType() + " --> 产生工厂：ConcreteCreator_GenericMethod");
        }

        public Product FactoryMethod<T>() where T : Product, new()
        {
            return new T();
        }
    }
}

namespace FactoryMethodStructure_Base
{
    /// <summary>
    /// 抽象产品接口
    /// </summary>
    public class Product
    {

    }

    /// <summary>
    /// 具体产品A
    /// </summary>
    public class ConcreteProductA : Product
    {
        public ConcreteProductA()
        {
            Debug.Log(GetType() + " --> ConcreteProductA");
        }
    }

    /// <summary>
    /// 具体产品B
    /// </summary>
    public class ConcreteProductB : Product
    {
        public ConcreteProductB()
        {
            Debug.Log(GetType() + " --> ConcreteProductB");
        }
    }
}