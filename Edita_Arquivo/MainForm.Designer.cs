/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 22/07/2020
 * Time: 13:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Edita_Arquivo
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btn_SelecionarDiretorio;
		private System.Windows.Forms.TextBox txt_EnderecoArquivo;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btn_Atualizar_XML;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl_quantidade_arquivos;
		private System.Windows.Forms.Timer timer_AtualizaXML;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btn_SelecionarDiretorio = new System.Windows.Forms.Button();
			this.txt_EnderecoArquivo = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btn_Atualizar_XML = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_quantidade_arquivos = new System.Windows.Forms.Label();
			this.timer_AtualizaXML = new System.Windows.Forms.Timer(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_SelecionarDiretorio
			// 
			this.btn_SelecionarDiretorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_SelecionarDiretorio.Location = new System.Drawing.Point(429, 6);
			this.btn_SelecionarDiretorio.Name = "btn_SelecionarDiretorio";
			this.btn_SelecionarDiretorio.Size = new System.Drawing.Size(173, 22);
			this.btn_SelecionarDiretorio.TabIndex = 0;
			this.btn_SelecionarDiretorio.Text = "Selecione a Pasta com XML";
			this.btn_SelecionarDiretorio.UseVisualStyleBackColor = true;
			this.btn_SelecionarDiretorio.Click += new System.EventHandler(this.Btn_SelecionarDiretorioClick);
			// 
			// txt_EnderecoArquivo
			// 
			this.txt_EnderecoArquivo.Location = new System.Drawing.Point(110, 6);
			this.txt_EnderecoArquivo.Name = "txt_EnderecoArquivo";
			this.txt_EnderecoArquivo.ReadOnly = true;
			this.txt_EnderecoArquivo.Size = new System.Drawing.Size(318, 20);
			this.txt_EnderecoArquivo.TabIndex = 1;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.CheckFileExists = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.ShowReadOnly = true;
			this.openFileDialog1.ValidateNames = false;
			// 
			// btn_Atualizar_XML
			// 
			this.btn_Atualizar_XML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Atualizar_XML.Location = new System.Drawing.Point(12, 55);
			this.btn_Atualizar_XML.Name = "btn_Atualizar_XML";
			this.btn_Atualizar_XML.Size = new System.Drawing.Size(244, 51);
			this.btn_Atualizar_XML.TabIndex = 3;
			this.btn_Atualizar_XML.Text = "Atualizar TODOS os Arquivos XML no Diretorio - FORMA MANUAL";
			this.btn_Atualizar_XML.UseVisualStyleBackColor = true;
			this.btn_Atualizar_XML.Click += new System.EventHandler(this.Btn_Atualizar_XMLClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Pasta com XML";
			// 
			// lbl_quantidade_arquivos
			// 
			this.lbl_quantidade_arquivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_quantidade_arquivos.Location = new System.Drawing.Point(3, 122);
			this.lbl_quantidade_arquivos.Name = "lbl_quantidade_arquivos";
			this.lbl_quantidade_arquivos.Size = new System.Drawing.Size(599, 25);
			this.lbl_quantidade_arquivos.TabIndex = 5;
			// 
			// timer_AtualizaXML
			// 
			this.timer_AtualizaXML.Enabled = true;
			this.timer_AtualizaXML.Interval = 10000;
			this.timer_AtualizaXML.Tick += new System.EventHandler(this.Timer_AtualizaXMLTick);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(262, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(329, 51);
			this.label2.TabIndex = 6;
			this.label2.Text = "AVISO: Este programa atualiza o arquivo (.XML) que for criado ou movido para a pa" +
	"sta selecionada enquanto estiver aberto";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 156);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbl_quantidade_arquivos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_Atualizar_XML);
			this.Controls.Add(this.txt_EnderecoArquivo);
			this.Controls.Add(this.btn_SelecionarDiretorio);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edita_Arquivo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
