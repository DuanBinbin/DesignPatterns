/*==============================
* author:		Duanbin
* time:			2018.08.06
* description:	
* function:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStructure
{
    public class StateStructure : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            UniTest();         
        }

        void UniTest()
        {
            Context context = new Context();
            context.State = new ConcreteStateA(context);

            context.Request(15);
            context.Request(25);
            context.Request(35);
        }
    }

    /// <summary>
    /// Context角色 持有表示当前状态的ConcreteState角色。此外，它还定义了供外部调用者
    /// 使用State模式的接口（API)。
    /// </summary>
    public class Context
    {
        private State _state;

        public State State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
                Debug.Log(GetType() + ",State : " + _state.GetType().Name);
            }
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="value">状态</param>
        public void Request(int value)
        {
            _state.Handle(value);
        }
    }

    /// <summary>
    /// 表示状态，定义了根据不同状态进行不同处理的接口（API），
    /// 该接口（API）是那些处理内容依赖于状态的方法的集合。
    /// </summary>
    public abstract class State
    {
        // 关联端的状态拥有者
        protected Context m_context;

        public State(Context theContext)
        {
            m_context = theContext;
        }

        /// <summary>
        /// Handle抽象方法
        /// </summary>
        /// <param name="value">参数值</param>
        public abstract void Handle(int value);
    }

    /// <summary>
    /// 表示各个具体的状态，它实现了State接口。
    /// </summary>
    public class ConcreteStateA : State
    {
        public ConcreteStateA(Context theContext) : base(theContext)
        {

        }

        public override void Handle(int value)
        {
            Debug.Log("ConcreteStateA.Handle");
            if (value >= 10)
            {
                m_context.State = new ConcreteStateB(m_context);
            }
        }
    }

    /// <summary>
    /// 表示各个具体的状态，它实现了State接口。
    /// </summary>
    public class ConcreteStateB : State
    {
        public ConcreteStateB(Context theContext) : base(theContext)
        {

        }

        public override void Handle(int value)
        {
            Debug.Log("ConcreteStateB.Handle");
            if (value > 20)
            {
                m_context.State = new ConcreteStateC(m_context);
            }
        }
    }

    public class ConcreteStateC : State
    {
        public ConcreteStateC(Context theContext) : base(theContext)
        {
        }

        public override void Handle(int value)
        {
            Debug.Log("ConcreteStateC.Handle");
            if (value > 30)
            {
                m_context.State = new ConcreteStateA(m_context);
            }
        }
    }
}