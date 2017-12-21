using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Memoton.Helpers
{
    public class CommonState
    {
        public string filePath;
        public Color color;
        public Vector2 position;
        public Vector2 origin;
        public float scale;
        public float rotation;
        public float drawOrder;

        public CommonState() { }

        public CommonState(CommonState state)
        {
            filePath = state.filePath;
            color = state.color;
            position = state.position;
            origin = state.origin;
            scale = state.scale;
            rotation = state.rotation;
            drawOrder = state.drawOrder;
        }

        public CommonState(string filePath, Color color, Vector2 position,
            Vector2 origin, float scale, float rotation, float drawOrder)
        {
            this.filePath = filePath;
            this.color = color;
            this.position = position;
            this.origin = origin;
            this.scale = scale;
            this.rotation = rotation;
            this.drawOrder = drawOrder;
        }

    }
}
