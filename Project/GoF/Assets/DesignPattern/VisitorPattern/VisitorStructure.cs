/*
* ==============================
* FileName:		VisitorStructure
* Author:		DuanBin
* CreateTime:	8/7/2018 3:32:24 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisitorStructure
{
	public class VisitorStructure : MonoBehaviour {
	
		void Start () {
            // setup structure
            ObjectStructure os = new ObjectStructure();
            os.Attach(new ConcreteElementA());
            os.Attach(new ConcreteElementB());

            // create visitor objects
            ConcreteVisitor1 visitor1 = new ConcreteVisitor1();
            ConcreteVisitor2 visitor2 = new ConcreteVisitor2();

            // structure accepting visitors
            os.Accept(visitor1);
            os.Accept(visitor2);
		}
	}

    public abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }

    public class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Debug.Log(concreteElementA.GetType().Name + " visited by " + this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Debug.Log(concreteElementB.GetType().Name + " visited by " + this.GetType().Name);
        }
    }

    public class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Debug.Log(concreteElementA.GetType().Name + " visited by " + this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Debug.Log(concreteElementB.GetType().Name + " visited by " + this.GetType().Name);
        }
    }

    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    public class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {
            Debug.Log(GetType() + ",ConcreteElementA.OperationA");
        }
    }

    public class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {

        }
    }

    public class ObjectStructure
    {
        private List<Element> _elementsList = new List<Element>();

        public void Attach(Element theElement)
        {
            _elementsList.Add(theElement);
        }

        public void Detach(Element theElement)
        {
            _elementsList.Remove(theElement);
        }

        public void Accept(Visitor theVisitor)
        {
            foreach (Element element in _elementsList)
            {
                element.Accept(theVisitor);
            }
        }
    }
}


