/*
* ==============================
* FileName:		BridgeStructure
* Author:		DuanBin
* CreateTime:	8/14/2018 2:32:08 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeStructure
{
	public class BridgeStructure : MonoBehaviour {
	
		void Start () {
            Abstraction ab = new Abstraction();

            // Set implemention and call
            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            // Change implemention and call
            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();
		}
	}

    public class Abstraction
    {
        protected Implementor m_implementor;

        public Implementor Implementor
        {
            set
            {
                m_implementor = value;
            }
        }

        public virtual void Operation()
        {
            m_implementor.Operation();
        }
    }

    public abstract class Implementor
    {
        public abstract void Operation();
    }

    public class RefinedAbstraction :Abstraction
    {
        public override void Operation()
        {
            m_implementor.Operation();
        }
    }

    public class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Debug.Log("ConcreteImplementorA.Operation()");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Debug.Log("ConcreteImplementorB.Operation()");
        }
    }
}