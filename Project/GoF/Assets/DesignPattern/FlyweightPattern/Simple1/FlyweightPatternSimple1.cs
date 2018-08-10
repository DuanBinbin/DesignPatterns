/*
* ==============================
* FileName:		FlyweightPatternSimple1
* Author:		DuanBin
* CreateTime:	8/10/2018 5:40:08 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPatternSimple1
{
	public class FlyweightPatternSimple1 : MonoBehaviour {
	
		void Start () {
            string document = "AAZZBBZBA";
            char[] chars = document.ToCharArray();

            CharacterFactory factory = new CharacterFactory();

            int pointSize = 10;

            foreach (char item in chars)
            {
                pointSize++;
                Character character = factory.GetCharacter(item);
                character.Display(pointSize);
            }

            factory.Display();
		}
	}

    /// <summary>
    /// The 'FlyweightFactory'
    /// </summary>
    public class CharacterFactory
    {
        private Dictionary<char, Character> _characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // uses "lazy initialization"
            Character character = null;
            if (_characters.ContainsKey(key))
            {
                character = _characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new Character_A();
                        break;
                    case 'B':
                        character = new Character_B();
                        break;
                    // ......
                    case 'Z':
                        character = new Character_Z();
                        break;
                }
                _characters.Add(key, character);
            }
            return character;
        }  
        
        public void Display()
        {
            foreach (var item in _characters.Keys)
            {
                Debug.Log("Character = key is " + item + ", value = " + _characters[item].GetSymoble());
            }
        }     
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    public abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;
        protected int pointSize;

        public abstract void Display(int pointSize);
        public abstract char GetSymoble();
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    public class Character_A : Character
    {
        public Character_A()
        {
            symbol = 'A';
            height = 100;
            width = 120;
            ascent = 70;
            descent = 0;
        }
        
        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Debug.Log(this.symbol + "(pointsize " + this.pointSize + " )");
        }

        public override char GetSymoble()
        {
            return this.symbol;
        }
    }

    /// <summary>
    /// B 'ConcreteFlyweight' class
    /// </summary>
    public class Character_B : Character
    {
        public Character_B()
        {
            symbol = 'B';
            height = 100;
            width = 140;
            ascent = 72;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Debug.Log(this.symbol + "(pointsize " + this.pointSize + " )");
        }

        public override char GetSymoble()
        {
            return this.symbol;
        }
    }

    // ... C, D, E, etc

    /// <summary>
    /// C 'ConcreteFlyweight' class
    /// </summary>                
    public class Character_Z : Character
    {
        public Character_Z()
        {
            symbol = 'Z';
            height = 100;
            width = 100;
            ascent = 68;
            descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Debug.Log(this.symbol + "(pointsize " + this.pointSize + " )");
        }

        public override char GetSymoble()
        {
            return this.symbol;
        }
    }
}


