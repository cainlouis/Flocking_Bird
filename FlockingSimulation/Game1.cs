using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlockingBackend;
using System.Collections.Generic;

namespace FlockingSimulation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World _world;
        private SparrowFlockSprite _sparrowFlockSprite;
        private RavenSprite _ravenSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Initialize the _world field for non-static call to methods
            _world = new World();
        }

        protected override void Initialize()
        {
            //Sets the height and width of the MonoGame canvas based on the static properties in World. 
            _graphics.PreferredBackBufferHeight = World.Height;
            _graphics.PreferredBackBufferWidth = World.Width;
            _graphics.ApplyChanges();

            //create the Raven and RavenSprite objects 
            _ravenSprite = new RavenSprite(this, _world.Raven);

            //Create the Sparrows list and the SparrowFlockSprite object
            _sparrowFlockSprite = new SparrowFlockSprite(this, _world.Sparrows);

            //Add the Sprites to the Components
            Components.Add(_ravenSprite);
            Components.Add(_sparrowFlockSprite);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Invokes World update method
            _world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
