/*
* ==============================
* FileName:		SimpleFactoryExample1
* Author:		DuanBin
* CreateTime:	8/14/2018 3:46:57 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleFactoryExample1
{
	public class SimpleFactoryExample1 : MonoBehaviour {
	
		void Start () {
            ResourceSimpleFactory factory = new ResourceSimpleFactory();

            ResourceManager mgr = factory.CreateManager(ResourceType.AudioResource);
            mgr.LoadAsset("audio resource file");
            mgr.LoadConfig("audio resource config");
            mgr.UnLoadResource(false);
		}
	}

    /// <summary>
    /// to create UI,Audio etc resource manager(The simple factory class)
    /// </summary>
    public class ResourceSimpleFactory
    {
        public ResourceManager CreateManager(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.UIResource:
                    return new UIResourceManager();
                case ResourceType.AudioResource:
                    return new AudioResourceManager();                    
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// The resource manager base class(The abstract product)
    /// </summary>
    public abstract class ResourceManager
    {
        public abstract void LoadConfig(string path);
        public abstract void LoadAsset(string name);
        public abstract void UnLoadResource(bool status);
    }

    /// <summary>
    /// Audio resource manager class(The concrete product)
    /// </summary>
    public class AudioResourceManager : ResourceManager
    {
        public override void LoadAsset(string name)
        {
            Debug.Log("Load audio file");
        }

        public override void LoadConfig(string path)
        {
            Debug.Log("Load audio config file");
        }

        public override void UnLoadResource(bool status)
        {
            Debug.Log("Unload audio file");
        }
    }

    /// <summary>
    /// The UI resource manager class(The concrete product)
    /// </summary>
    public class UIResourceManager : ResourceManager
    {
        public override void LoadAsset(string name)
        {
            Debug.Log("Load UI file");
        }

        public override void LoadConfig(string path)
        {
            Debug.Log("Load UI config file");
        }

        public override void UnLoadResource(bool status)
        {
            Debug.Log("Unload UI file");
        }
    }

    /// <summary>
    /// define resource type
    /// </summary>
    public enum ResourceType
    {
        None,
        UIResource,
        AudioResource
    }
}


