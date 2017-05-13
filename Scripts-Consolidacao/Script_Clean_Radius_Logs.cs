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

namespace Script_Clean_Radius_Logs
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
			//Esconder label relativo a etapa 1
            label_step_1.Visible = false;
        }
        private void buttonCleanLogs_Click(object sender, EventArgs e)
        {
            //Cada string é um dos campos da estrutura fixa dos logs Radius que será criada
            string data = "";
            string acctSessionId = "";
            string calledStationID = "";
            string callingStationID = "";
            string colubrisAVPairSsid = "";
            string ciscoAVPairSsid = "";
            string ciscoAVPairVlanid = "";
            string ciscoAVPairNasLocation = "";
            string username = "";
            string ciscoAVPairConnectProgress = "";
            string acctStatusType = "";
            string nasIPAddress = "";
            string nasPortType = "";
            string nasPortID = "";
            string nasPort = "";
            string wisprLocationName = "";
            string serviceType = "";
            string acctDelayTime = "";
            string acctUniqueSessionId = "";
            string acctInputOctets = "";
            string acctOutputOctets = "";
            string acctInputPackets = "";
            string acctOutputPackets = "";
            string acctTerminateCause = "";
            string ciscoAVPairDiscCauseExt = "";
            string strippedUsername = "";
            string realm = "";
            string operatorName = "";
            string eduroamSPCountry = "";
            string proxyState = "";
            string ciscoAVPairAuthAlgoType = "";
            string acctSessionTime = "";
            string acctAuthentic = "";
            string ciscoNasPort = "";
            string attr_103 = "";
            string accessPointID = "";
            string accessPointName = "";
            string connectInfo = "";
            string framedIPAddress = "";
            string nasIdentifier = "";
            string timestamp = "";
            string eventTimestamp = "";
            string airespaceWlanId = "";
            string tunnelType = "";
            string tunnelMediumType = "";
            string tunnelPrivateGroup = "";
            string acctInputGigawords = "";
            string acctOutputGigawords = "";
            string ciscoAVPairAuditSessionId = "";
            string framedIPV6Prefix = "";
            string acctMultiSessionId = "";
            string huaweiConnectId = ""; 
            string huaweiInputBurstSize = "";
            string huaweiInputAverageRate = ""; 
            string huaweiOutputBurstSize = ""; 
            string huaweiOutputAverageRate = ""; 
            string huaweiPriority = "";
            string freeRadiusAcctSessionStartTime = "";
            string arubaEssidName = "";
            string arubaLocationId = "";
            string arubaAPGroup = "";
            string arubaUserVlan = "";
            string colubrisAVPairGroup = "";
            string colubrisAVPairIncomingVlanId = "";
            //String que conterá todos os campos anteriores
            string allCamps = "";
            //Cleaning de dados. Cada log é colocado numa única string e é escrita num novo ficheiro.
            bool encontrou = false;
            string temp = "";
            string temp2 = "";
            string cleanData = "";
            int a1 = 0;
            int a2 = 0;
            int a3 = 0;
            int a4 = 0;
            int a5 = 0;
            int a6 = 0;
            int a7 = 0;
            int a8 = 0;
            int a9 = 0;
            int a10 = 0;
            int a11 = 0;
            int a12 = 0;
            int a13 = 0;
            int a14 = 0;
            int a15 = 0;
            int a16 = 0;
            int a17 = 0;
            int a18 = 0;
            int a19 = 0;
            int a20 = 0;
            int a21 = 0;
            int a22 = 0;
            int a23 = 0;
            int a24 = 0;
            int a25 = 0;
            int a26 = 0;
            int a27 = 0;
            int a28 = 0;
            int a29 = 0;
            int a30 = 0;
            int a31 = 0;
            int a32 = 0;
            int a33 = 0;
            int a34 = 0;
            int a35 = 0;
            int a36 = 0;
            int a37 = 0;
            int a38 = 0;
            int a39 = 0;
            int a40 = 0;
            int a41 = 0;
            int a42 = 0;
            int a43 = 0;
            int a44 = 0;
            int a45 = 0;
            int a46 = 0;
            int a47 = 0;
            int a48 = 0;
            int a49 = 0;
            int a50 = 0;
            int a51 = 0;
            int a52 = 0;
            int a53 = 0;
            int a54 = 0;
            int a55 = 0;
            int a56 = 0;
            int a57 = 0;
            int a58 = 0;
            int a59 = 0;
            int a60 = 0;
            int a61 = 0;
            int a62 = 0;
            int a63 = 0;
            int a64 = 0;
            string savefilename="";
            //path para o desktop do utilizador em que é executado o script
            string path_temp_file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path_temp_file = path_temp_file + "\\temp.txt";

            //contador para a barra de progresso que indica em que percentagem está a limpeza
            int count_max_prog_bar = 0;
  
			//Verificar se foi preenchido o caminho para um ficheiro
            if (string.IsNullOrEmpty(textBoxPathFile.Text))
            {
				//Apresentar uma mensagem caso não tenha sido preenchido o caminho para um ficheiro
                MessageBox.Show("Path não foi preenchida!!!\nPreencha primeiro a path!!");
            }
			//Caso tenha sido preenchido o caminho para o ficheiro
            else
            {
				//Verificar se o ficheiro existe
                if (File.Exists(textBoxPathFile.Text))
                {
                    //Adicionar onde guardar ficheiro
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
                    saveFileDialog1.Filter = "Text File (.txt) | *.txt";
                    saveFileDialog1.FilterIndex = 1;
					
					//Definir localização de onde será guardado o ficheiro com os eventos consolidados e transformados
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        savefilename = saveFileDialog1.FileName;
                    }

                    this.ControlBox = false;
                    buttonCleanLogs.Visible = false;
                    progressBarClean.Visible = true;
                    label_step_1.Visible = true;
                    label_step_1.Refresh();
                    var linesxpto = File.ReadAllLines(@textBoxPathFile.Text);

                    foreach(var line_count in linesxpto)
                    {
                        if(line_count == "")
                        {
                            count_max_prog_bar++;
                        }
                    }

                    progressBarClean.Maximum = count_max_prog_bar;
                    //Step 1 - Colocar todos os campos de cada log em apenas uma linha
                    foreach (var line in linesxpto)
                    {
                        cleanData = "";
                        temp = "";
                        temp2 = "";
                        encontrou = false;

						//Definir valores por defeito das variáveis (campos dos eventos)
                        if (line == "")
                        {
                            if (data == "")
                            {
                                data = "Mon Jan  1 00:00:00 1900";
                            }
                            if (acctSessionId == "")
                            {
                                acctSessionId = " Acct-Session-Id = " + @"""03030303""";
                            }
                            if (calledStationID == "")
                            {
                                calledStationID = " Called-Station-Id = " + @"""0000.0000.0000""";
                            }
                            if (callingStationID == "")
                            {
                                callingStationID = " Calling-Station-Id = " + @"""0000.0000.0000""";
                            }
                            if (colubrisAVPairSsid == "")
                            {
                                colubrisAVPairSsid = " Colubris-AVPair = " + @"""ssid=ssid""";
                            }
                            if (ciscoAVPairSsid == "")
                            {
                                ciscoAVPairSsid = " Cisco-AVPair = " + @"""ssid=ssid""";
                            }
                            if (ciscoAVPairVlanid == "")
                            {
                                ciscoAVPairVlanid = " Cisco-AVPair = " + @"""vlan-id=0""";
                            }
                            if (ciscoAVPairNasLocation == "")
                            {
                                ciscoAVPairNasLocation = " Cisco-AVPair = " + @"""nas-location=Nas - location""";
                            }
                            if (username == "")
                            {
                                username = " User-Name = " + @"""username""";
                            }
                            if (ciscoAVPairConnectProgress == "")
                            {
                                ciscoAVPairConnectProgress = " Cisco-AVPair = " + @"""connect-progress=Connect Progress""";
                            }
                            if (acctStatusType == "")
                            {
                                acctStatusType = " Acct-Status-Type = AccType";
                            }
                            if (nasIPAddress == "")
                            {
                                nasIPAddress = " NAS-IP-Address = 0.0.0.0";
                            }
                            if (nasPortType == "")
                            {
                                nasPortType = " NAS-Port-Type = Nasporttype";
                            }
                            if (nasPortID == "")
                            {
                                nasPortID = " NAS-Port-Id = " + @"""0000""";
                            }
                            if (nasPort == "")
                            {
                                nasPort = " NAS-Port = 00000";
                            }
                            if (wisprLocationName == "")
                            {
                                wisprLocationName = " WISPr-Location-Name = " + @"""Wispr""";
                            }
                            if (serviceType == "")
                            {
                                serviceType = " Service-Type = Service-Type";
                            }
                            if (acctDelayTime == "")
                            {
                                acctDelayTime = " Acct-Delay-Time = 10000000000";
                            }
                            if (acctUniqueSessionId == "")
                            {
                                acctUniqueSessionId = " Acct-Unique-Session-Id = " + @"""acctuniquesessionid""";
                            }
                            if (acctInputOctets == "")
                            {
                                acctInputOctets = " Acct-Input-Octets = 000000000000";
                            }
                            if (acctOutputOctets == "")
                            {
                                acctOutputOctets = " Acct-Output-Octets = 000000000000";
                            }
                            if (acctInputPackets == "")
                            {
                                acctInputPackets = " Acct-Input-Packets = 000000000000";
                            }
                            if (acctOutputPackets == "")
                            {
                                acctOutputPackets = " Acct-Output-Packets = 000000000000";
                            }
                            if (acctTerminateCause == "")
                            {
                                acctTerminateCause = " Acct-Terminate-Cause = Terminate-Cause";
                            }
                            if (ciscoAVPairDiscCauseExt == "")
                            {
                                ciscoAVPairDiscCauseExt = " Cisco-AVPair = " + @"""disc-cause-ext=Disc cause""";
                            }
                            if (strippedUsername == "")
                            {
                                strippedUsername = " Stripped-User-Name = " + @"""stripped""";
                            }
                            if (realm == "")
                            {
                                realm = " Realm = " + @"""realm""";
                            }
                            if (operatorName == "")
                            {
                                operatorName = " Operator-Name = " + @"""operator""";
                            }
                            if (eduroamSPCountry == "")
                            {
                                eduroamSPCountry = " Eduroam-SP-Country = " + @"""eduroamSPCountry""";
                            }
                            if (proxyState == "")
                            {
                                proxyState = " Proxy-State = proxystatexxxx1234";
                            }
                            if (ciscoAVPairAuthAlgoType == "")
                            {
                                ciscoAVPairAuthAlgoType = " Cisco-AVPair = " + @"""auth-algo-type=Auth-algo""";
                            }
                            if (acctSessionTime == "")
                            {
                                acctSessionTime = " Acct-Session-Time = 00000";
                            }
                            if (acctAuthentic == "")
                            {
                                acctAuthentic = " Acct-Authentic = Authentic";
                            }
                            if (ciscoNasPort == "")
                            {
                                ciscoNasPort = " Cisco-NAS-Port = " + @"""00000""";
                            }
                            if (attr_103 == "")
                            {
                                attr_103 = " Attr-103 = attx103";
                            }
                            if (accessPointID == "")
                            {
                                accessPointID = " Access-Point-Id = 0000000";
                            }
                            if (accessPointName == "")
                            {
                                accessPointName = " Access-Point-Name = " + @"""accesspointname""";
                            }
                            if (connectInfo == "")
                            {
                                connectInfo = " Connect-Info = " + @"""connect-info""";
                            }
                            if (framedIPAddress == "")
                            {
                                framedIPAddress = " Framed-IP-Address = framedipaddress";
                            }
                            if (nasIdentifier == "")
                            {
                                nasIdentifier = " NAS-Identifier = " + @"""00-00-00-00-00""";
                            }
                            if (timestamp == "")
                            {
                                timestamp = " Timestamp = 000000000";
                            }
                            if (eventTimestamp == "")
                            {
                                eventTimestamp = " Event-Timestamp = 000000000";
                            }
                            if (airespaceWlanId == "")
                            {
                                airespaceWlanId = " Airespace-Wlan-Id = 000000000";
                            }
                            if (tunnelType == "")
                            {
                                tunnelType = " Tunnel-Type:0000 = xpto";
                            }
                            if (tunnelMediumType == "")
                            {
                                tunnelMediumType = " Tunnel-Medium-Type:0000 = xpto";
                            }
                            if (tunnelPrivateGroup == "")
                            {
                                tunnelPrivateGroup = " Tunnel-Private-Group-Id:0000 = " + @"""xpto""";
                            }
                            if (acctInputGigawords == "")
                            {
                                acctInputGigawords = " Acct-Input-Gigawords = 000000";
                            }
                            if (acctOutputGigawords == "")
                            {
                                acctOutputGigawords = " Acct-Output-Gigawords = 000000";
                            }
                            if (ciscoAVPairAuditSessionId == "")
                            {
                                ciscoAVPairAuditSessionId = " Cisco-AVPair = " + @"""audit-session-id=Auditsessionid""";
                            }
                            if (framedIPV6Prefix == "")
                            {
                                framedIPV6Prefix = " Framed-IPv6-Prefix = framedipv6prefix";
                            }
                            if (acctMultiSessionId == "")
                            {
                                acctMultiSessionId = " Acct-Multi-Session-Id = acctMultiSessionId";
                            }
                            if (huaweiConnectId == "")
                            {
                                huaweiConnectId = " Huawei-Connect-ID = 0000000000";
                            }
                            if (huaweiInputBurstSize == "")
                            {
                                huaweiInputBurstSize = " Huawei-Input-Burst-Size = 0000000000";
                            }
                            if (huaweiInputAverageRate == "")
                            {
                                huaweiInputAverageRate = " Huawei-Input-Average-Rate = 0000000000";
                            }
                            if (huaweiOutputBurstSize == "")
                            {
                                huaweiOutputBurstSize = " Huawei-Output-Burst-Size = 0000000000";
                            }
                            if (huaweiOutputAverageRate == "")
                            {
                                huaweiOutputAverageRate = " Huawei-Output-Average-Rate = 0000000000";
                            }
                            if (huaweiPriority == "")
                            {
                                huaweiPriority = " Huawei-Priority = 0000000000";
                            }
                            if (freeRadiusAcctSessionStartTime == "")
                            {
                                freeRadiusAcctSessionStartTime = " FreeRADIUS-Acct-Session-Start-Time =" + @"""freeRadiusAcctSessionStartTime""";
                            }
                            if(arubaEssidName == "")
                            {
                                arubaEssidName = " Aruba-Essid-Name =" + @"""arubaessidname""";
                            }
                            if (arubaLocationId == "")
                            {
                                arubaLocationId = " Aruba-Location-Id =" + @"""arubalocationid""";
                            }
                            if (arubaUserVlan == "")
                            {
                                arubaUserVlan = " Aruba-User-Vlan = 0000000000";
                            }
                            if (arubaAPGroup == "")
                            {
                                arubaAPGroup = " Aruba-AP-Group =" + @"""arubaapgroup""";
                            }
                            if(colubrisAVPairGroup == "")
                            {
                                colubrisAVPairGroup = " Colubris-AVPair = " + @"""group=group""";
                            }
                            if(colubrisAVPairIncomingVlanId == "")
                            {
                                colubrisAVPairIncomingVlanId = " Colubris-AVPair = incoming-vlan-id=0000000000";
                            }

                            //Log Radius Completo, que irá preencher cada linha do novo ficheiro de logs
                            allCamps = data + acctSessionId + calledStationID + callingStationID + colubrisAVPairSsid + colubrisAVPairGroup + colubrisAVPairIncomingVlanId + ciscoAVPairSsid + ciscoAVPairVlanid + ciscoAVPairNasLocation + username + ciscoAVPairConnectProgress + acctStatusType + nasIPAddress
                                    + nasPortType + nasPortID + nasPort + wisprLocationName + serviceType + acctDelayTime + acctUniqueSessionId + acctInputOctets + acctOutputOctets + acctInputPackets + acctOutputPackets
                                    + acctTerminateCause + ciscoAVPairDiscCauseExt + strippedUsername + realm + operatorName + eduroamSPCountry + proxyState + ciscoAVPairAuthAlgoType + acctSessionTime + acctAuthentic
                                    + ciscoNasPort + attr_103 + accessPointID + accessPointName + connectInfo + framedIPAddress + nasIdentifier + 
                                    airespaceWlanId + tunnelType + tunnelMediumType + tunnelPrivateGroup + framedIPV6Prefix + acctInputGigawords
                                    + acctOutputGigawords + ciscoAVPairAuditSessionId + acctMultiSessionId + huaweiConnectId + huaweiInputBurstSize +
                                    huaweiInputAverageRate + huaweiOutputBurstSize + huaweiOutputAverageRate +
                                    huaweiPriority + freeRadiusAcctSessionStartTime + arubaEssidName + arubaLocationId + arubaAPGroup +
                                    arubaUserVlan  + timestamp + eventTimestamp;
                            File.AppendAllText(savefilename, allCamps);

                            File.AppendAllText(savefilename, Environment.NewLine);

                            //Limpar strings
                            data = ""; acctSessionId = ""; calledStationID = ""; callingStationID = ""; colubrisAVPairSsid = ""; ciscoAVPairSsid = ""; ciscoAVPairVlanid = ""; ciscoAVPairNasLocation = "";
                            username = ""; ciscoAVPairConnectProgress = ""; acctStatusType = ""; nasIPAddress = ""; nasPortType = ""; nasPortID = ""; nasPort = ""; wisprLocationName = "";
                            serviceType = ""; acctDelayTime = ""; acctUniqueSessionId = ""; acctInputOctets = ""; acctOutputOctets = ""; acctInputPackets = ""; acctOutputPackets = "";
                            acctTerminateCause = ""; ciscoAVPairDiscCauseExt = ""; strippedUsername = ""; realm = ""; operatorName = ""; eduroamSPCountry = ""; proxyState = ""; ciscoAVPairAuthAlgoType = "";
                            acctSessionTime = ""; acctAuthentic = ""; ciscoNasPort = ""; attr_103 = ""; accessPointID = ""; accessPointName = ""; connectInfo = ""; framedIPAddress = "";
                            nasIdentifier = ""; timestamp = ""; eventTimestamp = ""; airespaceWlanId = ""; tunnelType = ""; tunnelMediumType = ""; tunnelPrivateGroup = "";
                            acctInputGigawords = ""; acctOutputGigawords = ""; acctMultiSessionId = ""; huaweiConnectId = "";
                            huaweiInputBurstSize = ""; huaweiInputAverageRate = ""; huaweiOutputBurstSize = ""; huaweiOutputAverageRate = "";
                            huaweiPriority = ""; freeRadiusAcctSessionStartTime = ""; arubaEssidName = ""; arubaLocationId = ""; colubrisAVPairIncomingVlanId = "";
                            arubaUserVlan = ""; arubaAPGroup = ""; colubrisAVPairGroup = "";

                            //Limpar flags
                            a1 = 0; a2 = 0; a3 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0; a10 = 0; a11 = 0; a12 = 0; a13 = 0; a14 = 0; a15 = 0;
                            a16 = 0; a17 = 0; a18 = 0; a19 = 0; a20 = 0; a21 = 0; a22 = 0; a23 = 0; a24 = 0; a25 = 0; a26 = 0; a27 = 0; a28 = 0; a29 = 0; a30 = 0; a31 = 0;
                            a32 = 0; a33 = 0; a34 = 0; a35 = 0; a36 = 0; a37 = 0; a38 = 0; a39 = 0; a40 = 0; a41 = 0; a42 = 0; a43 = 0; a44 = 0; a45 = 0; a46 = 0;
                            a47 = 0; a48 = 0; a49 = 0; a50 = 0; a51 = 0; a52 = 0; a53 = 0; a54 = 0; a55 = 0; a56 = 0; a57 = 0; a58 = 0;
                            a59 = 0; a60 = 0; a61 = 0; a62 = 0; a63 = 0; a64 = 0;

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

                        }
                        else
                        {
                            cleanData = "";
                            if (line.Contains("\t"))
                            {
                                temp = line.Replace("\t", " ");
                                cleanData = temp;

                                if (cleanData.Contains("  "))
                                {
                                    temp2 = cleanData.Replace("  ", " ");
                                    cleanData = temp2;
                                }
                            }
                            else
                            {
                                cleanData = line;
                            }
                            //Verificar se existem os campos todos. Caso não existem serão adicionados à string
                            if ((cleanData.Contains("Mon") || cleanData.Contains("Tue") || cleanData.Contains("Wed") || cleanData.Contains("Thu") || cleanData.Contains("Fri") || cleanData.Contains("Sat") || cleanData.Contains("Sun")) && a1 != 1)
                            {
                                data = cleanData;
                                encontrou = true;
                                a1 = 1;
                            }
                            if (cleanData.Contains("Acct-Session-Id") && !encontrou && a2 != 1)
                            {
                                acctSessionId = cleanData;
                                encontrou = true;
                                a2 = 1;
                            }
                            if (cleanData.Contains("Called-Station-Id") && !encontrou && a3 != 1)
                            {
                                calledStationID = cleanData;
                                encontrou = true;
                                a3 = 1;
                            }
                            if (cleanData.Contains("Calling-Station-Id") && !encontrou && a4 != 1)
                            {
                                callingStationID = cleanData;
                                encontrou = true;
                                a4 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            string searchForThis3 = "ssid=";
                            string searchForThis4 = "Colubris";
                            int firstCharacter3 = cleanData.IndexOf(searchForThis3);
                            int firstCharacter4 = cleanData.IndexOf(searchForThis4);
                            if (firstCharacter3 != -1 && firstCharacter4 != -1 && !encontrou && a37 != 1)
                            {
                                colubrisAVPairSsid = cleanData;
                                encontrou = true;
                                a37 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            string searchForThis5 = "group=";
                            string searchForThis6 = "Colubris";
                            int firstCharacter5 = cleanData.IndexOf(searchForThis5);
                            int firstCharacter6 = cleanData.IndexOf(searchForThis6);
                            if (firstCharacter5 != -1 && firstCharacter6 != -1 && !encontrou && a63 != 1)
                            {
                                colubrisAVPairGroup = cleanData;
                                encontrou = true;
                                a63 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            string searchForThis7 = "incoming-vlan-id=";
                            string searchForThis8 = "Colubris";
                            int firstCharacter7 = cleanData.IndexOf(searchForThis7);
                            int firstCharacter8 = cleanData.IndexOf(searchForThis8);
                            if (firstCharacter5 != -1 && firstCharacter6 != -1 && !encontrou && a64 != 1)
                            {
                                colubrisAVPairIncomingVlanId = cleanData;
                                encontrou = true;
                                a64 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            string searchForThis = "ssid=";
                            string searchForThis2 = "Cisco";
                            int firstCharacter = cleanData.IndexOf(searchForThis);
                            int firstCharacter2 = cleanData.IndexOf(searchForThis2);
                            if (firstCharacter != -1 && firstCharacter2 != -1 && !encontrou && a5 != 1)
                            {
                                ciscoAVPairSsid = cleanData;
                                encontrou = true;
                                a5 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            searchForThis = "vlan-id=";
                            firstCharacter = cleanData.IndexOf(searchForThis);
                            if (firstCharacter != -1 && !encontrou && a6 != 1)
                            {
                                ciscoAVPairVlanid = cleanData;
                                encontrou = true;
                                a6 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            searchForThis = "nas-location=";
                            firstCharacter = cleanData.IndexOf(searchForThis);
                            if (firstCharacter != -1 && !encontrou && a7 != 1)
                            {
                                ciscoAVPairNasLocation = cleanData;
                                encontrou = true;
                                a7 = 1;
                            }
                            if (cleanData.Contains("User-Name") && !encontrou && a8 != 1)
                            {
                                username = cleanData;
                                encontrou = true;
                                a8 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            searchForThis = "connect-progress=";
                            firstCharacter = cleanData.IndexOf(searchForThis);
                            if (firstCharacter != -1 && !encontrou && a9 != 1)
                            {
                                ciscoAVPairConnectProgress = cleanData;
                                encontrou = true;
                                a9 = 1;
                            }
                            if (cleanData.Contains("Acct-Status-Type") && !encontrou && a10 != 1)
                            {
                                acctStatusType = cleanData;
                                encontrou = true;
                                a10 = 1;
                            }
                            if (cleanData.Contains("NAS-IP-Address") && !encontrou && a11 != 1)
                            {
                                nasIPAddress = cleanData;
                                encontrou = true;
                                a11 = 1;
                            }
                            if (cleanData.Contains("NAS-Port-Type") && !encontrou && a12 != 1)
                            {
                                nasPortType = cleanData;
                                encontrou = true;
                                a12 = 1;
                            }
                            if (cleanData.Contains("NAS-Port-Id") && !encontrou && a13 != 1)
                            {
                                nasPortID = cleanData;
                                encontrou = true;
                                a13 = 1;
                            }
                            if (cleanData.Equals("NAS-Port") && !encontrou && a14 != 1)
                            {
                                nasPort = cleanData;
                                encontrou = true;
                                a14 = 1;
                            }
                            if (cleanData.Contains("WISPr-Location-Name") && !encontrou && a15 != 1)
                            {
                                wisprLocationName = cleanData;
                                encontrou = true;
                                a15 = 1;
                            }
                            if (cleanData.Contains("Service-Type") && !encontrou && a16 != 1)
                            {
                                serviceType = cleanData;
                                encontrou = true;
                                a16 = 1;
                            }
                            if (cleanData.Contains("Acct-Delay-Time") && !encontrou && a17 != 1)
                            {
                                acctDelayTime = cleanData;
                                encontrou = true;
                                a17 = 1;
                            }
                            if (cleanData.Contains("Acct-Unique-Session-Id") && !encontrou && a18 != 1)
                            {
                                acctUniqueSessionId = cleanData;
                                encontrou = true;
                                a18 = 1;
                            }
                            if (cleanData.Contains("Acct-Input-Octets") && !encontrou && a19 != 1)
                            {
                                acctInputOctets = cleanData;
                                encontrou = true;
                                a19 = 1;
                            }
                            if (cleanData.Contains("Acct-Output-Octets") && !encontrou && a20 != 1)
                            {
                                acctOutputOctets = cleanData;
                                encontrou = true;
                                a20 = 1;
                            }
                            if (cleanData.Contains("Acct-Input-Packets") && !encontrou && a21 != 1)
                            {
                                acctInputPackets = cleanData;
                                encontrou = true;
                                a21 = 1;
                            }
                            if (cleanData.Contains("Acct-Output-Packets") && !encontrou && a22 != 1)
                            {
                                acctOutputPackets = cleanData;
                                encontrou = true;
                                a22 = 1;
                            }
                            if (cleanData.Contains("Acct-Terminate-Cause") && !encontrou && a23 != 1)
                            {
                                acctTerminateCause = cleanData;
                                encontrou = true;
                                a23 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            searchForThis = "disc-cause-ext=";
                            firstCharacter = cleanData.IndexOf(searchForThis);
                            if (firstCharacter != -1 && !encontrou && a24 != 1)
                            {
                                ciscoAVPairDiscCauseExt = cleanData;
                                encontrou = true;
                                a24 = 1;
                            }
                            if (cleanData.Contains("Stripped-User-Name") && !encontrou && a25 != 1)
                            {
                                strippedUsername = cleanData;
                                encontrou = true;
                                a25 = 1;
                            }
                            if (cleanData.Contains("Realm") && !encontrou && a26 != 1)
                            {
                                realm = cleanData;
                                encontrou = true;
                                a26 = 1;
                            }
                            if (cleanData.Contains("Operator-Name") && !encontrou && a27 != 1)
                            {
                                operatorName = cleanData;
                                encontrou = true;
                                a27 = 1;
                            }
                            if (cleanData.Contains("Eduroam-SP-Country") && !encontrou && a28 != 1)
                            {
                                eduroamSPCountry = cleanData;
                                encontrou = true;
                                a28 = 1;
                            }
                            if (cleanData.Contains("Proxy-State") && !encontrou && a29 != 1)
                            {
                                proxyState = cleanData;
                                encontrou = true;
                                a29 = 1;
                            }

                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            searchForThis = "auth-algo-type=";
                            firstCharacter = cleanData.IndexOf(searchForThis);
                            if (firstCharacter != -1 && !encontrou && a30 != 1)
                            {
                                ciscoAVPairAuthAlgoType = cleanData;
                                encontrou = true;
                                a30 = 1;
                            }
                            if (cleanData.Contains("Acct-Session-Time") && !encontrou && a31 != 1)
                            {
                                acctSessionTime = cleanData;
                                encontrou = true;
                                a31 = 1;
                            }
                            if (cleanData.Contains("Acct-Authentic") && !encontrou && a32 != 1)
                            {
                                acctAuthentic = cleanData;
                                encontrou = true;
                                a32 = 1;
                            }
                            if (cleanData.Contains("Cisco-NAS-Port") && !encontrou && a33 != 1)
                            {
                                ciscoNasPort = cleanData;
                                encontrou = true;
                                a33 = 1;
                            }
                            if (cleanData.Contains("Attr-103") && !encontrou && a34 != 1)
                            {
                                attr_103 = cleanData;
                                encontrou = true;
                                a34 = 1;
                            }
                            if (cleanData.Contains("Access-Point-Id") && !encontrou && a38 != 1)
                            {
                                accessPointID = cleanData;
                                encontrou = true;
                                a38 = 1;
                            }
                            if (cleanData.Contains("Access-Point-Name") && !encontrou && a39 != 1)
                            {
                                accessPointName = cleanData;
                                encontrou = true;
                                a39 = 1;
                            }
                            if (cleanData.Contains("Connect-Info") && !encontrou && a40 != 1)
                            {
                                connectInfo = cleanData;
                                encontrou = true;
                                a40 = 1;
                            }
                            if (cleanData.Contains("NAS-Identifier") && !encontrou && a41 != 1)
                            {
                                nasIdentifier = cleanData;
                                encontrou = true;
                                a41 = 1;
                            }
                            if (cleanData.Contains("Framed-IP-Address") && !encontrou && a42 != 1)
                            {
                                framedIPAddress = cleanData;
                                encontrou = true;
                                a42 = 1;
                            }                         
                            if (cleanData.Contains("Event") && !encontrou && a36 != 1)
                            {
                                eventTimestamp = cleanData;
                                encontrou = true;
                                a36 = 1;
                            }
                            if (cleanData.Contains("Timestamp") && !encontrou && a35 != 1)
                            {
                                timestamp = cleanData;
                                encontrou = true;
                                a35 = 1;
                            }
                            if (cleanData.Contains("Airespace-Wlan-Id") && !encontrou && a43 != 1)
                            {
                                airespaceWlanId = cleanData;
                                encontrou = true;
                                a43 = 1;
                            }
                            //Procurar se uma parte de string existe. Se não existir retorna -1.
                            searchForThis = "audit-session-id=";
                            firstCharacter = cleanData.IndexOf(searchForThis);
                            if (firstCharacter != -1 && !encontrou && a44 != 1)
                            {
                                ciscoAVPairAuditSessionId = cleanData;
                                encontrou = true;
                                a44 = 1;
                            }
                            if (cleanData.Contains("Framed-IPv6-Prefix") && !encontrou && a45 != 1)
                            {
                                framedIPV6Prefix = cleanData;
                                encontrou = true;
                                a45 = 1;
                            }
                            if (cleanData.Contains("Acct-Input-Gigawords") && !encontrou && a46 != 1)
                            {
                                acctInputGigawords = cleanData;
                                encontrou = true;
                                a46 = 1;
                            }
                            if (cleanData.Contains("Acct-Output-Gigawords") && !encontrou && a47 != 1)
                            {
                                acctOutputGigawords = cleanData;
                                encontrou = true;
                                a47 = 1;
                            }
                            if (cleanData.Contains("Tunnel-Type") && !encontrou && a48 != 1)
                            {
                                tunnelType = cleanData;
                                encontrou = true;
                                a48 = 1;
                            }
                            if (cleanData.Contains("Tunnel-Medium-Type") && !encontrou && a49 != 1)
                            {
                                tunnelMediumType = cleanData;
                                encontrou = true;
                                a49 = 1;
                            }
                            if (cleanData.Contains("Tunnel-Private-Group-Id") && !encontrou && a50 != 1)
                            {
                                tunnelPrivateGroup = cleanData;
                                encontrou = true;
                                a50 = 1;
                            }
                            if (cleanData.Contains("Acct-Multi-Session-Id") && !encontrou && a51 != 1)
                            {
                                acctMultiSessionId = cleanData;
                                encontrou = true;
                                a51 = 1;
                            }
                            if (cleanData.Contains("Huawei-Connect-ID") && !encontrou && a52 != 1)
                            {
                                huaweiConnectId = cleanData;
                                encontrou = true;
                                a52 = 1;
                            }
                            if (cleanData.Contains("Huawei-Input-Burst-Size") && !encontrou && a53 != 1)
                            {
                                huaweiInputBurstSize = cleanData;
                                encontrou = true;
                                a53 = 1;
                            }
                            if (cleanData.Contains("Huawei-Input-Average-Rate") && !encontrou && a54 != 1)
                            {
                                huaweiInputAverageRate = cleanData;
                                encontrou = true;
                                a54 = 1;
                            }
                            if (cleanData.Contains("Huawei-Output-Burst-Size") && !encontrou && a55 != 1)
                            {
                                huaweiOutputBurstSize = cleanData;
                                encontrou = true;
                                a55 = 1;
                            }
                            if (cleanData.Contains("Huawei-Output-Average-Rate") && !encontrou && a56 != 1)
                            {
                                huaweiOutputAverageRate = cleanData;
                                encontrou = true;
                                a56 = 1;
                            }
                            if (cleanData.Contains("Huawei-Priority") && !encontrou && a57 != 1)
                            {
                                huaweiPriority = cleanData;
                                encontrou = true;
                                a57 = 1;
                            }
                            if (cleanData.Contains("FreeRADIUS-Acct-Session-Start-Time") && !encontrou && a58 != 1)
                            {
                                freeRadiusAcctSessionStartTime = cleanData;
                                encontrou = true;
                                a58 = 1;
                            }
                            if (cleanData.Contains("Aruba-Essid-Name") && !encontrou && a59 != 1)
                            {
                                arubaEssidName = cleanData;
                                encontrou = true;
                                a59 = 1;
                            }
                            if (cleanData.Contains("Aruba-Location-Id") && !encontrou && a60 != 1)
                            {
                                arubaLocationId = cleanData;
                                encontrou = true;
                                a60 = 1;
                            }
                            if (cleanData.Contains("Aruba-AP-Group") && !encontrou && a61 != 1)
                            {
                                arubaAPGroup = cleanData;
                                encontrou = true;
                                a61 = 1;
                            }
                            if (cleanData.Contains("Aruba-User-Vlan") && !encontrou && a62 != 1)
                            {
                                arubaUserVlan = cleanData;
                                encontrou = true;
                                a62 = 1;
                            }
                        }
                    }
                    File.AppendAllText(savefilename, "END");
                    
					//Fazer reset dos valores da progress bar
					progressBarClean.Visible = false;
                    progressBarClean.Value = 0;
                    progressBarClean.Minimum = 0;
                    progressBarClean.Step = 1;
					
					//Step 2 - Remover aspas de cada log
                    var fileSecond = File.ReadAllLines(savefilename);
                    string tempi = "";
                    progressBarClean.Visible = true;
                    label_step_1.Text = "Step: 2/3";
                    label_step_1.Refresh();
                    foreach (var lineSeccount in fileSecond)
                    {
                        tempi = "";
                        if (lineSeccount.Contains("\""))
                        {
                            tempi = lineSeccount.Replace("\"", " ");
                            File.AppendAllText(path_temp_file, tempi);
                            File.AppendAllText(path_temp_file, "\r\n");
                        }
                        else
                        {
                            File.AppendAllText(path_temp_file, lineSeccount);
                            File.AppendAllText(path_temp_file, "\r\n");
                        }

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
                    }
                    var fileSecond2 = File.ReadAllLines(path_temp_file);
                    string tempi2 = "";
                    File.Delete(savefilename);
					
					//Fazer reset dos valores da progress bar
                    progressBarClean.Value = 0;
                    progressBarClean.Minimum = 0;
                    progressBarClean.Step = 1;
                    progressBarClean.Visible = true;
                    label_step_1.Text = "Step: 3/3";
                    label_step_1.Refresh();
					
					//Step 3 - Remover duplo espaço em branco e substituir por apenas um espaço para cada log
                    foreach (var lineThrcount in fileSecond2)
                    {
                        tempi2 = "";
                        if (lineThrcount.Contains("  "))
                        {
                            tempi2 = lineThrcount.Replace("  ", " ");
                            File.AppendAllText(savefilename, tempi2);
                            File.AppendAllText(savefilename, "\r\n");
                        }
                        else
                        {
                            File.AppendAllText(savefilename, lineThrcount);
                            File.AppendAllText(savefilename, "\r\n");
                        }

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
                    }

					//Progress bar é escondida
                    progressBarClean.Visible = false;
					//Habilitar novamente os controlos sobre a aplicação
                    this.ControlBox = true;
					//O botão de consolidação é colocado vísivel
                    buttonCleanLogs.Visible = true;
					//Label da primeira etapa colocada visível
                    label_step_1.Visible = false;
					//Label da primeira etapa colocada visível e atualizada
                    label_step_1.Refresh();
					//Remover ficheiro temporário
                    File.Delete(path_temp_file);
					//Mensagem de aviso ao utilizador de que a consolidação e transformação está terminada
                    MessageBox.Show("A Consolidação e transformação do ficheiro está concluída!!!");
                }
				//Caso o ficheiro não exista é lançada uma mensagem a avisar o utilizador que o ficheiro selecionado não é válido
                else
                {
                     MessageBox.Show("O ficheiro introduzido não é válido!!!\nTente novamente!!!");
                }
            }
        }
		
		//Função Click do botão para abrir um ficheiro para processar
        private void textBoxPathFile_Click(object sender, EventArgs e)
        {
            //Adicionar qual ficheiro a abrir
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Text File (.txt) | *.txt";
            openFileDialog1.FilterIndex = 1;

			//Validar o ficheiro escolhido, carregando no botão OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPathFile.Text = openFileDialog1.FileName;
            }
        }

    }
}