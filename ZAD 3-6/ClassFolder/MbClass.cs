using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZAD_3_6.ClassFolder
{
    internal class MbClass
    {
        public static void ErrorMB(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void ErrorMB(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void InfoMB(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        public static bool QuestionMB(string text)
        {
            return MessageBoxResult.Yes == MessageBox.Show(text,
                "Вопрос", MessageBoxButton.YesNo,
                MessageBoxImage.Error);
        }

        public static void ExitMB()
        {
            if (QuestionMB("Вы точно хотите выйти?"))
            {
                App.Current.Shutdown();
            }
        }
    }
}
