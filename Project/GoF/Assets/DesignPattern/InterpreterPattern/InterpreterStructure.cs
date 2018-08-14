/*
* ==============================
* FileName:		InterpreterStructure
* Author:		DuanBin
* CreateTime:	8/14/2018 11:45:36 AM
* Description:		
* ==============================
*/

using System.Collections;
using UnityEngine;

namespace InterpreterStructure
{
	public class InterpreterStructure : MonoBehaviour {
	
		void Start () {
            Context context = new Context();

            // Usually a tree
            ArrayList list = new ArrayList();

            // Populate's abstract syntax tree's
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
		}
	}

    public class Context { }


    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Debug.Log(GetType() + "Called Terminal.Interpret");
        }
    }

    public class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Debug.Log(GetType() + "Called Nonterminal.Interpret()");
        }
    }
}


