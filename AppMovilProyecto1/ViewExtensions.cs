using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace AppMovilProyecto1
{
    public static class ViewExtensions
    {
        public static Point GetRelativePosition(this View view, VisualElement relativeTo)
        {
            double x = 0;
            double y = 0;

            while (view != null && view != relativeTo)
            {
                x += view.X;
                y += view.Y;
                view = view.Parent as View;
            }
            return new Point(x, y);

        }


    }
}
