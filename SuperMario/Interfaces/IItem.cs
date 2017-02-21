﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    interface IItem : IObject
    {
        ISprite Sprite { get; set; }
        Game1 Mygame { get; set; }
        Rectangle Area { get; set; }
        void Update();
        void Used();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
