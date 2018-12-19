using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AsteroidsGameLibrary.Entities;
using MonogameUtilities;
using ShapesLibrary;

namespace AsteroidsGame.Renderers
{
    public static class SpaceShipRenderer
    {
        public static void Draw(SpriteBatch spriteBatch, SpaceShip spaceShip)
        {
            Texture2D texture = TextureManager.GetTexture(spaceShip.TextureId);
            var sourceRectangle = new Microsoft.Xna.Framework.Rectangle(0, 0, texture.Width, texture.Height);
            var body = new Microsoft.Xna.Framework.Rectangle((int)spaceShip.Position.X, (int)spaceShip.Position.Y, (int)spaceShip.Size.X, (int)spaceShip.Size.Y);
            var origin = new Vector2(spaceShip.Origin.X, spaceShip.Origin.Y);
            spriteBatch.Draw(texture, body, sourceRectangle, Color.White, spaceShip.RotationInRadians, origin, SpriteEffects.None, 0.0f);

            //DrawCollisionBoundary(spriteBatch, spaceShip);

            foreach (Laser laser in spaceShip.Lasers)
            {
                LaserRenderer.Draw(spriteBatch, laser);
            }
        }

        private static void DrawCollisionBoundary(SpriteBatch spriteBatch, SpaceShip spaceShip)
        {
            foreach (Shape shape in spaceShip.CollisionBoundary.Shapes)
            {
                var rect = (OrientedRectangle)shape;
                System.Numerics.Vector2 v0 = rect.Corner0;
                System.Numerics.Vector2 v1 = rect.Corner1;
                System.Numerics.Vector2 v2 = rect.Corner2;
                System.Numerics.Vector2 v3 = rect.Corner3;
                spriteBatch.DrawLine(new Vector2(v0.X, v0.Y), new Vector2(v1.X, v1.Y), Color.White);
                spriteBatch.DrawLine(new Vector2(v1.X, v1.Y), new Vector2(v2.X, v2.Y), Color.White);
                spriteBatch.DrawLine(new Vector2(v2.X, v2.Y), new Vector2(v3.X, v3.Y), Color.White);
                spriteBatch.DrawLine(new Vector2(v3.X, v3.Y), new Vector2(v0.X, v0.Y), Color.White);

                Circle circleHull = rect.GetCircleHull();
                spriteBatch.DrawCircle(new Vector2(circleHull.Center.X, circleHull.Center.Y), circleHull.Radius, 20, Color.White);

                ShapesLibrary.Rectangle rectHull = rect.GetRectangleHull();
                spriteBatch.DrawRectangle(new Microsoft.Xna.Framework.Rectangle((int)rectHull.Origin.X, (int)rectHull.Origin.Y, (int)rectHull.Size.X, (int)rectHull.Size.Y), Color.White);
            }
        }
    }
}