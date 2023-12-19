using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileMap_CS
{
    internal class Tile : Game1
    {
        private Texture2D _spriteTexture;
        private Rectangle _Bounds;
        private Vector2 _Position;


        public Tile() { }
       
        public Tile(Texture2D tileSprite, Vector2 Position)
        {
            _spriteTexture = tileSprite;
            _Position = Position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_spriteTexture, _Position, Color.White);
        }



    }
}
