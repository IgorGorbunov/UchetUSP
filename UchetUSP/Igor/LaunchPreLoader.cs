using System;
using System.Collections.Generic;
using System.Text;

namespace UchetUSP
{
    /// <summary>
    /// ����� ��� ������� ����������
    /// </summary>
    class LaunchPreLoader
    {
        static FpreLoader PreLoaderForm = new FpreLoader();


        /// <summary>
        /// ������ ����������
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
