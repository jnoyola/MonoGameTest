using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTest
{
    class FullscreenQuad
    {
        GraphicsDevice graphicsDevice;
        VertexBuffer vb;
        IndexBuffer ib;

        public FullscreenQuad(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;

            // Vertices
            VertexPositionTexture[] vertices =
            {
                new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, 1)),
                new VertexPositionTexture(new Vector3(-1, -1, 0), new Vector2(0, 1)),
                new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(0, 0)),
                new VertexPositionTexture(new Vector3(1, 1, 0), new Vector2(1, 0))
            };

            // Make vertex buffer
            vb = new VertexBuffer(graphicsDevice, VertexPositionTexture.VertexDeclaration, vertices.Length, BufferUsage.None);
            vb.SetData<VertexPositionTexture>(vertices);

            // Indices
            ushort[] indices = { 0, 1, 2, 2, 3, 0 };

            // Make index buffer
            ib = new IndexBuffer(graphicsDevice, IndexElementSize.SixteenBits, indices.Length, BufferUsage.None);
            ib.SetData<ushort>(indices);
        }
        
        public void Draw()
        {
            graphicsDevice.SetVertexBuffer(vb);
            graphicsDevice.Indices = ib;
            graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 2);
        }
    }
}
