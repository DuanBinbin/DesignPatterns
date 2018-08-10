/*
* ==============================
* FileName:		FlyweightStructure
* Author:		DuanBin
* CreateTime:	8/10/2018 5:10:00 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightStructure
{
	public class FlyweightStructure : MonoBehaviour {
	
		void Start () {
            // Arbitrary extrinsic state(任意外部状态）
            int externalState = 22;

            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--externalState);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--externalState);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--externalState);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(--externalState);
        }
	}

    /// <summary>
    /// The 'Flyweight' class
    /// </summary>
    public class FlyweightFactory
    {
        private Hashtable _flyweights = new Hashtable();

        public FlyweightFactory()
        {
            _flyweights.Add("X",new ConcreteFlyweight());
            _flyweights.Add("Y", new ConcreteFlyweight());
            _flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)_flyweights[key];
        }
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    public abstract class Flyweight
    {
        public abstract void Operation(int externalState);
    }

    /// <summary>
    /// The 'ConcreteFlyweight' class
    /// </summary>
    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int externalState)
        {
            Debug.Log("ConcreteFlyweight : " + externalState);
        }
    }

    /// <summary>
    /// The 'UnsharedConcreteFlyweight' class
    /// </summary>
    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int externalState)
        {
            Debug.Log("UnsharedConcreteFlyweight : " + externalState);
        }
    }
}