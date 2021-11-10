using System.Drawing;

namespace Scheduler1
{
    public static class Globals
    {
        //
        // https://www.webfx.com/web-design/hex-to-rgb/
        //
        
        public static readonly Color FontLight =
            Color.FromArgb(255, 255, 255);

        public static readonly Color FontDark =
            Color.FromArgb(19, 15, 64);

        public static readonly Color FormBackground =
            Color.FromArgb(223, 249, 251);

        public static readonly Color MenuElement =
            Color.FromArgb(104, 109, 224);
        
        public static readonly Color Button1 =
            Color.FromArgb(186, 220, 88);
        
        public static readonly Color Button2 =
            Color.FromArgb(255, 121, 121);
        
        public static readonly Font HeaderBarFont = 
            new Font("Gotham Pro Medium", 20);
        
        public static readonly Font ButtonFont = 
            new Font("Gotham Pro Medium", 17);
        
        public static readonly int MainSize = 50;
        
    }
}