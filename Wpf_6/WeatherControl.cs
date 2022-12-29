using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_6
{
    enum Precipitation
    {
       sunny ,
        cloudy,
        rain,
        snow
    }
    class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        private string windDirection;
        private int windSpeed;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public WeatherControl(string windDir, int windSpe, Precipitation precipitation)
        {
            this.WindDirection = windDir;
            this.WindSpeed = windSpe;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TempProperty;
        public double Temp
        {
            get => (double)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register
               (
                nameof(Temp),
                typeof(double),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                null, new CoerceValueCallback(CoerceTemp)), new ValidateValueCallback(ValidTemp));
        }
        private static bool ValidTemp(object value)
        {
            double v = (double)value;
            if ((v <= 50) && (v >= -50))
                return true;
            else
                return false;

        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            double v = (double)baseValue;
            if ((v <= 50) && (v >= -50))
                return v;
            else
                return 0;

        }
    }
}
