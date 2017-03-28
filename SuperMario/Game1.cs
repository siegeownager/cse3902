﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Command;
using SuperMario.Controller;
using SuperMario.Game_Object_Classes;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SuperMario
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public Texture2D texture { get; set; }
        private Texture2D background;
        private Rectangle mainFrame;
        public GameTime GameTime;
        public SpriteFactory SpriteFactory;
        private ISprite Sprite;
        public static Game1 Self;
        public Camera CameraPointer;
        public WorldManager World;
        public LevelClass Level;
        public Vector2 Location { get; set; }
        public static List<MarioFireball> mFireballs = new List<MarioFireball>();

        public ISprite sprite
        {
            get
            { return Sprite; }
            set
            { Sprite = value; }
        }
        private IProjectile fireball;

        public IProjectile Fireball
        {
            get
            { return fireball; }
            set
            { fireball = value; }
        }
        private IMario mario;
        public IMario MarioSprite
        {
            get
            { return mario; }
            set
            { mario = value; }
        }

        private IBlock block;
        public IBlock Block
        {
            get {return block; }
            set {block = value; }
        }

        private KeyboardController keyboardController;
        public KeyboardController KeyboardController
        {
            get
            { return keyboardController; }
            set
            { keyboardController = value; }
        }

        private GamepadController gamepadController;
        public GamepadController GamepadController
        {
            get
            { return gamepadController; }
            set
            { gamepadController = value; }
        }

      

        public static int xPos, yPos, xMax, yMax;
        
        private static ArrayList Valid_Keys;
        public static ArrayList validKeys
        {
            get
            { return Valid_Keys; }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";         
        }

        protected override void Initialize()
        {
            Valid_Keys = ValidKeys.Instance.ArrayOfKeys();
            CameraPointer = new Camera();
            Level = new LevelClass(this);
            Self = this;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("MarioSheet");
            background = Content.Load<Texture2D>("background3");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            SpriteFactory = new SpriteFactory();
            SpriteFactory.LoadAllTextures(Content);
            block = new BlockLogic(this);
            Mario.LoadContent(Content);
            World = new WorldManager(this);
            World.Load();

            KeyboardController = new KeyboardController();
            KeyboardController.RegisterCommand(Keys.Left, new MarioLookLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.Right, new MarioLookRightCommand(this));
            KeyboardController.RegisterCommand(Keys.Down, new MarioLookDownCommand(this));
            KeyboardController.RegisterCommand(Keys.A, new MarioLookLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.D, new MarioLookRightCommand(this));
            KeyboardController.RegisterCommand(Keys.S, new MarioLookDownCommand(this));
            KeyboardController.RegisterCommand(Keys.Z, new MarioJumpCommand(this));
            KeyboardController.RegisterCommand(Keys.Y, new MarioBecomeFireCommand(this));
            KeyboardController.RegisterCommand(Keys.U, new MarioBecomeBigCommand(this));
            KeyboardController.RegisterCommand(Keys.I, new MarioBecomeSmallCommand(this));

            KeyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            KeyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            KeyboardController.RegisterCommand(Keys.X, new MarioRunCommand(this));
            GamepadController = new GamepadController();
            GamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLookLeftCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioLookRightCommand(this));
            GamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioLookDownCommand(this));
            GamepadController.RegisterCommand(Buttons.A, new MarioJumpCommand(this));
            GamepadController.RegisterCommand(Buttons.B, new MarioRunCommand(this));
            xMax = GraphicsDevice.Viewport.Width;
            yMax = GraphicsDevice.Viewport.Height;
            xPos = xMax / 2;
            yPos = yMax / 2;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime GameTime)
        {
            this.GameTime = GameTime;
            KeyboardController.Update(GameTime);
            GamepadController.Update(GameTime);
            CameraPointer.UpdateX(Mario.LocationX);
            MarioSprite.Update(GameTime);
            World.Update(GameTime);
            Collision_Detection_and_Responses.CollisionHandling.Update(World.Level, this);
            base.Update(GameTime);
           
        }

        protected override void Draw(GameTime GameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            World.Draw(Location);
 
            World.Draw(new Vector2(Camera.cameraPositionX, Camera.cameraPositionY));
            MarioSprite.Draw(SpriteBatch, new Vector2(Camera.cameraPositionX, Camera.cameraPositionY));

            foreach (MarioFireball aFireball in Game1.mFireballs)
            {
                aFireball.Draw(SpriteBatch);
            }
            base.Draw(GameTime);
        }

  
    }
}
