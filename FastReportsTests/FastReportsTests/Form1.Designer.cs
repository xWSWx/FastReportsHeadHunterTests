namespace FastReportsTests
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DrawingPanelWSW = new WinFormComponents.DrawingPanel();
            listBox1 = new ListBox();
            FillLabel = new Label();
            StrokeLable = new Label();
            SuspendLayout();
            // 
            // DrawingPanelWSW
            // 
            DrawingPanelWSW.BorderStyle = BorderStyle.FixedSingle;
            DrawingPanelWSW.Location = new Point(12, 12);
            DrawingPanelWSW.Name = "DrawingPanelWSW";
            DrawingPanelWSW.Size = new Size(507, 373);
            DrawingPanelWSW.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "TODO: Заменить на иконку \"Мышь\"", "TODO: Заменить на иконку \"скрепки или... соединятора???\"", "TODO: Заменить на иконку \"Круг\"", "TODO: Заменить на иконку \"Треугольник\"", "TODO: Заменить на иконку \"Прямоугольник\"" });
            listBox1.Location = new Point(525, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(363, 94);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            FillLabel.AutoSize = true;
            FillLabel.Location = new Point(534, 117);
            FillLabel.Name = "label1";
            FillLabel.Size = new Size(223, 15);
            FillLabel.TabIndex = 2;
            FillLabel.Text = "TODO: Сделать палитру. Это Заливочка";
            // 
            // label2
            // 
            StrokeLable.AutoSize = true;
            StrokeLable.Location = new Point(534, 158);
            StrokeLable.Name = "label2";
            StrokeLable.Size = new Size(225, 15);
            StrokeLable.TabIndex = 3;
            StrokeLable.Text = "TODO: Сделать палитру. Это Обводочка";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 397);
            Controls.Add(StrokeLable);
            Controls.Add(FillLabel);
            Controls.Add(listBox1);
            Controls.Add(DrawingPanelWSW);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WinFormComponents.DrawingPanel DrawingPanelWSW;
        private ListBox listBox1;
        private Label FillLabel;
        private Label StrokeLable;
    }
}
