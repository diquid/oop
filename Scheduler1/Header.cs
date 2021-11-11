using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Scheduler1
{
    //
    // Прошу прощения, есть некая неудобная вещь. Для невероятно красивого дизайна
    // Header (это лейбл с кнопкой назад и настройки вверху окна) пришлось прикрепить
    // кнопки к лейблу на правой и левой стороне, что как бы делает кнопки зависимыми
    // от этого лейбла (надеюсь понятно) и возникает абсолютно не очевидная (не сарказм)
    // строка кода 'controls.Add(page.Header.Label);' в Page.cs. Если будут идеи как
    // заменить эту строку на 'controls.Add(page.Header);', будет отлично.
    //
    /// <summary>
    /// Заголовок с кнопками назад и настроек
    /// </summary>
    public class Header : Control
    {
        public readonly Color Color;
        public readonly Label Label;
        public readonly Button BackButton;
        public readonly Button SettingsButton;

        public Header(Size clientSize, Color color)
        {
            Color = color;
            Label = new Label
            {
                Dock = DockStyle.Top,
                Size = new Size(clientSize.Width, Globals.MainSize),
                BackColor = Color,
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(Globals.MainSize, 0, 0, 0)
            };
            BackButton = new Button
            {
                Dock = DockStyle.Left,
                Size = new Size(Globals.MainSize, Globals.MainSize),
                BackColor = Color,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\6.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = {BorderSize = 0}
            };
            SettingsButton = new Button
            {
                Dock = DockStyle.Right,
                Size = new Size(Globals.MainSize, Globals.MainSize),
                BackColor = Color,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\1.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = {BorderSize = 0}
            };

            Label.Controls.Add(SettingsButton);
            Label.Controls.Add(BackButton);
        }
    }
}