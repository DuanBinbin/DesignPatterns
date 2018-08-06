/*==============================
* author:		Duanbin
* time:			2018.08.01
* description:	
* function:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverStructure
{
    public class ObserverStructure : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "X"));
            subject.Attach(new ConcreteObserver(subject, "Y"));
            subject.Attach(new ConcreteObserver(subject, "Z"));

            subject.SubjectState = "ABC";
            subject.Notify();

            subject.SubjectState = "EFG";
            subject.Notify();
        }
    }

    /// <summary>
    /// knows its observers.Any number of Observer objects may observe a subject
    /// provides an interface for attaching and detaching Observer objects.
    /// </summary>
    public abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer item in _observers)
            {
                item.Update();
            }
        }
    }

    /// <summary>
    /// stores state of interest to ConcreteObserver
    /// sends a notification to its observers when its state changes
    /// </summary>
    public class ConcreteSubject : Subject
    {
        private string _subjectState;

        public string SubjectState
        {
            get
            {
                return _subjectState;
            }

            set
            {
                _subjectState = value;
            }
        }
    }

    /// <summary>
    /// defines an updating interface for objects that should be notified of changes in a subject.
    /// </summary>
    public abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// maintains a reference to a ConcreteSubject object
    /// stores state that should stay consistent with the subject's
    /// implements the Observer updating interface to keep its state consistent with the subject's
    /// </summary>
    public class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject,string name)
        {
            Subject = subject;
            _name = name;
        }

        public ConcreteSubject Subject
        {
            get
            {
                return _subject;
            }

            set
            {
                _subject = value;
            }
        }

        public override void Update()
        {
            _observerState = Subject.SubjectState;
            Debug.Log(GetType() + " , Observer " + _name + "'s new state is " + _observerState);
        }
    }
}