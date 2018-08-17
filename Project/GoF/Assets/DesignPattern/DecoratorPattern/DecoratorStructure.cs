/*
* ==============================
* FileName:		DecoratorStructure
* Author:		DuanBin
* CreateTime:	8/14/2018 2:54:40 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorStructure
{
	public class DecoratorStructure : MonoBehaviour {
	
		void Start () {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent component = new ConcreteComponent();
            ConcreteDecoratorA decoratorA = new ConcreteDecoratorA();
            ConcreteDecoratorB decoratorB = new ConcreteDecoratorB();

            // Link decorators
            decoratorA.SetComponent(component);
            decoratorB.SetComponent(component);

            decoratorB.Operation();
		}
	}

    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Debug.Log("ConcreteComponent.Operation()");
        }
    }

    public abstract class Decorator : Component
    {
        protected Component m_component;

        public void SetComponent(Component component)
        {
            m_component = component;
        }

        public override void Operation()
        {
            if (m_component != null)
            {
                m_component.Operation();
            }
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Debug.Log("ConcreteDecoratorA.Operation()");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddBehavior();
            Debug.Log("ConcreteDecoratorB.Operation()");
        }

        private void AddBehavior()
        {
            Debug.Log("ConcreteDecoratorB.AddBehavior()");
        }
    }
}


