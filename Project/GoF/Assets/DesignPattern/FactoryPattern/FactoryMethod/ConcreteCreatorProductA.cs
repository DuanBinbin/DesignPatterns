  /*==============================
* author:		Duanbin
* time:			2018.07.20
* description:	
* function:		
* ==============================
*/

using UnityEngine;

namespace FactoryMethodPattern{

    /// <summary>
    /// 工厂子类
    /// 说明：负责生成具体的产品对象，目的是将产品类的实例化操作延迟到工厂子类去完成，
    /// 即通过工厂子类来确定究竟应该实例化哪一个具体产品类
    /// </summary>
    public class ConcreteCreatorProductA : Factory
    {
        public ConcreteCreatorProductA()
        {
            Debug.Log(GetType() + "-->ConcreteCreatorProductA");
        }

        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
}


