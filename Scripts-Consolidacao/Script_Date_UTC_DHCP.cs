//Bibliotecas utilizadas para a conceção desta aplicação
using System; //Utilizada como base do projeto (e.g. definir e manipular eventos, interfaces, atributos, exceções)
using System.Collections.Generic; //Utilizada para definir coleções genéricas
using System.ComponentModel; //Utilizada para implementar o comportamento de tempo de execução e tempo de design de componentes e controlos
using System.Data; //Utilizada para gerir dados provenientes de múltiplas fontes
using System.Drawing; //Utilizada para ter acesso a funcionalidades básicas gráficas GDI+
using System.IO; //Utilizada para a escrita e leitura de ficheiros
using System.Linq; //Utilizada para suportar queries que usam LINQ
using System.Text; //Utilizada para ações relacionadas com ficheiros de texto
using System.Threading; //Utilizada para criar e controlar Threads
using System.Threading.Tasks; //Utilizada para escrever código simultâneo e assíncrono
using System.Windows.Forms; //Utilizada para criar interface gráfica

namespace Script_Date_UTC_DHCP
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
        }
		
		//Criação de um menu da aplicação
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta aplicação é utilizada para eliminar os espaços a mais nos logs DHCP cujo dia é inferior a 10!!!");
        }
		
		//Codificação do Botão que efetua a consolidação e transformação dos eventos do ficheiro
        private void buttonLimpar_Click(object sender, EventArgs e)
        {
			//Variável que irá guardar o caminho para o ficheiro que armazena o resultado do processamento
            string savefilename = "";
			//Variável com o valor máximo da progress bar (que equivale ao número de evento a serem processados)
            int count_max_prog_bar = 0;

			//Verificar se foi preenchido o caminho para um ficheiro
            if (string.IsNullOrEmpty(textBoxPathFicheiro.Text))
            {
				//Apresentar uma mensagem caso não tenha sido preenchido o caminho para um ficheiro
                MessageBox.Show("Path não foi preenchida!!!\nPreencha primeiro a path!!");
            }
			//Caso tenha sido preenchido o caminho para o ficheiro
            else
            {
				//Verificar se o ficheiro existe
                if (File.Exists(textBoxPathFicheiro.Text))
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
                    buttonLimpar.Visible = false;
					//Fazer aparecer a progress bar
                    progressBarClean.Visible = true;

					//Ler todos os eventos do ficheiro e guardá-los numa variável do tipo var
                    var linesxpto = File.ReadAllLines(@textBoxPathFicheiro.Text);

					//Por cada evento encontrado que possua uma data, soma +1 ao valor máximo da progress bar
                    foreach (var line_count in linesxpto)
                    {
                        if (line_count.Contains("Jan") || line_count.Contains("Fev") || line_count.Contains("Mar") || line_count.Contains("Apr") || line_count.Contains("May") || line_count.Contains("Jun") || line_count.Contains("Jul") || line_count.Contains("Aug") || line_count.Contains("Sep") || line_count.Contains("Oct") || line_count.Contains("Nov") || line_count.Contains("Dec"))
                        {
                            count_max_prog_bar++;
                        }
                    }
                    progressBarClean.Maximum = count_max_prog_bar;
					
					//Substituir dois espaços por apenas um
                    StringBuilder newFile = new StringBuilder();
                    string temp = "";
                    string[] file = File.ReadAllLines(@textBoxPathFicheiro.Text);

                    foreach (string line in file)
                    {
                        if (line.Contains("  "))
                        {
                            temp = line.Replace("  ", " ");
                            newFile.Append(temp + "\r\n");
                            continue;
                        }
                        newFile.Append(line + "\r\n");
                    }
					//Tentar atualizar progress bar
                    try
                    {

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
						
						//Escrever em ficheiro as novas alterações desejadas
                        File.WriteAllText(savefilename, newFile.ToString());
						//Mostrar uma mensagem quando a consolidação do ficheiro estiver concluída
                        MessageBox.Show("A consolidação e transformação do ficheiro está concluída!!!");
						//Habilitar novamente os controlos sobre a aplicação
                        this.ControlBox = true;
						//O botão de consolidação é colocado vísivel
                        buttonLimpar.Visible = true;
						//A progress bar é escondida
                        progressBarClean.Visible = false;
						//Fazer reset do valor da progress bar para que esta comece em zero sempre que a aplicação é executada
                        progressBarClean.Value = 0;
                    }
					//Caso não consiga atualizar a progress bar lança uma exceção para que o utilizador possa perceber qual o problema
                    catch (System.IO.IOException ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }
				//Caso o ficheiro não exista é lançada uma mensagem a avisar o utilizador que o ficheiro selecionado não é válido
                else
                {
                    MessageBox.Show("O ficheiro introduzido não é válido!!!\nTente novamente!!!");
                }
            }
        }

		//Função Click do botão para abrir um ficheiro para processar
        private void textBoxPathFicheiro_Click(object sender, EventArgs e)
        {
            //Adicionar qual ficheiro a abrir
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Text File (.txt) | *.txt";
            openFileDialog1.FilterIndex = 1;

			//Validar o ficheiro escolhido, carregando no botão OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPathFicheiro.Text = openFileDialog1.FileName;
            }
        }
    }
}
