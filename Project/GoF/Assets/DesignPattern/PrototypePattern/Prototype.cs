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

namespace PrototypePattern
{

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
}


