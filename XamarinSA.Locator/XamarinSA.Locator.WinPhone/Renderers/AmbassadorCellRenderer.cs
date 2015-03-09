using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.WinPhone;
using XamarinSA.Locator.Views.Cells;
using XamarinSA.Locator.WinPhone.Renderers;
using System.Windows.Media;
using XamarinSA.Locator.Misc;

[assembly: Xamarin.Forms.ExportRenderer(typeof(AmbassadorCell), typeof(AmbassadorCellRenderer))]
namespace XamarinSA.Locator.WinPhone.Renderers
{
    public class AmbassadorCellRenderer : ImageCellRenderer
    {
        public override System.Windows.DataTemplate GetTemplate(Xamarin.Forms.Cell cell)
        {
            var template = base.GetTemplate(cell);
            SolidColorBrush scb = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            var background = ColorStyles.XamarinDark;
            template.SetValue(CellControl.BorderBrushProperty, scb);
            template.SetValue(CellControl.BorderThicknessProperty, 1);
            template.SetValue(CellControl.BackgroundProperty, background);
            return template;
        }
        //public override UIKit.UITableViewCell GetCell(Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        //{
        //    var cell = base.GetCell(item, reusableCell, tv);

        //    cell.Accessory = UIKit.UITableViewCellAccessory.DisclosureIndicator;

        //    //set blue border for image
        //    cell.ImageView.Layer.BorderColor = Color.White.ToCGColor();
        //    cell.ImageView.Layer.BorderWidth = 1;
        //    cell.BackgroundColor = Color.FromHex(ColorStyles.XamarinDark).ToUIColor();

        //    return cell;
        //}
    }
}
