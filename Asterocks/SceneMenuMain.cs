using System.Drawing;
using Engine;
using Engine.Math;

namespace Asterocks
{
    class SceneMenuMain : Scene
    {
        public SceneMenuMain()
        {
            Image imgBg = Image.FromFile(Const.FILENAME_BG_MAINMENU);
            Sprite objBg = new Sprite(new Vector2(0.0F, 0.0F), imgBg);
            Add(objBg);

            Add(new TitleStart());
        }
    }
}
