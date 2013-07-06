using System;
using System.Collections.Generic;
using System.Text;

namespace UchetUSP
{
    /// <summary>
    /// Класс обмена данными между формами
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// Статическая переменная для обмена данными
        /// </summary>
        public static object value;

        /// <summary>
        /// Делегат для нашего события
        /// </summary>
        /// <param name="data">данные</param>
        public delegate void MyEvent(object data);
        /// <summary>
        /// Событие, при котором передаются наши данные
        /// </summary>
        public static MyEvent ElemsNEventHandler;

        /// <summary>
        /// Делегат для события возвращающее Dictionary
        /// </summary>
        /// <param name="data">данные</param>
        public delegate void MyEventDict(Dictionary<string, string> Data);
        /// <summary>
        /// Событие окончания ручного редактирования состава сборки УСПО
        /// </summary>
        public static MyEventDict ElemsAfterEditingAss;
    }
}
