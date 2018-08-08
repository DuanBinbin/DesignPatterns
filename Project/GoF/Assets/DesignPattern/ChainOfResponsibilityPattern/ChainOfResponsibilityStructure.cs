/*
* ==============================
* FileName:		ChainOfResponsibilityStructure
* Author:		DuanBin
* CreateTime:	8/8/2018 7:43:16 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainOfResponsibilityStructure
{
	public class ChainOfResponsibilityStructure : MonoBehaviour {
	
		void Start () {
            // setup chain of responsibility
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // generate and process request
            int[] requests = { 2, 5, 18, 22, 33, 27, 3, 30 };
            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
		}
	}

    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    /// <summary>
    /// The 'ConcreteHandler1' class
    /// </summary>
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Debug.Log(this.GetType().Name + " handled request " + request);
            }
            else if(successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler2' class
    /// </summary>
    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Debug.Log(this.GetType().Name + " handled request " + request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler3' class
    /// </summary>
    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Debug.Log(this.GetType().Name + " handled request " + request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}


