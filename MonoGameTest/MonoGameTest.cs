using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System.Reflection;
using System.IO;

namespace MonoGameTest
{
	public class MonoGameTest : Game
    {
        GraphicsDeviceManager graphics;
        RenderTargetBinding[] RenderTargets;
        FullscreenQuad fullscreenQuad;
        Effect effect;
        SpriteBatch spriteBatch;

        public MonoGameTest()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Render targets
            int width = graphics.PreferredBackBufferWidth;
            int height = graphics.PreferredBackBufferHeight;
            RenderTargets = new RenderTargetBinding[] {
                new RenderTargetBinding(new RenderTarget2D(GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.Depth24)),
                new RenderTargetBinding(new RenderTarget2D(GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.Depth24))
            };

            // Fullscreen quad
            fullscreenQuad = new FullscreenQuad(GraphicsDevice);

            // Effect
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($@"MonoGameTest.Content.Effects.Clear.ogl.mgfx");
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                effect = new Effect(GraphicsDevice, ms.ToArray());
            }

            // Sprite batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            // Apply effect
            GraphicsDevice.SetRenderTargets(RenderTargets);
            effect.Techniques[0].Passes[0].Apply();
            fullscreenQuad.Draw();
            GraphicsDevice.SetRenderTargets(null);

            // Draw render targets
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.PointClamp, null, null);
            Rectangle rect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight);

            spriteBatch.Draw((Texture2D)RenderTargets[0].RenderTarget, rect, Color.White);

            rect.X += rect.Width;
            spriteBatch.Draw((Texture2D)RenderTargets[1].RenderTarget, rect, Color.White);

            spriteBatch.End();
        }
    }
}