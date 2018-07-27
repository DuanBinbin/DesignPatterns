/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrateypePattern
{
    public class CashContext{
        private CashSuper _cashSuper;
    
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cs">现金收费工厂子类</param>
        public CashContext(CashSuper cs)
        {
            _cashSuper = cs;
        }	

        public double GetMoney(double money)
        {
            return _cashSuper.AcceptCash(money);
        }
    }
}


