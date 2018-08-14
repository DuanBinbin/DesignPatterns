/*
* ==============================
* FileName:		FacadePatternStructure
* Author:		DuanBin
* CreateTime:	8/13/2018 2:34:54 PM
* Description:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FacadePatternStructure
{
	public class FacadePatternStructure : MonoBehaviour {
	
		void Start () {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();
		}   
	}

    public class SubSystemOne
    {
        public void MethodOne()
        {
            Debug.Log(GetType() + " : MethodOne()");
        }
    }

    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            Debug.Log(GetType() + " : MethodTwo()");
        }
    }

    public class SubSystemThree
    {
        public void MethodThree()
        {
            Debug.Log(GetType() + " : MethodThree()");
        }                
    }

    public class SubSystemFour
    {
        public void MethodFour()
        {
            Debug.Log(GetType() + " : MethodFour()");
        }
    }

    public class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Debug.Log(GetType() + ", MethodA()");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }

        public void MethodB()
        {
            Debug.Log(GetType() + ", MethodB()");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}