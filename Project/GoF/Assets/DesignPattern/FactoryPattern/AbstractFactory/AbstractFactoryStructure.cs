/*==============================
* author:		Duanbin
* time:			2018.07.30
* description:	
* function:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryStructure
{
    public class AbstractFactoryStructure : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            // Abstract Factory #1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract Factory #2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }

    /// <summary>
    /// AbstractFactory,declares an interface for operations that create abstract products   
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();            
    }

    /// <summary>
    ///ConcreteFactory,implements the operations to create concrete product objects
    /// </summary>
    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    /// <summary>
    /// AbstractProduct,declares an interface for a type of product object
    /// </summary>
    public abstract class AbstractProductA
    {

    }

    public abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA productA);
    }

    /// <summary>
    /// 1.defines a product object to be created by the corresponding concrete factory
    /// 2.implements the AbstractProduct interface
    /// </summary>
    public class ProductA1: AbstractProductA
    {

    }

    public class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA productA)
        {
            Debug.Log(GetType().Name + "interacts with" + productA.GetType().Name);
        }
    }

    public class ProductA2 : AbstractProductA
    {

    }

    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA productA)
        {
            Debug.Log(GetType().Name + "interacts with" + productA.GetType().Name);
        }
    }

    /// <summary>
    /// Client,uses interfaces declared by AbstractFactory and AbstractProduct classes
    /// </summary>
    public class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}



