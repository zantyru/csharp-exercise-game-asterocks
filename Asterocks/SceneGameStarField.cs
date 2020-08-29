using System.Drawing;
using Engine;
using Engine.Math;

namespace Asterocks
{
    public class SceneGameStarField : Scene
    {
        public SceneGameStarField(int nStars, Vector2 velocity, Vector2 velocityBias, Image imgStar)
        {
            Star objStar;
            Vector2 posStar;
            Vector2 velStar;
            for (int i = 0; i < nStars; i++)
            {
                posStar = new Vector2(
                    (float)(Core.Random.NextDouble() * Core.WindowWidth),
                    (float)(Core.Random.NextDouble() * Core.WindowHeight)
                );
                velStar = velocity + (float)(Core.Random.NextDouble()) * velocityBias;
                objStar = new Star(posStar, velStar, imgStar);
                Add(objStar);
            }
        }
    }
}
