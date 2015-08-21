using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Views
{
    public class CircleLabelView : Label
    {
        public CircleLabelView()
        {
            HeightRequest = 30;
            WidthRequest = 30;
        }

        /// <summary>
        /// BindableProperty solo de lectura
        /// </summary>
        public static readonly BindableProperty TextRadialProperty = BindableProperty.Create((CircleLabelView R) => R.TextRadial, string.Empty);

        /// <summary>
        /// BindableProperty Color solo lectura
        /// </summary>
        public static readonly BindableProperty BackColorProperty = BindableProperty.Create((CircleLabelView R) => R.BackColor, Color.Default);

        /// <summary>
        /// Propiedad para cambiar el texto del radial
        /// </summary>
        public string TextRadial
        {
            get { return (string)GetValue(TextRadialProperty); }
            set { SetValue(TextRadialProperty, value); }
        }

        /// <summary>
        /// Propiedad para cambiar el color del elemento
        /// </summary>
        public Color BackColor
        {
            get { return (Color)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }


        /// <summary>
        /// Posicion X a mover el elemento
        /// TODO: Escalar esta propiedad con deteccion automatica
        /// </summary>
        public int XPosition { get; set; }


        /// <summary>
        /// posicion en la que agregara el alert en la grid
        /// </summary>
        public int UIAlertColumnPosition { get; set; }
    }
}
