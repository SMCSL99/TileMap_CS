using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TileMap_CS
{
    internal static class TileManager
    {
        public static char[,] FileReader(string fileName, int mapSize)
        {
            char[,] charArray = new char[mapSize, mapSize];
            StreamReader reader = new StreamReader(@"..\..\..\Content\" + fileName);
            string currentLine = "";
            int charsPerLine = 0;

            do
            {
                currentLine = reader.ReadLine();
                for (int i = 0; i < currentLine.Length; i++)
                    charArray[i, charsPerLine] = currentLine[i];

                if (charsPerLine < currentLine.Length - 1)
                    charsPerLine++;
            }
            while (!reader.EndOfStream);

            reader.Close();

            return charArray;
        }

        

        public static List<Texture2D> LoadTextures(ContentManager Content)
        {
            Texture2D _grass, _water, _mud, _wall;
            List<Texture2D> tileTextures = new();

            _grass = Content.Load<Texture2D>("Grass");
            _water = Content.Load<Texture2D>("Water");
            _mud = Content.Load<Texture2D>("Mud");
            _wall = Content.Load<Texture2D>("Stone");

            tileTextures.Add( _grass);
            tileTextures.Add(_water);
            tileTextures.Add(_mud); 
            tileTextures.Add(_wall);

            return tileTextures;
        }

        public static Tile[,] CreateMap(char[,] mapArray, int tileSize, List<Texture2D> Textures)
        { 
            Tile[,] tiles = new Tile[mapArray.GetLength(0), mapArray.GetLength(1)];
            Vector2 tilePosition;

            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    tilePosition = new Vector2(j * tileSize, i * tileSize);
                    switch (mapArray[i, j])
                    {
                        case '0':
                            tiles[i, j] = new Tile(Textures[0], tilePosition);
                            break;
                        case '1':
                            tiles[i, j] = new Tile(Textures[1], tilePosition);
                            break;
                        case '2':
                            tiles[i, j] = new Tile(Textures[2], tilePosition);
                            break;
                        case '3':
                            tiles[i, j] = new Tile(Textures[3], tilePosition);
                            break;
                        default:
                            break;
                    }
                }
            }
            return tiles;
        }

    }
}
