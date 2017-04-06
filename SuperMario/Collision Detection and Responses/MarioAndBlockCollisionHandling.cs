﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, IBlock item)
        {
            KeyboardState KeyboardStatus = Keyboard.GetState();
            Rectangle collisionRectangle = new Rectangle();
            ISprite block = item.Sprite;
            if (block.Area(item.Location).Equals(collisionRectangle)) {
                return;
            }
            
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Width <= collisionRectangle.Height/*
            && (KeyboardStatus.IsKeyDown(Keys.Right) || KeyboardStatus.IsKeyDown(Keys.Left)
            || KeyboardStatus.IsKeyDown(Keys.A) || KeyboardStatus.IsKeyDown(Keys.D))*/)
            {
                WidthSmallerThanHeight( mario,  item,  collisionRectangle,  block);
            }
            else
            {
                HeightSmallerThanWidth(mario, item, collisionRectangle, block);
            }
        }

        private static void WidthSmallerThanHeight(IMario mario, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                Mario.LocationX += collisionRectangle.Width + 1;
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                Mario.LocationX -= (collisionRectangle.Width + 1);
            }
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
            {
                Mario.LocationY += collisionRectangle.Height;
                mario.ResetVelocity();
                block.CollisionSprite();
                item.BecomeUsed();
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top)
            {
                Mario.GroundedStatus = true;
                Mario.DisableJump = false;
                Mario.JumpStatus = false;
                Mario.LocationY -= (collisionRectangle.Height);
                CollisionHandling.bottomCollision = true;
                mario.ResetVelocity();
            }
        }

        private static void HeightSmallerThanWidth(IMario mario, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (collisionRectangle.Top == block.Area(item.Location).Top)
            {
                Mario.GroundedStatus = true;
                Mario.DisableJump = false;
                Mario.JumpStatus = false;
                Mario.LocationY -= (collisionRectangle.Height);
                CollisionHandling.bottomCollision = true;

                mario.ResetVelocity();
            }
            else if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
            {
                Mario.LocationY += collisionRectangle.Height;
                mario.ResetVelocity();
                block.CollisionSprite();
                item.BecomeUsed();
            }

            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                Mario.LocationX += collisionRectangle.Width + 1;
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                Mario.LocationX -= (collisionRectangle.Width + 1);
            }
        }

    }
}
