using System;
using System.Collections.Generic;
using System.Text;

namespace UchetUSP
{
    /// <summary>
    /// Класс для запуска прелоадера
    /// </summary>
    class LaunchPreLoader
    {
        static FpreLoader PreLoaderForm = new FpreLoader();


        /// <summary>
        /// Запуск прелоадера
        /// </summary>
        public static void start()
        {
            PreLoaderForm.ShowDialog();
        }

        public static void stop()
        {
            PreLoaderForm.Close();
        }
    }
}
