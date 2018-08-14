/*
* ==============================
* FileName:		ProxyStructure
* Author:		DuanBin
* CreateTime:	8/14/2018 2:17:23 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProxyStructure
{
	public class ProxyStructure : MonoBehaviour {
	
		void Start () {
            // Create proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();
		}
	}

    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Debug.Log("Called RealSubject.Request()");
        }
    }

    public class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }
    }
}


