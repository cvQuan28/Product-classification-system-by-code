using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using SymbolFactoryDotNet;

namespace FORM_SACADA
{
    class Class_Status_Display
    {
        //============================trạng thái băng tải==========================
        public void stt_conveyor(StandardControl st, string value)
        {
            if (value == "True")
            {
                st.DiscreteValue1 = true;
                //st.DiscreteValue2 = false;
            }
            else
            {
                st.DiscreteValue1 = false;

            }

        }


        //============================trạng thái nút ấn===========================
        public void STT_Button(Button btt, string value, string backcolor, string forecolor)
        {
            if (value == "True")
            {
                btt.BackColor = ColorTranslator.FromHtml(backcolor);
                btt.ForeColor = ColorTranslator.FromHtml(forecolor);
                

            }
            else
            {
                btt.BackColor = default(Color);
                btt.ForeColor = default(Color);
            }
        }
        //=============================trạng thái sensor==============================
        public void stt_sensor(StandardControl st, string value)
        {
            if (value == "True")
            {
                st.DiscreteValue1 = true;
            }
            else
            {
                st.DiscreteValue1 = false;

            }
        }
        //=============================trạng thái cylinder==============================
        public void stt_cylinder(StandardControl st, string value)
        {
            if (value == "True")
            {
                st.DiscreteValue1 = true;
            }
            else
            {
                st.DiscreteValue1 = false;

            }
        }

        //=============================trạng thái cylinder==============================
        public void simu_cylinder(StandardControl st, string value)
        {
            if (value == "True")
            {
                st.Visible = true;
            }
            else
            {
                st.Visible = false;

            }
        }
        public void STT_Textbox(TextBox txb, string value, string backcolor, string forecolor)
        {
            if (value == "True")
            {
                txb.BackColor = ColorTranslator.FromHtml(backcolor);
                txb.ForeColor = ColorTranslator.FromHtml(forecolor);


            }
            else
            {
                txb.BackColor = default(Color);
                txb.ForeColor = default(Color);
            }
        }

    }
}
