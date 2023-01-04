namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.Generate_button = new System.Windows.Forms.Button();
            this.ABC_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chrom_num = new System.Windows.Forms.TextBox();
            this.iteration_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Graph_size = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bee_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ranger_box = new System.Windows.Forms.TextBox();
            this.hrom_histori = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.MDS;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(9, 10);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(448, 372);
            this.gViewer1.TabIndex = 0;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = false;
            this.gViewer1.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer1.Transform")));
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // Generate_button
            // 
            this.Generate_button.Location = new System.Drawing.Point(476, 343);
            this.Generate_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Generate_button.Name = "Generate_button";
            this.Generate_button.Size = new System.Drawing.Size(168, 41);
            this.Generate_button.TabIndex = 1;
            this.Generate_button.Text = "Згенерувати граф";
            this.Generate_button.UseVisualStyleBackColor = true;
            this.Generate_button.Click += new System.EventHandler(this.Generate_button_Click);
            // 
            // ABC_button
            // 
            this.ABC_button.Location = new System.Drawing.Point(476, 275);
            this.ABC_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ABC_button.Name = "ABC_button";
            this.ABC_button.Size = new System.Drawing.Size(168, 41);
            this.ABC_button.TabIndex = 2;
            this.ABC_button.Text = "Розмалювати граф алгоритмом ABC";
            this.ABC_button.UseVisualStyleBackColor = true;
            this.ABC_button.Click += new System.EventHandler(this.ABC_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(487, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Хроматичне число";
            // 
            // chrom_num
            // 
            this.chrom_num.Location = new System.Drawing.Point(476, 41);
            this.chrom_num.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chrom_num.Name = "chrom_num";
            this.chrom_num.ReadOnly = true;
            this.chrom_num.Size = new System.Drawing.Size(169, 20);
            this.chrom_num.TabIndex = 4;
            // 
            // iteration_box
            // 
            this.iteration_box.Location = new System.Drawing.Point(586, 206);
            this.iteration_box.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iteration_box.Name = "iteration_box";
            this.iteration_box.Size = new System.Drawing.Size(59, 20);
            this.iteration_box.TabIndex = 5;
            this.iteration_box.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кількість ітерацій";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 323);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Розмір графа";
            // 
            // Graph_size
            // 
            this.Graph_size.Location = new System.Drawing.Point(568, 320);
            this.Graph_size.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Graph_size.Name = "Graph_size";
            this.Graph_size.Size = new System.Drawing.Size(77, 20);
            this.Graph_size.TabIndex = 9;
            this.Graph_size.Text = "250";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Кількіть бджіл";
            // 
            // bee_box
            // 
            this.bee_box.Location = new System.Drawing.Point(586, 229);
            this.bee_box.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bee_box.Name = "bee_box";
            this.bee_box.Size = new System.Drawing.Size(59, 20);
            this.bee_box.TabIndex = 11;
            this.bee_box.Text = "35";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 254);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Кількість розвідників";
            // 
            // ranger_box
            // 
            this.ranger_box.Location = new System.Drawing.Point(586, 252);
            this.ranger_box.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ranger_box.Name = "ranger_box";
            this.ranger_box.Size = new System.Drawing.Size(59, 20);
            this.ranger_box.TabIndex = 13;
            this.ranger_box.Text = "3";
            // 
            // hrom_histori
            // 
            this.hrom_histori.Location = new System.Drawing.Point(476, 71);
            this.hrom_histori.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hrom_histori.Multiline = true;
            this.hrom_histori.Name = "hrom_histori";
            this.hrom_histori.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hrom_histori.Size = new System.Drawing.Size(169, 121);
            this.hrom_histori.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 393);
            this.Controls.Add(this.hrom_histori);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ranger_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bee_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Graph_size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iteration_box);
            this.Controls.Add(this.chrom_num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ABC_button);
            this.Controls.Add(this.Generate_button);
            this.Controls.Add(this.gViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Розмальовка графа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.Button Generate_button;
        private System.Windows.Forms.Button ABC_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chrom_num;
        private System.Windows.Forms.TextBox iteration_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Graph_size;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bee_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ranger_box;
        private System.Windows.Forms.TextBox hrom_histori;
    }
}

