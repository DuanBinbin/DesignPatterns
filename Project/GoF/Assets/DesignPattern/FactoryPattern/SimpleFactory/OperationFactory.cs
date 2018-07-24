/*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/
using FactoryPattern;

namespace SimpleFactoryPattern
{
	public class OperationFactory  {

        /// <summary>
        /// 简单工厂模式，判断的条件在代码实现内部，如果需要添加新的case，则要修改类中方法的判断条件，
        /// 这样就违背了开放封闭原则
        /// </summary>
        /// <param name="operate"></param>
        /// <returns></returns>
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }         
	}
}


