using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.Layout
{
    partial class Layout : IDisposable
    {
         //отображение строки статуса для pictureBox
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Изображение УСП по ГОСТ";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Поиск элементов по заданным критериям";
        }

        private void button1_MouseHover_LoadNX(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Просмотр элементов УСП в NX";
        }

        private void button1_MouseHover_Edit(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Редактирование информации о элементах УСП";
        }
        private void button1_MouseHover_Delete(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Сокращение количества элементов УСП";
        }

        private void treeView1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Сортировка элементов УСП по дереву";
        }
        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Отображение элементов УСП";
        }
    }


    partial class LayoutOrderTZ : IDisposable
    {
        private void buttonView_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Оформление техничесого задания";
        }
             
        private void buttonEdit_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Редактирование технического задания";
        }

        private void buttonFind_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Поиск технического задания";
        }
        private void BeginTime_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Начальная дата для сортировки технического задания";
        }

        private void EndTime_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Конечная дата для сортировки технического задания";
        }
        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Техническое задание";
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {

            if (String.Compare(comboBox1.Text, "Разработка") == 0)                
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы с возможностью внесения изменений";

            if (String.Compare(comboBox1.Text, "Подписано") == 0)
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы с возможностью просмотра";
        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            if (String.Compare(comboBox2.Text, "ТЗ оформлено") == 0)
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы, которые были заполнены ранее";

            if (String.Compare(comboBox2.Text, "ТЗ не оформлено") == 0)
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы, которые не заполнлись ранее";
        }
        private void comboBox3_MouseHover(object sender, EventArgs e)
        {
            if (String.Compare(comboBox3.Text, "Проработка") == 0)
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы, которые находятся на проработке";

            if (String.Compare(comboBox3.Text, "Утвержденные") == 0)
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы, которые были утверждены";

            if (String.Compare(comboBox3.Text, "Архив") == 0)
                ParentToolStripStatusLabel.Text = "Тип сортировки установлен на документы, которые находятся в архиве";
        }
        private void Update_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "Обновление информации";
        }



        
    }
    
    
    partial class LayoutOrder : IDisposable
        {

            private void comboBox1_MainForm(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "ВСЕ") == 0)
                        ParentToolStripStatusLabel.Text = "Вывод на экран всех документов";

                if (String.Compare(comboBox1.Text, "ВПП") == 0)
                    ParentToolStripStatusLabel.Text = "Вывод на экран  ВПП";

                    if (String.Compare(comboBox1.Text, "ВЗД") == 0)
                        ParentToolStripStatusLabel.Text = "Вывод на экран  ВЗД";

                  
                    if (String.Compare(comboBox1.Text, "ТЗ (без ВПП)") == 0)
                        ParentToolStripStatusLabel.Text = "Вывод на экран ТЗ, оформленых в АС \"Учет УСП\"";
            }

            private void comboBox2_MainForm(object sender, EventArgs e)
            {
                if (String.Compare(comboBox2.Text, "ВСЕ") == 0)
                    ParentToolStripStatusLabel.Text = "Печать всех документв в Excel";

                if (String.Compare(comboBox2.Text, "ВПП") == 0)
                    ParentToolStripStatusLabel.Text = "Печать ВПП/ВЗД в Excel";

                if (String.Compare(comboBox2.Text, "ТЗ") == 0)
                    ParentToolStripStatusLabel.Text = "Печать ТЗ в Excel";


                if (String.Compare(comboBox2.Text, "Спецификация") == 0)
                    ParentToolStripStatusLabel.Text = "Печать спецификации в Excel";
            }

            private void dGV_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "Отображение новых заказов. Щелкните 2 раза на желаемой позиции для формирования Листа Заказа";               
            }

            private void button3_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "Выгрузить модель сборки УСПО в NX для желаемой позиции";               
            }

             private void button4_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "Поиск заказов по заданным критериям";               
            }

             private void dateTimePicker1_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "Начальная дата для сортировки заказов";               
            }
            private void dateTimePicker2_MainForm(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Конечная дата для сортировки заказов";
            }    
        
            ///Confirm Order

            private void dGV_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Отображение Листов Заказа. Щелкните 2 раза на желаемой позиции для вызова мастера подтверждения исполнения заказа на сборку УСПО";
            }    
            private void dateTimePicker1_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Начальная дата для сортировки Листов Заказа";
            }    
            private void dateTimePicker2_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Конечная дата для сортировки Листов Заказа";
            }
            private void button3_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Поиск Листов Заказа по заданным критериям";
            }
             private void comboBox1_ConfirmOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "Отобразить в Excel") == 0)
                    ParentToolStripStatusLabel.Text = "отображение Листов Заказа в Excel";

                if (String.Compare(comboBox1.Text, "Удалить") == 0)
                    ParentToolStripStatusLabel.Text = "Удаление Листов Заказа";
               
            }

             //Grant Order

            private void dGV_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Отображение Листов Заказа. Щелкните 2 раза на желаемой позиции для вызова мастера выдачи сборки УСПО";
            }

            private void dateTimePicker1_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Начальная дата для сортировки Листов Заказа";
            }
            private void dateTimePicker2_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Конечная дата для сортировки Листов Заказа";
            }
            private void button3_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Поиск Листов Заказа по заданным критериям";
            }
            private void comboBox1_GrantOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "Отобразить в Excel") == 0)
                    ParentToolStripStatusLabel.Text = "отобраение Листов Заказа в Excel";

                if (String.Compare(comboBox1.Text, "Отменить сборку") == 0)
                    ParentToolStripStatusLabel.Text = "Перевод Листов Заказа на предыдущую стадию";

                if (String.Compare(comboBox1.Text, "Удалить") == 0)
                    ParentToolStripStatusLabel.Text = "Удаление Листов Заказа";
               
            }
        
            //Get Order

            private void dGV_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Отображение Листов Заказа. Щелкните 2 раза на желаемой позиции для вызова мастера возврата оснастки на участов УСПО";
            }

            private void dateTimePicker1_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Начальная дата для сортировки Листов Заказа";
            }
            private void dateTimePicker2_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Конечная дата для сортировки Листов Заказа";
            }
            private void button3_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Поиск Листов Заказа по заданным критериям";
            }
            private void comboBox1_GetOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "Отобразить в Excel") == 0)
                    ParentToolStripStatusLabel.Text = "отобраение Листов Заказа в Excel";

                if (String.Compare(comboBox1.Text, "Отменить выдачу заказчику") == 0)
                    ParentToolStripStatusLabel.Text = "Перевод Листов Заказа на предыдущую стадию";

                if (String.Compare(comboBox1.Text, "Удалить") == 0)
                    ParentToolStripStatusLabel.Text = "Удаление Листов Заказа";

            }


            //HistoryOrder

        private void dGV_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Отображение Листов Заказа";
            }

            private void dateTimePicker1_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Начальная дата для сортировки Листов Заказа";
            }
            private void dateTimePicker2_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Конечная дата для сортировки Листов Заказа";
            }
            private void button3_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Поиск Листов Заказа по заданным критериям";
            }
            private void dTPAssCard_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "Месяц вывода карты складского учета по сборкам УСПО";
            }

            private void comboBox1_HistoryOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "Отобразить в Excel") == 0)
                    ParentToolStripStatusLabel.Text = "отобраение Листов Заказа в Excel";

                if (String.Compare(comboBox1.Text, "Отменить возвращение на склад") == 0)
                    ParentToolStripStatusLabel.Text = "Перевод Листов Заказа на предыдущую стадию";

                if (String.Compare(comboBox1.Text, "Удалить") == 0)
                    ParentToolStripStatusLabel.Text = "Удаление Листов Заказа";

            }


        
        }
}
