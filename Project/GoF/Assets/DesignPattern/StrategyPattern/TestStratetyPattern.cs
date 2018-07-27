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
    public class TestStratetyPattern : MonoBehaviour
    {

        public void TestSimpleFactory()
        {
            CashSuper cs = CashFactory.createCashAccept("打八折");
            double result = cs.AcceptCash(100d);
        }

        public void TestStrategyPattern()
        {
            CashContext cc = null;
            double result = 0d;

            cc = new CashContext(new CashNormal());
            result = cc.GetMoney(100d);

            cc = new CashContext(new CashRebate("打八折"));
            result = cc.GetMoney(100d);

            cc = new CashContext(new CashReturn("300", "100"));
            result = cc.GetMoney(100d);
        }
    }	
}


