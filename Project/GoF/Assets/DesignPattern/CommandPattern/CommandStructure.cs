/*
* ==============================
* FileName:		CommandStructure
* Author:		DuanBin
* CreateTime:	8/7/2018 5:33:58 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandStructure
{
	public class CommandStructure : MonoBehaviour {
	
		void Start () {
            // create receiver,command and invoker
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();            	
		}
	}

    public abstract class Command
    {
        protected Receiver m_receiver;

        public Command(Receiver theReceiver)
        {
            m_receiver = theReceiver;
        }

        public abstract void Execute();
    }

    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver theReceiver) : base(theReceiver) { }

        public override void Execute()
        {
            m_receiver.Action();
        }
    }

    public class Receiver
    {
        public void Action()
        {
            Debug.Log("Called Receiver.Action()");
        }
    }

    public class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}