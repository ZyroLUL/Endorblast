﻿using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Server
{
    public enum MapType
    {
        Town,
        Snowlands,
        Fortnite
    }

    public class Map
    {
        public int lobbyId;
        public const int TileSize = 32;

        public int Width;
        public int Height;
        public Vector2 Center => new Vector2((Width * TileSize) / 2, (Height * TileSize) / 2);

        public Vector2 EntrancePos;

        public TmxMap tiledMap;
        public TmxLayer ground;
        public TmxObject testSpawn;



        public Map()
        {

        }

        public Map(int lobbyId)
        {
            this.lobbyId = lobbyId;
        }


        
        

        public void Setup(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}