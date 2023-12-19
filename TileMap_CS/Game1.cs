using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace TileMap_CS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private const int MAP_SIZE = 80;
        private const int TILE_WIDTH = 40;
        private const int TILE_HEIGHT = 40;
        char[,] tilePosition;
        Tile[,] tileArray;
        List<Texture2D> allTileTextures = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = TILE_HEIGHT * 32;
            _graphics.PreferredBackBufferWidth = TILE_WIDTH * 32;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }   

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            allTileTextures = TileManager.LoadTextures(Content);
            int tileSize = allTileTextures[0].Width;


            tilePosition = TileManager.FileReader("tileMap.txt", MAP_SIZE);
            tileArray = TileManager.CreateMap(tilePosition, tileSize, allTileTextures);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (Tile tile in tileArray)
                tile.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}