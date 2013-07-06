using System;
using System.Collections;
using System.Windows.Forms;

namespace ElementInform
{
    /// <summary>
    /// Summary description for ArrayOfControllers.
    /// </summary>
    public class ArrayOfComboBox : System.Collections.CollectionBase
    {
        private readonly System.Windows.Forms.Form HostForm;

        public ArrayOfComboBox(System.Windows.Forms.Form host)
        {
            HostForm = host;

            this.AddNewComboBox();

        }

        public System.Windows.Forms.ComboBox AddNewComboBox()
        {

            System.Windows.Forms.ComboBox aComboBox = new System.Windows.Forms.ComboBox();

            this.List.Add(aComboBox);

            HostForm.Controls.Add(aComboBox);

            aComboBox.Items.AddRange(new object[] {	  "������������",
													  "�����������",
													  "����",
													  "L",
													  "B",
													  "B1",
													  "H",
													  "D",
													  "D1",
													  "d",
													  "d1",
													  "alfa",
													  "S",
													  "b",
													  "H0",
													  "h",
													  "t",
													  "N",
													  "�����",
													  "�������",
													  "�����������������"});
            aComboBox.Top = (this.Count - 1) * 21;
            aComboBox.Left = 0;
            aComboBox.Tag = this.Count;
            aComboBox.Width = 200;
            aComboBox.Height = 21;
            aComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //������������ �������� ���������� ComboBox �� ��������������� �������. ���� ����� ������������ �������� ���
            //������ � ���������� ComboBox, �� ������������ ����� ��� �� ��������� �������� � �� ����������.

            bool currentIndex = true;

            if (this.Count != 1)
            {
                for (int i = 0; i < this.Count; i++)
                {

                    try
                    {
                        for (int j = 0; j < this.Count; j++)
                            if (((int)(((System.Windows.Forms.ComboBox)this.List[j]).SelectedIndex)) == i)
                            {
                                currentIndex = false;
                                break;
                            }
                            else
                            {
                                currentIndex = true;
                            }

                        if (currentIndex == true)
                        {
                            aComboBox.Text = aComboBox.Items[i].ToString();
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            else
            {
                aComboBox.Text = aComboBox.Items[0].ToString();
            }




            aComboBox.SelectedValueChanged += new System.EventHandler(SelectionChange);
            aComboBox.Click += new System.EventHandler(ClickComboBox);
            return aComboBox;
        }




        public System.Windows.Forms.ComboBox this[int Index]
        {
            get
            {
                return (System.Windows.Forms.ComboBox)this.List[Index];
            }
        }




        public void Remove()
        {

            if (this.Count > 0)
            {
                HostForm.Controls.Remove(this[this.Count - 1]);
                this.List.RemoveAt(this.Count - 1);
            }
        }

        //���� ���������� ������ � ComboBOx, ������� ��� ����������� ������ COmboBOx,�� ������������ ��� ������ ��������.

        public void SelectionChange(Object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.Count; i++)
            {
                try
                {
                    if (((int)((ComboBox)sender).Tag) != ((int)(((System.Windows.Forms.ComboBox)this.List[i]).Tag)))
                    {


                        if (((System.Windows.Forms.ComboBox)sender).SelectedIndex == this[i].SelectedIndex)
                        {
                            ((System.Windows.Forms.ComboBox)sender).SelectedIndex = indexClicked;
                            MessageBox.Show("����� ����� ��� ������!");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        //����������� �� ����� ���� �������� ������� ComboBox.

        private int indexClicked = 0;


        public void ClickComboBox(Object sender, System.EventArgs e)
        {
            indexClicked = ((System.Windows.Forms.ComboBox)sender).SelectedIndex;

        }







    }
}
