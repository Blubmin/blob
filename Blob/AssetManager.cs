using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blob {
    static class AssetManager {

        private static ContentManager Content;

        private static Dictionary<string, Texture2D> Images;
        private static Dictionary<string, TiledMap> Levels;

        public static void Init(ContentManager c) {
            Content = c;
            Images = new Dictionary<string, Texture2D>();
            Levels = new Dictionary<string, TiledMap>();
        }

        public static Texture2D GetTexture(string name) {
            Texture2D img;
            if (!Images.TryGetValue(name, out img)) {
                img = Content.Load<Texture2D>(name);
                Images.Add(name, img);
            }
            return img;
        }

        public static TiledMap GetLevel(string name) {
            TiledMap level;
            if (!Levels.TryGetValue(name, out level)) {
                level = Content.Load<TiledMap>(name);
                Levels.Add(name, level);
            }
            return level;
        }

        public static void Unload() {
            Content.Unload();
        }
    }
}
