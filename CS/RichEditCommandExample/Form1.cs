using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Commands;

namespace RichEditCommandExample {
    public partial class Form1 : Form {
        public Form1() {

            InitializeComponent();
            #region #commandbuttonusage
            btnUndo.Command = new UndoCommand(richEditControl1);
            btnUndo.RichEditControl = richEditControl1;
            #endregion #commandbuttonusage

            #region #commandbuttonadapterusage
            CommandButtonAdapter redoAdapter = new CommandButtonAdapter();
            redoAdapter.Button = btnRedo;
            redoAdapter.Command = new RedoCommand(richEditControl1);
            redoAdapter.RichEditControl = richEditControl1;
            #endregion #commandbuttonadapterusage

            CommandCheckBoxAdapter fontBoldAdapter = new CommandCheckBoxAdapter();            
            fontBoldAdapter.Command = new ToggleFontBoldCommand(richEditControl1);
            fontBoldAdapter.RichEditControl = richEditControl1;
            fontBoldAdapter.CheckBox = chkToggleFontBold;
            
        }

        private void btnToggleReadOnly_Click(object sender, EventArgs e) {
            richEditControl1.ReadOnly = !richEditControl1.ReadOnly;
        }
    }
}