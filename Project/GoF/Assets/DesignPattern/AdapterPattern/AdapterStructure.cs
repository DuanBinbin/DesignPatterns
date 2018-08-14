/*
* ==============================
* FileName:		AdapterStructure
* Author:		DuanBin
* CreateTime:	8/14/2018 11:27:03 AM
* Description:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdapterStructure
{
	public class AdapterStructure : MonoBehaviour {
	
		void Start () {
            Target target = new Adapter();
            target.Request();
		}   
	}

    public class Target
    {
        public virtual void Request()
        {
            Debug.Log("Called Target Request()");
        }
    }

    public class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Debug.Log("Called Adaptee SpecificRequest()");
        }
    }
}