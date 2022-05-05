
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listSeeds = new System.Windows.Forms.ListView();
            this.nextDamageRoll = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.nextMissRnd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listSeeds
            // 
            this.listSeeds.HideSelection = false;
            this.listSeeds.Location = new System.Drawing.Point(9, 9);
            this.listSeeds.Margin = new System.Windows.Forms.Padding(0);
            this.listSeeds.Name = "listSeeds";
            this.listSeeds.Size = new System.Drawing.Size(200, 210);
            this.listSeeds.TabIndex = 1;
            this.listSeeds.UseCompatibleStateImageBehavior = false;
            this.listSeeds.View = System.Windows.Forms.View.List;
            // 
            // nextDamageRoll
            // 
            this.nextDamageRoll.AutoSize = true;
            this.nextDamageRoll.Location = new System.Drawing.Point(212, 9);
            this.nextDamageRoll.Name = "nextDamageRoll";
            this.nextDamageRoll.Size = new System.Drawing.Size(35, 13);
            this.nextDamageRoll.TabIndex = 2;
            this.nextDamageRoll.Text = "label1";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(133, 195);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // nextMissRnd
            // 
            this.nextMissRnd.AutoSize = true;
            this.nextMissRnd.Location = new System.Drawing.Point(212, 22);
            this.nextMissRnd.Name = "nextMissRnd";
            this.nextMissRnd.Size = new System.Drawing.Size(35, 13);
            this.nextMissRnd.TabIndex = 4;
            this.nextMissRnd.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 231);
            this.Controls.Add(this.nextMissRnd);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.nextDamageRoll);
            this.Controls.Add(this.listSeeds);
            this.Name = "Form1";
            this.Text = "EvolandRNG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listSeeds;
        private System.Windows.Forms.Label nextDamageRoll;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label nextMissRnd;
    }
}

