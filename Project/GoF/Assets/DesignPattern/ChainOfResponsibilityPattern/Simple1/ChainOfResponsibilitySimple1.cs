/*
* ==============================
* FileName:		ChainOfResponsibilitySimple1
* Author:		DuanBin
* CreateTime:	8/8/2018 7:59:55 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainOfResponsibilitySimple1
{
	public class ChainOfResponsibilitySimple1 : MonoBehaviour {
	
		void Start () {
            CommaonManager jinli = new CommaonManager("CommonManager");
            Majordomo zongjian = new Majordomo("Majordomo");
            GeneralManager zongjingli = new GeneralManager("GeneralManager");

            // 设置上级
            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zongjingli);

            Request request1 = new Request();
            request1.RequestType = RequestTypeEnum.IncreaseSalary;           
            request1.Number = 1000;

            jinli.RequestApplication(request1);

            Request request2 = new Request();
            request2.RequestType = RequestTypeEnum.AskForLeave;           
            request2.Number = 1;

            jinli.RequestApplication(request2);

            Request request3 = new Request();
            request3.RequestType = RequestTypeEnum.IncreaseSalary;
            request3.Number = 1100;

            jinli.RequestApplication(request3);
        }
	}

    /// <summary>
    /// 申请加薪
    /// </summary>
    public class Request
    {
        // 申请类别
        private RequestTypeEnum _requestType;
        // 数量
        private int _number;

        public RequestTypeEnum RequestType
        {
            get
            {
                return _requestType;
            }

            set
            {
                _requestType = value;
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }
    }

    /// <summary>
    /// 枚举：请求类型
    /// </summary>
    public enum RequestTypeEnum
    {
        AskForLeave,
        IncreaseSalary,
    }

    /// <summary>
    /// 经理
    /// </summary>
    public abstract class Manager
    {
        protected Manager m_suporior;
        protected string m_name;        
        
        public Manager(string name)
        {
            this.m_name = name;
        }

        /// <summary>
        /// 设置管理者的上级
        /// </summary>
        /// <param name="superior"></param>
        public void SetSuperior(Manager superior)
        {
            this.m_suporior = superior;
        }

        public abstract void RequestApplication(Request request);        
    }


    /// <summary>
    /// 经理
    /// </summary>
    public class CommaonManager : Manager
    {
        public CommaonManager(string name) : base(name)
        {

        }

        public override void RequestApplication(Request request)
        {
            if (request.RequestType == RequestTypeEnum.AskForLeave && request.Number <= 1)
            {
                Debug.Log(m_name +  " allows asking for leave " + request.Number + "days");
            }
            else
            {
                if (m_suporior != null)
                {
                    m_suporior.RequestApplication(request);
                }
            }
        }
    }

    /// <summary>
    /// 总监
    /// </summary>
    public class Majordomo : Manager
    {
        public Majordomo(string name) : base(name)
        {
        }

        public override void RequestApplication(Request request)
        {
            if (request.RequestType == RequestTypeEnum.AskForLeave && request.Number <= 3)
            {
                Debug.Log(m_name + " allows asking for leave " + request.Number + "days");
            }
            else
            {
                if (m_suporior != null)
                {
                    m_suporior.RequestApplication(request);
                }
            }
        }
    }

    public class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name)
        {
        }

        public override void RequestApplication(Request request)
        {
            if (request.RequestType == RequestTypeEnum.AskForLeave)
            {
                Debug.Log(m_name + " allows asking for leave " + request.Number + "days");
            }
            else if (request.RequestType == RequestTypeEnum.IncreaseSalary && request.Number <= 1000)
            {
                Debug.Log(m_name + " allows increasing salary " + request.Number + "$");
            }
            else if (request.RequestType == RequestTypeEnum.IncreaseSalary && request.Number > 1000)
            {
                Debug.Log(m_name + "said Good Bye !!!");
            }
        }
    }
}


