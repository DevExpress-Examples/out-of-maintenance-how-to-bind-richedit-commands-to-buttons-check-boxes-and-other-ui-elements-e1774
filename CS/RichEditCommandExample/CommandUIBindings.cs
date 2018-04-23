using System;
using System.Collections.Generic;
using System.Text;
#region #usings
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.Utils.Commands;
#endregion #usings

namespace RichEditCommandExample {
    #region #commandbutton
    public class CommandButton : SimpleButton {
        Command command;
        RichEditControl control;

        public RichEditControl RichEditControl {
            get { return control; }
            set {
                if(control == value)
                    return;
                UnsubscribeControlEvents();
                this.control = value;
                SubscribeControlEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        public Command Command {
            get { return command; }
            set {
                if(command == value)
                    return;
                command = value;
                OnUpdateUI(this, EventArgs.Empty);
            }
        }

        void SubscribeControlEvents() {
            if(control == null)
                return;
            control.UpdateUI += OnUpdateUI;
        }
        void UnsubscribeControlEvents() {
            if(control == null)
                return;
            control.UpdateUI -= OnUpdateUI;
        }

        void OnUpdateUI(object sender, EventArgs e) {
            Command command = CreateCommand();
            if(command != null) {
                CommandButtonUIState state = new CommandButtonUIState(this);
                command.UpdateUIState(state);
            }
        }

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);
            Command command = CreateCommand();
            if(command != null)
                command.Execute();
        }

        // You may override this method to create a command
        protected virtual Command CreateCommand() {
            return command;
        }
    }
    #endregion #commandbutton
    #region #commandbuttonuistate
    public class CommandButtonUIState : ICommandUIState {
        readonly SimpleButton button;
        public CommandButtonUIState(SimpleButton button) {
            this.button = button;
        }
        #region ICommandUIState Members
        public bool Checked { get { return false; } set {} }
        public bool Enabled { get { return button.Enabled; } set { button.Enabled = value; } }
        public bool Visible { get { return button.Visible; } set { button.Visible = value; } }
        #endregion
    }
    #endregion #commandbuttonuistate

    public class CommandCheckBoxAdapter {
        Command command;
        RichEditControl control;
        CheckEdit checkBox;

        public CheckEdit CheckBox {
            get { return checkBox; }
            set {
                if(checkBox == value)
                    return;

                UnsubscribeCheckBoxEvents();
                checkBox = value;
                SubscribeCheckBoxEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        void SubscribeCheckBoxEvents() {
            if(checkBox == null)
                return;

            checkBox.CheckedChanged += OnCheckedChanged;
        }
        void UnsubscribeCheckBoxEvents() {
            if(checkBox == null)
                return;

            checkBox.CheckedChanged -= OnCheckedChanged;
        }            
        public RichEditControl RichEditControl {
            get { return control; }
            set {
                if(control == value)
                    return;
                UnsubscribeControlEvents();
                this.control = value;
                SubscribeControlEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        public Command Command {
            get { return command; }
            set {
                if(command == value)
                    return;
                command = value;
                OnUpdateUI(this, EventArgs.Empty);
            }
        }


        void SubscribeControlEvents() {
            if(control == null)
                return;
            control.UpdateUI += OnUpdateUI;
        }
        void UnsubscribeControlEvents() {
            if(control == null)
                return;
            control.UpdateUI -= OnUpdateUI;
        }

        void OnUpdateUI(object sender, EventArgs e) {
            if(checkBox == null)
                return;
            checkBox.CheckedChanged -= OnCheckedChanged;
            try {
                Command command = CreateCommand();
                if(command != null) {
                    CommandCheckBoxUIState state = new CommandCheckBoxUIState(checkBox);
                    command.UpdateUIState(state);
                }
            }
            finally {
                checkBox.CheckedChanged += OnCheckedChanged;
            }
        }

        void OnCheckedChanged(object sender, EventArgs e) {
            checkBox.CheckedChanged -= OnCheckedChanged;
            try {
                Command command = CreateCommand();
                if(command != null)
                    command.Execute();
            }
            finally {
                checkBox.CheckedChanged += OnCheckedChanged;
            }
        }

        // You may override this method to create command
        protected virtual Command CreateCommand() {
            return command;
        }
    }

    public class CommandCheckBoxUIState : ICommandUIState {
        readonly CheckEdit checkBox;
        public CommandCheckBoxUIState(CheckEdit checkBox) {
            this.checkBox = checkBox;
        }
        #region ICommandUIState Members
        public bool Checked { get { return checkBox.Checked; } set { checkBox.Checked = value; } }
        public bool Enabled { get { return checkBox.Enabled; } set { checkBox.Enabled = value; } }
        public bool Visible { get { return checkBox.Visible; } set { checkBox.Visible = value; } }
        #endregion
    }
    #region #commandbuttonadapter
    public class CommandButtonAdapter {
        Command command;
        RichEditControl control;
        SimpleButton button;

        public RichEditControl RichEditControl {
            get { return control; }
            set {
                if(control == value)
                    return;
                UnsubscribeControlEvents();
                this.control = value;
                SubscribeControlEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        public Command Command {
            get { return command; }
            set {
                if(command == value)
                    return;
                command = value;
                OnUpdateUI(this, EventArgs.Empty);
            }
        }

        public SimpleButton Button {
            get { return button; }
            set {
                if(button == value)
                    return;

                UnsubscribeButtonEvents();
                button = value;
                SubscribeButtonEvents();
                OnUpdateUI(this, EventArgs.Empty);
            }
        }
        void SubscribeButtonEvents() {
            if(button == null)
                return;

            button.Click += OnClick;
        }
        void UnsubscribeButtonEvents() {
            if(button == null)
                return;

            button.Click -= OnClick;
        }
        void SubscribeControlEvents() {
            if(control == null)
                return;
            control.UpdateUI += OnUpdateUI;
        }
        void UnsubscribeControlEvents() {
            if(control == null)
                return;
            control.UpdateUI -= OnUpdateUI;
        }

        void OnUpdateUI(object sender, EventArgs e) {
            if(button == null)
                return;

            Command command = CreateCommand();
            if(command != null) {
                CommandButtonUIState state = new CommandButtonUIState(button);
                command.UpdateUIState(state);
            }
        }

        void OnClick(object sender, EventArgs e) {
            Command command = CreateCommand();
            if(command != null)
                command.Execute();
        }

        // You may override this method to create a command
        protected virtual Command CreateCommand() {
            return command;
        }
    }
    #endregion #commandbuttonadapter
}

