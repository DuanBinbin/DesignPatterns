/*
* ==============================
* FileName:		MediatorStructure
* Author:		DuanBin
* CreateTime:	8/13/2018 12:15:32 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MediatorStructure
{
	public class MediatorStructure : MonoBehaviour {
	
		void Start () {

            ConcreteMediator mediator = new ConcreteMediator();

            ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
            ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;

            colleague1.Send("How are you");
            colleague2.Send("Fine, thanks");
		}
	}

    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    public class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 _colleague1;
        private ConcreteColleague2 _colleague2;

        public ConcreteColleague1 Colleague1
        {
            set
            {
                _colleague1 = value;
            }
        }

        public ConcreteColleague2 Colleague2
        {
            set
            {
                _colleague2 = value;
            }
        }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == _colleague1)
            {
                _colleague2.Notify(message);
            }
            else
            {
                _colleague1.Notify(message);
            }
        }
    }

    public abstract class Colleague
    {
        protected Mediator m_mediator;

        public Colleague(Mediator mediator)
        {
            m_mediator = mediator;
        }
    }

    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            m_mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Debug.Log("ConcreteColleague1 gets message : " + message);
        }
    }

    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            m_mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Debug.Log("ConcreteColleague2 gets message : " + message);
        }
    }
}


