<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditSubmission
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSubmitEdit = New System.Windows.Forms.Button()
        Me.txtEditName = New System.Windows.Forms.TextBox()
        Me.txtEditEmail = New System.Windows.Forms.TextBox()
        Me.txtEditPhone = New System.Windows.Forms.TextBox()
        Me.txtEditGithubLink = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEditStopwatchTime = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(257, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(269, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "John Doe, Slidely Task 2 - Slidely Form App"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(208, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(208, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Phone"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(208, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "GitHub Link for Task 2"
        '
        'btnSubmitEdit
        '
        Me.btnSubmitEdit.Location = New System.Drawing.Point(211, 366)
        Me.btnSubmitEdit.Name = "btnSubmitEdit"
        Me.btnSubmitEdit.Size = New System.Drawing.Size(346, 23)
        Me.btnSubmitEdit.TabIndex = 6
        Me.btnSubmitEdit.Text = "SUBMIT"
        Me.btnSubmitEdit.UseVisualStyleBackColor = True
        '
        'txtEditName
        '
        Me.txtEditName.Location = New System.Drawing.Point(367, 143)
        Me.txtEditName.Name = "txtEditName"
        Me.txtEditName.Size = New System.Drawing.Size(190, 22)
        Me.txtEditName.TabIndex = 7
        '
        'txtEditEmail
        '
        Me.txtEditEmail.Location = New System.Drawing.Point(367, 189)
        Me.txtEditEmail.Name = "txtEditEmail"
        Me.txtEditEmail.Size = New System.Drawing.Size(190, 22)
        Me.txtEditEmail.TabIndex = 8
        '
        'txtEditPhone
        '
        Me.txtEditPhone.Location = New System.Drawing.Point(367, 234)
        Me.txtEditPhone.Name = "txtEditPhone"
        Me.txtEditPhone.Size = New System.Drawing.Size(190, 22)
        Me.txtEditPhone.TabIndex = 9
        '
        'txtEditGithubLink
        '
        Me.txtEditGithubLink.Location = New System.Drawing.Point(367, 284)
        Me.txtEditGithubLink.Name = "txtEditGithubLink"
        Me.txtEditGithubLink.Size = New System.Drawing.Size(190, 22)
        Me.txtEditGithubLink.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(208, 333)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Stopwatch Time"
        '
        'txtEditStopwatchTime
        '
        Me.txtEditStopwatchTime.Location = New System.Drawing.Point(367, 327)
        Me.txtEditStopwatchTime.Name = "txtEditStopwatchTime"
        Me.txtEditStopwatchTime.Size = New System.Drawing.Size(190, 22)
        Me.txtEditStopwatchTime.TabIndex = 12
        '
        'FormEditSubmission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtEditStopwatchTime)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEditGithubLink)
        Me.Controls.Add(Me.txtEditPhone)
        Me.Controls.Add(Me.txtEditEmail)
        Me.Controls.Add(Me.txtEditName)
        Me.Controls.Add(Me.btnSubmitEdit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormEditSubmission"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSubmitEdit As Button
    Friend WithEvents txtEditName As TextBox
    Friend WithEvents txtEditEmail As TextBox
    Friend WithEvents txtEditPhone As TextBox
    Friend WithEvents txtEditGithubLink As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEditStopwatchTime As TextBox
End Class
