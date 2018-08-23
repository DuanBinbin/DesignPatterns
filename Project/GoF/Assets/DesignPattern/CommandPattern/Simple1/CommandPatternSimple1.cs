/*
* ==============================
* FileName:		CommandPatternSimple1
* Author:		DuanBin
* CreateTime:	8/7/2018 7:29:56 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPatternSimple1
{
	public class CommandPatternSimple1 : MonoBehaviour {
	
		void Start () {
            BakeShop();
		}
	
		void BakeShop () {
            // 开店前准备
            Barbucuer bakeBoy = new Barbucuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(bakeBoy);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(bakeBoy);
            Command bakeChickenWingCommand1 = new BakeChickenCommand(bakeBoy);

            Waiter waiterGirl = new Waiter();

            waiterGirl.SetOrder(bakeMuttonCommand1);           
            waiterGirl.SetOrder(bakeMuttonCommand2);         
            waiterGirl.SetOrder(bakeChickenWingCommand1);

            waiterGirl.Notify();
        }
	}

    /// <summary>
    /// 抽象命令
    /// </summary>
    public abstract class Command
    {
        protected Barbucuer m_Receiver;

        public Command(Barbucuer receiver)
        {
            m_Receiver = receiver;
        }

        public abstract void ExecuteCommand();
    }

    /// <summary>
    /// 具体命令 - 烤羊肉
    /// </summary>
    public class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbucuer receiver) : base(receiver)
        {
            
        }

        public override void ExecuteCommand()
        {
            m_Receiver.BakeMutton();   
        }
    }

    /// <summary>
    /// 具体命令 - 烤鸡翅
    /// </summary>
    public class BakeChickenCommand : Command
    {
        public BakeChickenCommand(Barbucuer receiver) : base(receiver)
        {

        }

        public override void ExecuteCommand()
        {
            m_Receiver.BakeChickenWing();
        }
    }

    /// <summary>
    /// 具体执行者 - 烤肉串者
    /// </summary>
    public class Barbucuer
    {
        public void BakeMutton()
        {
            Debug.Log("Barbucuer.BakeMutton()");
        }

        public void BakeChickenWing()
        {
            Debug.Log("Barbucuer.BakeChikenWing()");
        }
    }

    /// <summary>
    /// 服务员
    /// </summary>
    public class Waiter
    {
        private List<Command> _orders = new List<Command>();

        /// <summary>
        /// set order command
        /// </summary>
        /// <param name="theCommand">具体命令</param>
        public void SetOrder(Command theCommand)
        {
            if (theCommand.ToString() == "CommandPattern.BakeChickenWingCommand")
            {
                Debug.Log("WaiterGirl:have not wings,don't order wings");
            }
            else
            {
                _orders.Add(theCommand);
                Debug.Log("increase order : " + theCommand.ToString() + " !");
            }
        }

        /// <summary>
        /// cancel order command 
        /// </summary>
        /// <param name="theCommand"></param>
        public void CancelOrder(Command theCommand)
        {
            _orders.Remove(theCommand);
            Debug.Log("cancel order : " + theCommand.ToString() + " !");
        }

        /// <summary>
        /// notify and execute
        /// </summary>
        public void Notify()
        {
            foreach (Command order in _orders)
            {
                order.ExecuteCommand();
            }
        }
    }
}


