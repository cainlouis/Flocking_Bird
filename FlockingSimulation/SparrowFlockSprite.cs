using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FlockingBackend;

namespace FlockingSimulation
{
    public class SparrowFlockSprite : DrawableGameComponent
    {
        private Game1 _game;
        private List<Sparrow> _sparrows;
        private Texture2D _texture;
        private SpriteBatch _spriteBatch;
        private const int _originRotation = 10;

        //initialize _game
        public SparrowFlockSprite(Game1 game) : base(game)
        {
            _game = game;
        }

        //OverLoad the constructor and initialize _game and _sparrows fields
        public SparrowFlockSprite(Game1 game, List<Sparrow> sparrows) : base(game)
        {
            _game = game;
            _sparrows = sparrows;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //load the texture
            _texture = _game.Content.Load<Texture2D>("sparrow");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            //Goes through the list and draw sparrows
            foreach (Sparrow sparrow in _sparrows)
            {
                _spriteBatch.Draw(_texture, new Microsoft.Xna.Framework.Vector2(sparrow.Position.Vx, sparrow.Position.Vy), null, Color.White, sparrow.Rotation, new Microsoft.Xna.Framework.Vector2(_originRotation, _originRotation), 1, SpriteEffects.None, 0f);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}