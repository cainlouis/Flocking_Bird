using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FlockingBackend;

namespace FlockingSimulation
{
    public class RavenSprite : DrawableGameComponent
    {
        private Game1 _game;
        private Raven _raven;
        private Texture2D _texture;
        private SpriteBatch _spriteBatch;
        private const int _originRotation = 10;

        //initialize _game
        public RavenSprite(Game1 game) : base(game)
        {
            _game = game;
        }

        //OverLoad the constructor and initialize _game and _raven fields
        public RavenSprite(Game1 game, Raven raven) : base(game)
        {
            _game = game;
            _raven = raven;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //load the texture
            _texture = _game.Content.Load<Texture2D>("raven");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            //Draw _raven
            _spriteBatch.Draw(_texture, new Microsoft.Xna.Framework.Vector2(_raven.Position.Vx, _raven.Position.Vy), null, Color.White, _raven.Rotation, new Microsoft.Xna.Framework.Vector2(_originRotation, _originRotation), 1, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}