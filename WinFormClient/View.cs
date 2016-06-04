using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace WinFormClient
{
    public class View
    {
        /// <summary>
        /// Временное решение... есть проблемы с позицией иконок в неравнопропорциональных размерах поля
        /// </summary>
        /// <param name="field"></param>
        /// <param name="panel"></param>
        public void Present(Field field, Control panel)
        {
            var g = Graphics.FromImage(Form1.bitMap);
            g.Clear(Color.White);
            for (int i = 0; i < panel.Size.Width; i += panel.Size.Width / field.XLenght)
            {
                g.DrawLine(Pens.Aqua, i, i - i, i, i + panel.Size.Height);
            }
            for (int i = 0; i < panel.Size.Height; i += panel.Size.Height / field.YLenght)
            {
                g.DrawLine(Pens.Aqua, i - i, i, i + panel.Size.Width, i);
            }

            g.PageUnit = GraphicsUnit.Pixel;
            g.PageScale = (panel.Size.Width + panel.Size.Height) / (field.XLenght + field.YLenght);
            foreach (var item in field.GameObjects)
            {
                g.DrawString(item.Icon.ToString(), new Font(FontFamily.GenericSansSerif, (panel.Size.Width / field.XLenght) - 10), Brushes.Brown, item.PosX, item.PosY);
            }
            panel.Invalidate();
        }
    }
}
