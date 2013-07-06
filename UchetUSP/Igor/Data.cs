using System;
using System.Collections.Generic;
using System.Text;

namespace UchetUSP
{
    /// <summary>
    /// ����� ������ ������� ����� �������
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// ����������� ���������� ��� ������ �������
        /// </summary>
        public static object value;

        /// <summary>
        /// ������� ��� ������ �������
        /// </summary>
        /// <param name="data">������</param>
        public delegate void MyEvent(object data);
        /// <summary>
        /// �������, ��� ������� ���������� ���� ������
        /// </summary>
        public static MyEvent ElemsNEventHandler;

        /// <summary>
        /// ������� ��� ������� ������������ Dictionary
        /// </summary>
        /// <param name="data">������</param>
        public delegate void MyEventDict(Dictionary<string, string> Data);
        /// <summary>
        /// ������� ��������� ������� �������������� ������� ������ ����
        /// </summary>
        public static MyEventDict ElemsAfterEditingAss;
    }
}
