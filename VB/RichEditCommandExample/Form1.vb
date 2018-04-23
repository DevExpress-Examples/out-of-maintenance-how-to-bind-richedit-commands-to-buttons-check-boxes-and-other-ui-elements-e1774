Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.Commands

Namespace RichEditCommandExample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()

			InitializeComponent()
'			#Region "#commandbuttonusage"
			btnUndo.Command = New UndoCommand(richEditControl1)
			btnUndo.RichEditControl = richEditControl1
'			#End Region ' #commandbuttonusage

'			#Region "#commandbuttonadapterusage"
			Dim redoAdapter As New CommandButtonAdapter()
			redoAdapter.Button = btnRedo
			redoAdapter.Command = New RedoCommand(richEditControl1)
			redoAdapter.RichEditControl = richEditControl1
'			#End Region ' #commandbuttonadapterusage

			Dim fontBoldAdapter As New CommandCheckBoxAdapter()
			fontBoldAdapter.Command = New ToggleFontBoldCommand(richEditControl1)
			fontBoldAdapter.RichEditControl = richEditControl1
			fontBoldAdapter.CheckBox = chkToggleFontBold

		End Sub

		Private Sub btnToggleReadOnly_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnToggleReadonly.Click
			richEditControl1.ReadOnly = Not richEditControl1.ReadOnly
		End Sub
	End Class
End Namespace