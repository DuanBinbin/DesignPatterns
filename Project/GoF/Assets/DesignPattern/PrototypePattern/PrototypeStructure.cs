/*==============================
* author:		Duanbin
* time:			2018.07.27
* description:	
* function:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeStructure
{
    public class PrototypeStructure : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            ConcretePrototypeA concretePrototypeA = new ConcretePrototypeA("A");
            ConcretePrototypeA _concretePrototypeA = (ConcretePrototypeA)concretePrototypeA.Clone();
            Debug.Log(GetType() + " --> ConcretePrototypeA id = " + _concretePrototypeA.Id);

            ConcretePrototypeB concretePrototypeB = new ConcretePrototypeB("B");
            ConcretePrototypeB _concretePrototypeB = (ConcretePrototypeB)concretePrototypeB.Clone();
            Debug.Log(GetType() + " --> ConcretePrototypeB id = " + _concretePrototypeB.Id);
        }
    }

    /// <summary>
    /// declares an interface for cloning itself
    /// </summary>
    public abstract class Prototype
    {

        private string id;

        public string Id
        {
            get
            {
                return id;
            }
        }

        public Prototype(string id)
        {
            this.id = id;
        }

        public abstract Prototype Clone();
    }

    /// <summary>
    /// implements an operation for cloning itself
    /// </summary>
    public class ConcretePrototypeA : Prototype
    {
        public ConcretePrototypeA(string id) : base(id)
        {

        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// implements an operation for cloning itself
    /// </summary>
    public class ConcretePrototypeB : Prototype
    {
        public ConcretePrototypeB(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}