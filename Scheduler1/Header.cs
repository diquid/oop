using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public sealed class Header : Control
    {
        public readonly Dictionary<ElementsTypes, Control> Elements;

        public Header(string text, Color color, IEnumerable<ElementsTypes> elementsTypes)
        {
            Elements = new Dictionary<ElementsTypes, Control>();
            Height = 50;
            Dock = DockStyle.Top;
            BackColor = color;

            foreach (var e in elementsTypes)
            {
                switch (e)
                {
                    case ElementsTypes.SettingsBtn:
                        Elements.Add(ElementsTypes.SettingsBtn,
                            new PatternMenuButton(color) 
                            {
                                Dock = DockStyle.Right, 
                                BackgroundImage = Image.FromFile(
                                    Files.GetPathTo(@"Icons\1.png"))
                            });
                        break;
                    case ElementsTypes.BackBtn:
                        Elements.Add(ElementsTypes.BackBtn,
                            new PatternMenuButton(color) 
                            {
                                Dock = DockStyle.Left, 
                                BackgroundImage = Image.FromFile(
                                    Files.GetPathTo(@"Icons\6.png"))
                            });
                        break;
                    case ElementsTypes.AddBtn:
                        Elements.Add(ElementsTypes.AddBtn, 
                            new PatternMenuButton(color) 
                            {
                                Dock = DockStyle.Right, 
                                BackgroundImage = Image.FromFile(
                                Files.GetPathTo(@"Icons\add.png"))
                            });
                        break;
                    case ElementsTypes.Label:
                        Elements.Add(ElementsTypes.Label, 
                            new Label 
                            {
                                Text = text,
                                Dock = DockStyle.Left, 
                                AutoSize = true, 
                                Font = Globals.HeaderBarFont, 
                                ForeColor = Globals.FontLight
                            });
                        break;
                    case ElementsTypes.HistoryBtn:
                        Elements.Add(ElementsTypes.HistoryBtn,
                            new PatternMenuButton(color)
                            {
                                Dock = DockStyle.Right,
                                BackgroundImage = Image.FromFile(
                                    Files.GetPathTo(@"Icons\history.png"))
                            });
                        break;
                    case ElementsTypes.DeleteBtn:
                        Elements.Add(ElementsTypes.DeleteBtn,
                            new PatternMenuButton(color) 
                            {
                                Dock = DockStyle.Right,
                                BackgroundImage = Image.FromFile(
                                    Files.GetPathTo(@"Icons\can.png"))
                            });
                        break;
                    default:
                        throw new ArgumentException("Wrong ElementsTypes");
                }
            }

            foreach (var pair in Elements) 
                Controls.Add(pair.Value);
        }
    }
}