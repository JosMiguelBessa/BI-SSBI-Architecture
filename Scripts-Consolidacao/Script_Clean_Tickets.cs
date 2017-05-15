//Bibliotecas utilizadas para a conceção desta aplicação
using System; //Utilizada como base do projeto (e.g. definir e manipular eventos, interfaces, atributos, exceções)
using System.Collections.Generic; //Utilizada para definir coleções genéricas
using System.ComponentModel; //Utilizada para implementar o comportamento de tempo de execução e tempo de design de componentes e controlos
using System.Data; //Utilizada para gerir dados provenientes de múltiplas fontes
using System.Drawing; //Utilizada para ter acesso a funcionalidades básicas gráficas GDI+
using System.IO; //Utilizada para a escrita e leitura de ficheiros
using System.Linq; //Utilizada para suportar queries que usam LINQ
using System.Text; //Utilizada para ações relacionadas com ficheiros de texto
using System.Threading.Tasks; //Utilizada para escrever código simultâneo e assíncrono
using System.Windows.Forms; //Utilizada para criar interface gráfica

namespace Remove_Comma_Tickets_TXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
	    //Método instanciado por defeito utilizado para inicializar a interface gráfica da aplicação
            InitializeComponent();
	    //Esconder progress bar quando arranca o programa
            progressBarClean.Visible = false;
	    //Valor mínimo da progress bar
            progressBarClean.Minimum = 0;
	    //Valor adicionado à progress bar em cada iteração
            progressBarClean.Step = 1;
	    //Esconder label das etapas quando arranca o programa
	    label_step.Visible = false;
        }
	//Codificação do Botão que efetua a consolidação e transformação dos eventos do ficheiro
        private void Button_Limpar_Click(object sender, EventArgs e)
        {
	    //Variável que irá guardar o caminho para o ficheiro que armazena o resultado do processamento
            string savefilename = "";
	    //Variável com o valor máximo da progress bar (que equivale ao número de evento a serem processados)
            int count_max_prog_bar = 0;

	    //Verificar se foi preenchido o caminho para um ficheiro
            if (string.IsNullOrEmpty(textBox_Ficheiro.Text))
            {
		//Apresentar uma mensagem caso não tenha sido preenchido o caminho para um ficheiro
                MessageBox.Show("Path não foi preenchida!!!\nPreencha primeiro a path!!");
            }
	    //Caso tenha sido preenchido o caminho para o ficheiro
            else
            {
		//Verificar se o ficheiro existe
                if (File.Exists(textBox_Ficheiro.Text))
                {
                    //Adicionar onde guardar ficheiro
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
                    saveFileDialog1.Filter = "Text File (.txt) | *.txt";
                    saveFileDialog1.FilterIndex = 1;
		    //Verificar se é carregado no botão OK. Se sim, guarda o ficheiro na localização escolhida
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        savefilename = saveFileDialog1.FileName;
                    }
		    //Desabilitar o acesso a controlos sobre a aplicação
                    this.ControlBox = false;
		    //Esconder o botão de consolidação
                    Button_Limpar.Visible = false;
		    //Fazer aparecer a progress bar
                    progressBarClean.Visible = true;
		    //Tornar visível a label com a atualização do número da etapa em curso
		    label_step.Visible = true;
		    //Atualizar a label com os novos valores das suas propriedades
                    label_step.Refresh();
		    //Ler todos os eventos do ficheiro e guardá-los numa variável do tipo var
                    var linesxpto = File.ReadAllLines(@textBox_Ficheiro.Text);
		    //Por cada evento encontrado que possua virgula soma +1 ao valor máximo da progress bar
                    foreach (var line_count in linesxpto)
                    {
                        if (line_count.Contains('"'))
                        {
                            count_max_prog_bar++;
                        }
                    }
		    //Definir o valor máximo da progress bar
                    progressBarClean.Maximum = count_max_prog_bar;

                    //Remover as aspas de um ficheiro
                    StringBuilder newFile2 = new StringBuilder();
                    string temp2 = "";
                    string[] file2 = File.ReadAllLines(@textBox_Ficheiro.Text);
                
                    foreach (string line2 in file2)
                    {
                        if (line2.Contains('"'))
                        {
                            temp2 = line2.Replace("\"", "");
                            newFile2.Append(temp2 + "\r\n");
                            //atualizar progress bar
                            progressBarClean.Increment(1);
                            int percent = (int)(((double)(progressBarClean.Value - progressBarClean.Minimum) /
                                    (double)(progressBarClean.Maximum - progressBarClean.Minimum)) * 100);
                            //Atualizar de forma gráfica o preenchimento da progress bar
			    using (Graphics gr = progressBarClean.CreateGraphics())
                            {
                                gr.DrawString(percent.ToString() + "%",
                                    SystemFonts.DefaultFont,
                                    Brushes.Black,
                                    new PointF(progressBarClean.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Width / 2.0F),
                                    progressBarClean.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Height / 2.0F)));
                            }

                            continue;
                        }
		        //Acrescentar novo log
                        newFile2.Append(line2 + "\r\n");
                    }
		    //Escrever em ficheiro as novas alterações
                    File.WriteAllText(savefilename, newFile2.ToString());
		    //Fazer reset aos valores da progress bar, mantendo o seu valor máximo anteriormente definido
                    progressBarClean.Value = 0;
                    progressBarClean.Maximum = 0;
                    progressBarClean.Maximum = count_max_prog_bar;

                    //Substituir as vírgulas de um ficheiro por \t
                    label_step.Text = "Step: 2/2";
                    label_step.Refresh();
                    StringBuilder newFile = new StringBuilder();
                    string temp = "";
                    string[] file = File.ReadAllLines(savefilename);

                    foreach (string line in file)
                    {
                        if (line.Contains(','))
                        {
                            temp = line.Replace(",", "\t");
                            newFile.Append(temp + "\r\n");
                            //atualizar progress bar
                            progressBarClean.Increment(1);
                            int percent = (int)(((double)(progressBarClean.Value - progressBarClean.Minimum) /
                                    (double)(progressBarClean.Maximum - progressBarClean.Minimum)) * 100);
                            //Atualizar de forma gráfica o preenchimento da progress bar                            
			    using (Graphics gr = progressBarClean.CreateGraphics())
                            {
                                gr.DrawString(percent.ToString() + "%",
                                    SystemFonts.DefaultFont,
                                    Brushes.Black,
                                    new PointF(progressBarClean.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Width / 2.0F),
                                    progressBarClean.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Height / 2.0F)));
                            }
                            continue; 
                        }
                        newFile.Append(line + "\r\n");
                    }
					//Escrever em ficheiros as novas alterações
					File.WriteAllText(savefilename, newFile.ToString());
					//Mostrar uma mensagem quando a consolidação do ficheiro estiver concluída					
					MessageBox.Show("A limpeza do ficheiro está concluída!!!");
					//Esconder label que dá a indicação da etapa em curso
					label_step.Visible = false;						
					//Habilitar novamente os controlos sobre a aplicação
					this.ControlBox = true;
					//O botão de consolidação é colocado vísivel
					Button_Limpar.Visible = true;
					//A progress bar é escondida
					progressBarClean.Visible = false;
					//Fazer reset do valor da progress bar para que esta comece em zero sempre que a aplicação é executada
					progressBarClean.Value = 0;
                }
	        //Caso o ficheiro não exista é lançada uma mensagem a avisar o utilizador que o ficheiro selecionado não é válido				
                else
                {
                    MessageBox.Show("O ficheiro introduzido não é válido!!!\nTente novamente!!!");
                }
            }
        }
        //Função Click do botão para abrir um ficheiro para processar
        private void textBox_Ficheiro_Click(object sender, EventArgs e)
        {
            //Adicionar qual ficheiro a abrir
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Text File (.txt) | *.txt";
            openFileDialog1.FilterIndex = 1;
	    //Validar o ficheiro escolhido, carregando no botão OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_Ficheiro.Text = openFileDialog1.FileName;
            }
        }
    }
}
