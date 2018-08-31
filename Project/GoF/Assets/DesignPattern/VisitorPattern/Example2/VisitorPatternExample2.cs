/*
* ==============================
* FileName:		VisitorPatternExample2
* Author:		DuanBin
* CreateTime:	8/31/2018 3:09:29 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisitorPatternExample2
{
	public class VisitorPatternExample2 : MonoBehaviour {
	
		void Start () {
            Test();
		}

        void Test()
        {
            ObjectStructure os = new ObjectStructure();
            os.Attach(new Man());
            os.Attach(new Woman());

            Success v1 = new Success();
            os.Display(v1);

            Failing v2 = new Failing();
            os.Display(v2);

            Amativeness v3 = new Amativeness();
            os.Display(v3);
        }
	}

    public abstract class Action
    {
        public abstract void GetManConclusion(Man concreteElementA);
        public abstract void GetWomanConclusion(Woman concreteElementB);
    }

    public abstract class Person
    {
        // 接受
        public abstract void Accept(Action visitor);
    }

    public class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }

        public override string ToString()
        {
            return "Man";
        }
    }

    public class Woman : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }

        public override string ToString()
        {
            return "Woman";
        }
    }

    public class Success : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Debug.LogFormat("{0} {1}时，背后多半有一个伟大的女人", concreteElementA.ToString(), ToString());
        }

        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Debug.LogFormat("{0} {1}时，背后多半有一个不负责任的男人", concreteElementB.ToString(), ToString());
        }

        public override string ToString()
        {
            return "Success";
        }
    }

    public class Failing : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Debug.LogFormat("{0} {1}时，蒙头喝酒，谁也不用劝", concreteElementA.ToString(), ToString());
        }

        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Debug.LogFormat("{0} {1}时，泪眼汪汪，谁也劝不了", concreteElementB.ToString(), ToString());
        }

        public override string ToString()
        {
            return "Failing";
        }
    }

    public class Amativeness : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Debug.LogFormat("{0} {1}时，凡事不懂也要装懂", concreteElementA.ToString(), ToString());
        }

        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Debug.LogFormat("{0} {1}时，凡事懂也要装不懂", concreteElementB.ToString(), ToString());
        }

        public override string ToString()
        {
            return "Amativeness";
        }
    }

    /// <summary>
    /// 对象结构
    /// </summary>
    public class ObjectStructure
    {
        private List<Person> _elements = new List<Person>();

        public void Attach(Person element)
        {
            _elements.Add(element);
        }

        public void Deatach(Person element)
        {
            _elements.Remove(element);
        }

        public void Display(Action visitor)
        {
            foreach (Person item in _elements)
            {
                item.Accept(visitor);
            }
        }
    }

}