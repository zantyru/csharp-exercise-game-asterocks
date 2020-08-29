using System.Drawing;
using Engine;
using Engine.Math;

namespace Asterocks
{
    public class SceneGameBackground : Scene
    {
        public SceneGameBackground()
        {
            Image imgBg = Image.FromFile(Const.FILENAME_BG_STARFIELD0001);
            Sprite objBg = new Sprite(new Vector2(0.0F, 0.0F), imgBg);
            Add(objBg);
        }
    }
}
