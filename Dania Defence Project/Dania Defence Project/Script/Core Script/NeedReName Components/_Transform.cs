using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dania_Defence_Project.Script.Core_Script.NeedReName_Components
{
    public class _Transform
    {
        // ---Unity Setup---

			// is not done and cant be use atm

        private Vector2 drawPosition;
        private float drawRotation;
        private Vector2 drawScale = new Vector2(1, 1);

        private Vector2 position;
        private float rotation;
        private Vector2 scale = new Vector2(1, 1);
        private _Transform parent = null;

        private Vector2 localPosition;
        private Vector2 localScale = new Vector2(1, 1);
        private float localRotation;

        private List<_Transform> childs = new List<_Transform>();

        // for MomoGame Only
        private Vector2 drawOffSet;
        private Vector2 origin;

        public Vector2 Position { get => position; set => position = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public _Transform Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (value != null)
                {
                    if (parent != null)
                    {
                        childs.Remove(this);
                        RemoveFormParent();
                        parent = value;
                        AttachToChild();
                        childs.Add(this);
                    }
                    else
                    {
                        parent = value;
                        AttachToChild();
                        childs.Add(this);
                    }
                }
                else
                {
                    if (parent != null)
                    {
                        childs.Remove(this);
                        RemoveFormParent();
                        parent = value;
                    }
                    else
                    {
                        parent = value;
                    }
                }
            }
        }


        public Vector2 DrawOffSet { get => drawOffSet; set => drawOffSet = value; }
        public Vector2 Origin { get => origin; set => origin = value; }
        public Vector2 LocalPosition
        {
            get
            {
                if (parent != null)
                {
                    return parent.position + localPosition;
                }
                else
                {
                    return position;
                }
            }
            set
            {
                if (parent != null)
                {
                    localPosition = parent.position + value;
                    position = parent.position + value;
                }
                else
                {
                    position = value;
                }
            }
        }
        public Vector2 LocalScale
        {
            get
            {
                if (parent != null)
                {
                    return parent.scale + localScale;
                }
                else
                {
                    return scale;
                }
            }
            set
            {
                if (parent != null)
                {
                    localScale = value;
                    scale = parent.scale + value;
                }
                else
                {
                    scale = value;
                }
            }
        }
        public float LocalRotation
        {
            get
            {
                if (parent != null)
                {
                    return parent.rotation + localRotation;
                }
                else
                {
                    return rotation;
                }
            }
            set
            {
                if (parent != null)
                {
                    localRotation = value;
                    rotation = parent.rotation + value;
                }
                else
                {
                    rotation = value;
                }
            }
        }

        // - - - - - Draw - - - - -
        public Vector2 DrawPosition
        {
            get
            {
                if (parent != null)
                {
                    return
                        this.parent.DrawPosition
                        +
                        drawPosition;
                }
                else
                {
                    return position;
                }
            }
        }
        public Vector2 DrawScale
        {
            get
            {
                if (parent != null)
                {
                    return parent.scale + drawScale;
                }
                else
                {
                    return scale;
                }
            }
        }
        public float DrawRotation
        {
            get
            {
                if (parent != null)
                {
                    return
                    this.parent.DrawRotation
                    +
                    drawRotation;
                }
                else
                {
                    return rotation;
                }
            }
        }


        public void AddChild(_Transform childTransform)
        {
            if (childTransform.parent != null)
                childTransform.parent.RemoveChild(childTransform);

            childTransform.parent = this;
            this.childs.Add(childTransform);
        }

        public void AddRangeChild(List<_Transform> childTransform)
        {
            foreach (_Transform x in childTransform)
            {
                x.parent.RemoveChild(x);
                x.parent = this;
                this.childs.Add(x);
            }
        }

        public void RemoveChild(_Transform childTransform)
        {
            childTransform.parent = null;
            this.childs.Remove(childTransform);
        }

        private void AttachToChild()
        {
            // Set Position
            this.position = this.position - this.parent.DrawPosition;
            // Set Rotation
            this.rotation = this.rotation - this.parent.DrawRotation;

            // Set drawPosition
            this.drawPosition =
                this.parent.DrawPosition
                +
                (this.position - this.parent.DrawPosition);

            // Set drawRotation
            this.drawRotation =
                this.DrawRotation
                +
                (this.rotation - this.DrawRotation);

            // Set drawScale
            this.drawScale = this.scale - this.parent.scale;
        }

        private void RemoveFormParent()
        {
            this.position = this.drawPosition + this.parent.DrawPosition;
            this.rotation = this.drawRotation + this.parent.DrawRotation;
            this.scale = this.drawScale + this.parent.scale;
        }

        public void UpdateTranform()
        {
            // if we got a parent, update to it Position, Rotation and Sacle.
            if (parent != null)
            {
                // Set Position
                this.drawPosition =
                    this.parent.DrawPosition
                    +
                    (this.position - this.parent.DrawPosition);
                // Set Rotation
                this.drawRotation =
                    this.DrawRotation
                    +
                    (this.rotation - this.DrawRotation);
                // Set Scale
                this.drawScale = this.scale - this.parent.scale;
            }
        }

        // TODO : Need a fix.
        private void FixRotation()
        {
            if (rotation > 360)
            {
                rotation = 0;
            }
            else if (rotation < 0)
            {
                rotation = 360;
            }
        }
    }
}

