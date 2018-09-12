/*
* ==============================
* FileName:		StatePatternExample1
* Author:		DuanBin
* CreateTime:	9/12/2018 11:58:52 AM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePatternExample1
{
	public class StatePatternExample1 : MonoBehaviour {
	
		void Start () {
            UnitTest();
		}

        void UnitTest()
        {
            Account account = new Account("Jack");

            account.Deposit(1000.00);
            account.Deposit(200.00);
            account.Deposit(600.00);

            account.PayInterest();

            account.Withdraw(2000.00);
            account.Withdraw(500.00);
        }
    }

    public class Account
    {
        public State State { get; set; }
        public string Owner { get; set; }              
        public Account(string owner)
        {
            Owner = owner;
            State = new SilverState(0.00, this);
        }

        //余额
        public double Balance { get { return State.Balance; } }

        // 存钱
        public void Deposit(double amount)
        {
            State.Deposit(amount);

            Debug.LogFormat("存款金额为 {0:C}——", amount);
            Debug.LogFormat("账户余额为 =:{0:C}", this.Balance);
            Debug.LogFormat("账户状态为: {0}", this.State.GetType().Name);
        }

        // 取款
        public void Withdraw(double amount)
        {
            State.WithDraw(amount);

            Debug.LogFormat("取款金额为 {0:C}——", amount);
            Debug.LogFormat("账户余额为 =:{0:C}", this.Balance);
            Debug.LogFormat("账户状态为: {0}", this.State.GetType().Name);
        }

        // 获取利息
        public void PayInterest()
        {
            State.PayInterest();

            Debug.Log("Interest Paid ---");
            Debug.LogFormat("账户余额为 =:{0:C}", this.Balance);
            Debug.LogFormat("账户状态为: {0}", this.State.GetType().Name);
        }
    }

    public abstract class State
    {
        #region properties

        public Account Account { get; set; }
        public double Balance { get; set; }     //余额
        public double Interest { get; set; }    //利率
        public double LowerLimit { get; set; }  //下限
        public double UpperLimit { get; set; }  //上限

        #endregion

        #region method

        public abstract void Deposit(double amount);    //存款
        public abstract void WithDraw(double amount);   //取钱
        public abstract void PayInterest();             //获取利息
        #endregion

    }

    // Red State意味着Account透支了
    public class RedState : State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.00;
            LowerLimit = -100.00;
            UpperLimit = 0.00;
        }

        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="amount"></param>
        public override void Deposit(double amount)
        {
            this.Balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Debug.Log("hava no interest");
        }

        public override void WithDraw(double amount)
        {
            Debug.Log("have no money");
        }

        private void StateChangeCheck()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);    
            }   
        }
    }

    // Silver State意味着没有利息
    public class SilverState : State
    {
        public SilverState(State state)
             : this(state.Balance, state.Account)
        {

        }

        public SilverState(double balance, Account account)
        {
            Balance = balance;
            Account = account;
            Interest = 0.00;
            LowerLimit = 100.00;
            UpperLimit = 1000.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        public override void WithDraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Balance < LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else if (Balance > UpperLimit)
            {
                Account.State = new GoldState(this);
            }
        }
    }

    public class GoldState : State
    {
        public GoldState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Interest = 0.05;
            LowerLimit = 1000.00;
            UpperLimit = 10000.00;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            StateChangeCheck();
        }

        public override void WithDraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Balance < 0.00)
            {
                Account.State = new RedState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
}