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
        /// ���Ի�ͼ���ܵ�Visitor
        /// </summary>
        void UnitTestDraw()
        {
            DirectX theDirectX = new DirectX();

            // ������״
            ShapeContainer theShapeContainer = new ShapeContainer();
            theShapeContainer.AddShape(new Cube(theDirectX));
            theShapeContainer.AddShape(new Sphere(theDirectX));
            theShapeContainer.AddShape(new Cylinder(theDirectX));

            // ��ͼ
            theShapeContainer.RunVisitor(new DrawVisitor());
        }
	}

    /// <summary>
    /// ������״�����߽ӿ�
    /// </summary>
    public abstract class IShapeeVisitor
    {
        // ��Sphere��������
        public virtual void VisitSphere(Sphere theSphere)
        {

        }

        // ��Cube��������
        public virtual void VisitCube(Cube theCube)
        {

        }

        // ��Cylinder��������
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
        protected RenderEngine _renderEngine = null;        // ʹ�õĻ�ͼ����
        protected Vector3 _position = Vector3.zero;         // ��ʾλ��
        protected Vector3 _scale = Vector3.zero;            // ��С�����ţ�
        
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

        public abstract void Draw();            // ���
        public abstract float GetVolume();      // ��ȡ���
        public abstract int GetVectorCount();   // ��ȡ������
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
    /// DirectX ����
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
    /// OpenGL ����
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


