﻿/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		测试各个模式
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BuildPattern;
using FactoryPattern;

namespace Global{
	public class CoreCtrl : MonoBehaviour {

		void Start () {
            TestBuildPattern.execute();          
            TestFactoryPattern.TestSimpleFactoryPattern();
		}
	}
}


