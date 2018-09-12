/*
* ==============================
* FileName:		FlyweightPatternExample2
* Author:		DuanBin
* CreateTime:	9/11/2018 8:51:48 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPatternExample2
{
	public class FlyweightPatternExample2 : MonoBehaviour {
	
		void Start () {
            UnitTest();	
		}
	
		void UnitTest () {
            // 组件工厂
            FlyweightFactory theFactory = new FlyweightFactory();

            // 产生共享组件
            theFactory.GetFlyweight("1", "共享组件1");
            theFactory.GetFlyweight("2", "共享组件2");
            theFactory.GetFlyweight("3", "共享组件3");

            // 获取一个共享组件
            Flyweight theFlyweight = theFactory.GetFlyweight("1", "");
            theFlyweight.Operation();

            // 产生不共享的组件
            UnsharedConcreteFlyweight theUnshared = theFactory.GetUnsharedFlyweight("不共享的信息1");
            theUnshared.Operator();

            // 设置共享组件
            theUnshared.SetFlyweight(theFlyweight);

            // 产生不共享的组件2，并指定使用共享组件1
            UnsharedConcreteFlyweight theUnshared2 = theFactory.GetUnsharedFlyweight("1", "", "不共享的信息2");

            // 同时显示
            theUnshared.Operator();
            theUnshared2.Operator();
        }
	}

    public abstract class Flyweight
    {
        // 显示内容,代表共享的信息
        protected string m_content;

        public Flyweight()
        {

        }

        public Flyweight(string content)
        {
            m_content = content;
        }

        public string GetContent()
        {
            return m_content;
        }

        public abstract void Operation();    
    }

    /// <summary>
    /// 表示被共享的组件
    /// </summary>
    public class ConcreteFlyweight : Flyweight
    {
        public ConcreteFlyweight(string content) : base(content)
        {

        }

        public override void Operation()
        {
            Debug.Log("ConcreteFlyweight.Content[" + m_content + "]");
        }
    }

    public class UnsharedConcreteFlyweight// : Flyweight
    {
        Flyweight m_flyweight = null;   // 共享的组件
        string m_unshareContent;        // 不共享的组件

        public UnsharedConcreteFlyweight(string content)
        {
            m_unshareContent = content;
        }

        public void SetFlyweight(Flyweight theFlyweight)
        {
            m_flyweight = theFlyweight;
        }

        public void Operator()
        {
            string msg = string.Format("UnshareConcreteFlyweight.Content[{0}]", m_unshareContent);

            if (m_flyweight != null)
            {
                msg += "包含了：" + m_flyweight.GetContent();
            }

            Debug.Log(msg);
        }
    }

    public class FlyweightFactory
    {
        Dictionary<string, Flyweight> m_flyweights = new Dictionary<string, Flyweight>();

        /// <summary>
        /// 获取共享组件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Flyweight GetFlyweight(string key,string content)
        {
            if (m_flyweights.ContainsKey(key))
            {
                return m_flyweights[key];
            }

            // 产生并设置内存
            ConcreteFlyweight theFlyweight = new ConcreteFlyweight(content);

            m_flyweights[key] = theFlyweight;

            Debug.Log("new ConcreteFlyweight Key[" + key + "] Content [" + content + "]");

            return theFlyweight;
        }

        /// <summary>
        /// 获取非共享组件
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public UnsharedConcreteFlyweight GetUnsharedFlyweight(string content)
        {
            return new UnsharedConcreteFlyweight(content);
        }

        public UnsharedConcreteFlyweight GetUnsharedFlyweight(string key,string sharedContent,string unsharedContent)
        {
            // 先获取共享部分
            Flyweight sharedFlyweight = GetFlyweight(key, sharedContent);

            // 产生非共享组件
            UnsharedConcreteFlyweight theFlyweight = new UnsharedConcreteFlyweight(unsharedContent);

            // 设置共享部分
            theFlyweight.SetFlyweight(sharedFlyweight);

            return theFlyweight;
        }
    }
}