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
using UnityEngine;

namespace StrategyStructure
{
    public class StrategyStructure : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Context context;

            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }

    /// <summary>
    /// declares an interface common to all support algorithms.Context uses this interface to 
    /// call the algorithm defined by a ConcreteStrategy
    /// </summary>
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    /// <summary>
    /// implements the algorithm using the Strategy interface
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Call ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Call ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Call ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// is configured with a ConcreteStrategy object
    /// maintains a reference to a Strategy object
    /// may define an interface that lets Strategy access its data
    /// </summary>
    class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}