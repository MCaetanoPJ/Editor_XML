/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 22/07/2020
 * Time: 13:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Edita_Arquivo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private static FileSystemWatcher monitorar;//Monitorar a pasta selecionada
		private string Diretorio_Arquivo_XML;//Possui o endereço do arquivo selecionado
		const string Diretorio_Arquivo_Config = "XML_Config.txt";
		const string filtrar_extensao = "*.xml";
		private bool is_monitorar_pasta;
		const bool is_monitorar_subdiretorio_pasta = false;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Ler_Diretorio_Arquivo_TXT();
			Ler_Arquivos_XML_no_Diretorio_Selecionado();//Altera todos os arquivos XML na pasta quando iniciar
			MonitorarArquivos();//Altera apenas os novos arquivos ou arquivos editados
			lbl_quantidade_arquivos.Text = "Sistema Iniciado em "+DateTime.Now;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private void MonitorarArquivos()
        {
			try{
				if(File.Exists(Diretorio_Arquivo_Config)){//Verifica se o arquivo com o endereço existe
					is_monitorar_pasta = true;//Ativar monitoramento da pasta
		            monitorar = new FileSystemWatcher(Diretorio_Arquivo_XML, filtrar_extensao)
		            {
		                IncludeSubdirectories = is_monitorar_subdiretorio_pasta// vai monitorar os subdiretorios da pasta selecionada
		            };
		            monitorar.Created += OnFileChanged;//Monitora novos arquivos criados dentro da pasta
		            monitorar.EnableRaisingEvents = is_monitorar_pasta;//Vai monitorar a pasta selecionada
				}
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao Monitorar a pasta informada \n\nMotivo: "+ex.Message);
			}
        }
		private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
			MessageBox.Show("Detectado Alteração...");
			Altera_Arquivo_XML(e.FullPath);//Envia para o método o endereço do arquivo que foi alterado
        }
		
		private void Salvar_Diretorio_Arquivo_TXT(){
			try{
				StreamWriter c = new StreamWriter(Diretorio_Arquivo_Config);
				c.WriteLine(Diretorio_Arquivo_XML);
				c.Close();
				c.Dispose();
				MessageBox.Show("O novo diretório XML foi salvo com sucesso!");
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao salvar o diretório \n Motivo: "+ex.Message);
			}
		}
		private void Ler_Diretorio_Arquivo_TXT(){
			try{
				if(File.Exists(Diretorio_Arquivo_Config)){//Verifica se o arquivo com o endereço existe
					StreamReader c = new StreamReader(Diretorio_Arquivo_Config);
						Diretorio_Arquivo_XML = c.ReadLine();
						txt_EnderecoArquivo.Text = Diretorio_Arquivo_XML;
						c.Close();
						c.Dispose();
				}
				else{
					MessageBox.Show("Nenhuma Pasta contendo arquivos XML foi selecionada!");
				}
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao ler o arquivo com o endereço da pasta com o XML \n Motivo: "+ex.Message);
			}
		}
		private void Ler_Arquivos_XML_no_Diretorio_Selecionado(){
			try{
				if(Diretorio_Arquivo_XML != null){
					string[] arquivos_XML_no_Diretorio = Directory.GetFiles(Diretorio_Arquivo_XML, "*.XML", SearchOption.TopDirectoryOnly);//Ler apenas os arquivo XML no diretorio Selecionado
		        	foreach (string arq in arquivos_XML_no_Diretorio)//Percorre o vetor com o endereço dos arquivos XML
		        	{
		        		Altera_Arquivo_XML(arq);
		        	}
		        	
				}
				else{
					MessageBox.Show("Nenhuma Pasta contendo os arquivos XML foi selecionada!");
				}
			}
			catch(Exception ex){
				MessageBox.Show("Aviso: Houve um erro ao Ler os arquivos dentro do diretório selecionado \n Info: "+ex.Message);
			}
		}
		private void Altera_Arquivo_XML(string endereco_arquivo_XML){
			try{
				XmlDocument Arquivo_XML = new XmlDocument();
	            Arquivo_XML.Load(endereco_arquivo_XML);
	            XmlNodeList Elemento_XML = Arquivo_XML.SelectNodes("//entidade/pacientes/paciente");//Endereco do atributo a ser selecionado
	            foreach(XmlNode endereco_Elemento_XML in Elemento_XML)//Percorre dentro do arquivo XML
	            {
	                string codigolis_antigo = endereco_Elemento_XML.Attributes["codigo_lis"].Value;//Lê o valor atual do codigo_lis
	                string codigolis_novo = codigolis_antigo.TrimEnd();//remove o espaço no final do valor do codigo_lis
	                endereco_Elemento_XML.Attributes["codigo_lis"].Value = codigolis_novo;//Insere o novo valor no codigo_lis
	            }
	            Arquivo_XML.Save(endereco_arquivo_XML);//endereco para atualizar o arquivo XML
			}
			catch(Exception ex){
				MessageBox.Show("Aviso: Houve um erro atualizar o seguinte arquivo XML: "+endereco_arquivo_XML+"\n Solução: Retire o arquivo XML da pasta e o coloque novamente  \n Info: "+ex.Message);
			}
		}
		
		private void Btn_SelecionarDiretorioClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd1 = new OpenFileDialog();
            //define as propriedades do controle 
			ofd1.FileName = "Selecione a pasta com os XML";
            DialogResult dr = ofd1.ShowDialog();
            if (dr == DialogResult.OK)
            {
            	Diretorio_Arquivo_XML = Path.GetDirectoryName(ofd1.FileName);
                txt_EnderecoArquivo.Text = Diretorio_Arquivo_XML;
                Salvar_Diretorio_Arquivo_TXT();
                Ler_Arquivos_XML_no_Diretorio_Selecionado();
                MonitorarArquivos();
            }
		}
		private void Btn_Atualizar_XMLClick(object sender, EventArgs e)
		{
			Ler_Arquivos_XML_no_Diretorio_Selecionado();
		}
		private void Btn_SalvarDiretorioClick(object sender, EventArgs e)
		{
			Salvar_Diretorio_Arquivo_TXT();
		}
		private void Timer_AtualizaXMLTick(object sender, EventArgs e)
		{
			//Funções que será executada pelo timer			
		}
		
		
	}
}
