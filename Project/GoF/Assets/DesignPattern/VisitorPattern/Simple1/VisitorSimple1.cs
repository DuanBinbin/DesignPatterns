/*
* ==============================
* FileName:		VisitorSimple1
* Author:		DuanBin
* CreateTime:	8/7/2018 4:12:49 PM
* Description:		
* ==============================
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisitorSimple1
{
	public class VisitorSimple1 : MonoBehaviour {
	
		void Start () {
            UnitTestDraw();	
		}
	
        /// <summary>
        /// 测试绘图功能的Visitor
        /// </summary>
        void UnitTestDraw()
        {
            DirectX theDirectX = new DirectX();

            // 加入形状
            ShapeContainer theShapeContainer = new ShapeContainer();
            theShapeContainer.AddShape(new Cube(theDirectX));
            theShapeContainer.AddShape(new Sphere(theDirectX));
            theShapeContainer.AddShape(new Cylinder(theDirectX));

            // 绘图
            theShapeContainer.RunVisitor(new DrawVisitor());
        }
	}

    /// <summary>
    /// 定义形状访问者接口
    /// </summary>
    public abstract class IShapeeVisitor
    {
        // 有Sphere类来调用
        public virtual void VisitSphere(Sphere theSphere)
        {

        }

        // 有Cube类来调用
        public virtual void VisitCube(Cube theCube)
        {

        }

        // 有Cylinder类来调用
        public virtual void VisitCylinder(Cylinder theCylinder)
        {

        }
    }

    public class ShapeContainer
    {
        private List<IShape> _ShapeesList = new List<IShape>();

        public ShapeContainer() { }

        public void AddShape(IShape theShape)
        {
            _ShapeesList.Add(theShape);
        }

        public void RunVisitor(IShapeeVisitor theVisitor)
        {
            foreach (IShape theShape in _ShapeesList)
            {
                theShape.RunVisitor(theVisitor);   
            }
        }
    }

    public abstract class IShape
    {
        protected RenderEngine _renderEngine = null;        // 使用的绘图引擎
        protected Vector3 _position = Vector3.zero;         // 显示位置
        protected Vector3 _scale = Vector3.zero;            // 大小（缩放）
        
        public void SetRenderEngine(RenderEngine theRenderEngine)
        {
            _renderEngine = theRenderEngine;
        }   

        public Vector3 GetPosition()
        {
            return _position;
        }

        public Vector3 GetScale()
        {
            return _scale;
        }

        public abstract void Draw();            // 绘出
        public abstract float GetVolume();      // 获取体积
        public abstract int GetVectorCount();   // 获取定点数
        public abstract void RunVisitor(IShapeeVisitor theVisitor); 
    }

    public class Sphere : IShape
    {
        public Sphere(RenderEngine theRenderEngine)
        {
            base.SetRenderEngine(theRenderEngine);
        }

        public override void Draw()
        {
            _renderEngine.Render("Sphere");
        }

        public override int GetVectorCount()
        {
            return 0;
        }

        public override float GetVolume()
        {
            return 0;
        }

        public override void RunVisitor(IShapeeVisitor theVisitor)
        {
            theVisitor.VisitSphere(this);
        }
    }

    public class Cube : IShape
    {
        public Cube(RenderEngine theRenderEngine)
        {
            base.SetRenderEngine(theRenderEngine);
        }

        public override void Draw()
        {
            _renderEngine.Render("Cube");
        }

        public override int GetVectorCount()
        {
            return 0;
        }

        public override float GetVolume()
        {
            return 0;
        }

        public override void RunVisitor(IShapeeVisitor theVisitor)
        {
            theVisitor.VisitCube(this);
        }
    }

    public class Cylinder : IShape
    {
        public Cylinder(RenderEngine theRenderEngine)
        {
            base.SetRenderEngine(theRenderEngine);
        }

        public override void Draw()
        {
            _renderEngine.Render("Cylinder");
        }

        public override int GetVectorCount()
        {
            return 0;
        }

        public override float GetVolume()
        {
            return 0;
        }

        public override void RunVisitor(IShapeeVisitor theVisitor)
        {
            theVisitor.VisitCylinder(this);
        }
    }

    public abstract class RenderEngine
    {
        public abstract void Render(string objName);
        public abstract void Text(string text);
    }

    /// <summary>
    /// DirectX 引擎
    /// </summary>
    public class DirectX : RenderEngine
    {
        public override void Render(string objName)
        {
            DXRender(objName);
        }

        public override void Text(string text)
        {
            DXRender(text);
        }

        public void DXRender(string objName)
        {
            Debug.Log("DXRender:" + objName);
        }
    }

    /// <summary>
    /// OpenGL 引擎
    /// </summary>
    public class OpenGL : RenderEngine
    {
        public override void Render(string objName)
        {
            GLRender(objName);
        }

        public override void Text(string text)
        {
            GLRender(text);
        }

        public void GLRender(string objName)
        {
            Debug.Log("GLRender:" + objName);
        }
    }

    public class DrawVisitor : IShapeeVisitor
    {
        public override void VisitSphere(Sphere theSphere)
        {
            theSphere.Draw();
        }

        public override void VisitCube(Cube theCube)
        {
            theCube.Draw();
        }

        public override void VisitCylinder(Cylinder theCylinder)
        {
            theCylinder.Draw();
        }
    }
}


