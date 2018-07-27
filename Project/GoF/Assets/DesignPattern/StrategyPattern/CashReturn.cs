/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace StrateypePattern
{
    /// <summary>
    /// 返利收费子类
    /// </summary>
    public class CashReturn : CashSuper
    {
        private double _moneyCondition = 0.0d;
        private double _moneyReturn = 0.0d;

        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this._moneyCondition = double.Parse(moneyCondition);
            this._moneyReturn = double.Parse(moneyReturn);
        }

        public override double AcceptCash(double money)
        {
            double result = money;
            if (money >= _moneyCondition)
            {
                result = money - Math.Floor(money / _moneyCondition) * 0.2;
            }
            return result;
        }
    }
}


