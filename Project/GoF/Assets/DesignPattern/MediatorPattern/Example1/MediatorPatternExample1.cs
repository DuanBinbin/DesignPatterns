/*
* ==============================
* FileName:		MediatorPatternExample1
* Author:		DuanBin
* CreateTime:	8/23/2018 3:16:12 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MediatorPatternExample1
{
	public class MediatorPatternExample1 : MonoBehaviour {
	
		void Start () {
            UnitedNationsSecurityCouncil unsc = new UnitedNationsSecurityCouncil();
            USA colleague1 = new USA(unsc);
            Iraq colleague2 = new Iraq(unsc);

            unsc.Colleague1 = colleague1;
            unsc.Colleague2 = colleague2;

            colleague1.Declare("我在你家发现了大规模杀伤性武器");
            colleague2.Declare("我家没有");
		}
	}

    /// <summary>
    /// 联合国机构（安理会做中介）
    /// </summary>
    public abstract class UnitedNations
    {
        // 声明
        public abstract void Declare(string message, Country colleague);
    }

    /// <summary>
    /// 国家类（相当于Colleague类）
    /// </summary>
    public abstract class Country
    {
        protected UnitedNations m_mediator;

        public Country(UnitedNations mediator)
        {
            m_mediator = mediator;
        }
    }

    /// <summary>
    /// 美国类（相当于ConcreteColleague1类）
    /// </summary>
    public class USA : Country
    {
        public USA(UnitedNations mediator):base(mediator)
        {
            
        }   

        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message">消息</param>
        public void Declare(string message)
        {
            m_mediator.Declare(message, this);
        }

        /// <summary>
        /// 获得消息
        /// </summary>
        /// <param name="message"></param>
        public void GetMessage(string message)
        {
            Debug.Log("美国获得对方消息 : " + message); 
        }
    }

    /// <summary>
    /// 伊拉克类（相当于ConcreteColleague2类）
    /// </summary>
    public class Iraq : Country
    {
        public Iraq(UnitedNations mediator) : base(mediator)
        {

        }

        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message">消息</param>
        public void Declare(string message)
        {
            m_mediator.Declare(message, this);
        }

        /// <summary>
        /// 获得消息
        /// </summary>
        /// <param name="message"></param>
        public void GetMessage(string message)
        {
            Debug.Log("伊拉克获得对方消息 : " + message);
        }
    }

    /// <summary>
    /// 联合国安理会（相当于ConcreteMediator类）
    /// </summary>
    public class UnitedNationsSecurityCouncil : UnitedNations
    {
        private USA _colleague1;
        private Iraq _colleague2;

        /// <summary>
        /// 美国
        /// </summary>
        public USA Colleague1
        {
            set
            {
                _colleague1 = value;
            }
        }

        /// <summary>
        /// 伊拉克
        /// </summary>
        public Iraq Colleague2
        {
            set
            {
                _colleague2 = value;
            }
        }

        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="colleagues"></param>
        public override void Declare(string message, Country colleague)
        {
            if (colleague == _colleague1)
            {
                _colleague2.GetMessage(message);
            }
            else
            {
                _colleague1.GetMessage(message);
            } 
        }
    }
}