using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.ValueConverters
{
    class BookIdToImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            try
            {
                int id = (int)value;

                ////string appFolder = AppDomain.CurrentDomain.RelativeSearchPath;
                //string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appFolder = "E:\\Kursovaya 2.0\\Pics";
                //string rootFolder = AppDomain.CurrentDomain.FriendlyName;
                string[] files = Directory.GetFiles(appFolder, $"image{id}.*");
                return ImageSource.FromFile(files[0]);
            }
            catch 
            {
                return ImageSource.FromFile("dotnet_bot.png");
            }

       }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
