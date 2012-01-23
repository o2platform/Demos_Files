using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SqlInjection_DatabaseExplorer
{
    public class debugInfo
    {
        public static TextBox tbDebugMessages;

        public static void setTargetTextBoxForDebugMessages(TextBox tbTextBox)
        {
            tbDebugMessages = tbTextBox;
        }

        public static void addDebugMessageOnTop(string strDebugMessageToAdd)
        {            
            tbDebugMessages.Text = "[" + DateTime.Now.ToLongTimeString() + "]   :  " + strDebugMessageToAdd + Environment.NewLine + tbDebugMessages.Text;
            Application.DoEvents();
        }

    }
}
