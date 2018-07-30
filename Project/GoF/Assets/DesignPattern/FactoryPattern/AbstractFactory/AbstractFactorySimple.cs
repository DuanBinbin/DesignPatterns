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

namespace AbstractFactoryPattern
{
    public class AbstractFactorySimple : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();   
    }

    class AfricaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
    }

    class AmericaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
    }

    abstract class Herbivore
    {

    }

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore herbivore);
    }

    class Wildebeest : Herbivore
    {

    }

    class Lion : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Debug.Log(GetType().Name + " eats " + herbivore.GetType().Name);
        }
    }

    class Bison : Herbivore
    {

    }

    class Wolf : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Debug.Log(GetType().Name + " eats " + herbivore.GetType().Name);
        }
    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}


