using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MagicReader
{
    public partial class FormReader : Form
    {
        #region Constants
        const bool OPEN = true;
        const bool CLOSED = false;
        const char EMPTY_BUFFER = '*';
        const char APPEND = 'a';

        //Commands to send to the uP
        const string TRY_OPEN = "O";
        const string READ_CARD = "R";
        const string SUCCESSFULLY_IDENTIFIED = "S";
        const string FAILED_TO_IDENTIFY = "F";
        const string STOP_TRANSMTTING = "X";

        //expected responses from the uP
        const char OPEN_SUCCESS = 'P';
        const char EOT = '$';       //end of transmission
        const char EOC = '#';       //end of cards
        const char NEW_CARD = '@';  //new card for processing
        const char FINISHED_PROCESSING = '^';    //uP has finished processing a card
        #endregion

        #region Properties
        SerialPort ComPort;
        ImageProcessor cardImage;
        FormDBViewer FormDB;
        #endregion

        #region Constructor
        public FormReader()
        {
            InitializeComponent();

            ComPort = new SerialPort();
            ComPort.BaudRate = 9600;
            ComPort.PortName = tbCOMSelect.Text;
            ComPort.Encoding = Encoding.Unicode;

            //FormDB = new FormDBViewer();
        }
        #endregion
               
        private bool InitializeCOMConnection()
        {
            char readChar = ' ';

            if (ComPort.IsOpen)
                ComPort.Close();

            ComPort.PortName = tbCOMSelect.Text;
            
            try
            {
                ComPort.Open();
            }
            catch
            {
                UpdateStatus("Unable to Open Port: Ensure Correct COM Port is Selected");
                return CLOSED;
            }
            
            ComPort.DiscardInBuffer();
            ComPort.WriteLine(TRY_OPEN);
            readChar = GetSerialChar();

            if (readChar == OPEN_SUCCESS)
            {
                int buffersize = ComPort.ReadBufferSize;
                UpdateStatus("Connected to COM port: " + tbCOMSelect.Text);
                return OPEN;
            }
            else
            {
                ComPort.Close();
                UpdateStatus("Unable to Connect: Ensure Device is Connected " + readChar);
                return CLOSED;
            }
        }

        private void StartReading()
        {            
            string cardName = "";
            string cardExpansion = "";
            char readChar;
            bool valid = false;

            readChar = GetNextCard();

            while (readChar == NEW_CARD)
            {
                UpdateStatus("Recieved Card: Checking Validity. ");

                cardImage = new ImageProcessor(Properties.Resources.OldGreenCard);
                cardName = cardImage.Name;

                valid = CheckIfValid(cardName , cardExpansion);

                if (valid == true)
                {
                    AddCardToListView(cardName, cardExpansion, lvSuccessfulCards);
                    ComPort.WriteLine(SUCCESSFULLY_IDENTIFIED);
                }
                else
                {
                    AddCardToListView(cardName, cardExpansion, lvAttemptedCards);
                    ComPort.WriteLine(FAILED_TO_IDENTIFY);
                }
                
                readChar = GetNextCard();
                cardExpansion = "";
                cardName = "";
            }
            UpdateStatus("Finished Reading");

        }

        private void AddCardToListView(string name, string ex, ListView lv)
        {
            ListViewItem item = new ListViewItem();
            for(int i = 0; i < lv.Items.Count; i++)
            {
                item = lv.Items[i];
                if(item.Text == name)
                {
                    if (item.SubItems.ContainsKey(ex))
                    {
                        //increase count here
                        return;
                    }

                }

            }

            item = new ListViewItem(name);
            item.SubItems.Add(ex);
            item.SubItems.Add("x1");
            lv.Items.Add(item);
            lv.Refresh();
        }

        private char GetNextCard()
        {
            int numDots = 0;
            char readChar = ' ';

            ComPort.Write(READ_CARD);
            UpdateStatus("Processing Card: ");

            readChar = GetSerialChar();

            while (readChar != FINISHED_PROCESSING)
            {
                if(DateTime.Now.TimeOfDay.Milliseconds % 500 == 0)
                {
                    UpdateStatus(" . " , APPEND);
                    numDots++;
                }
                else if(numDots == 5)
                {
                    UpdateStatus("Processing Card: ");
                    numDots = 0;
                }
                readChar = GetSerialChar();
            }

            while ((readChar = GetSerialChar()) == EMPTY_BUFFER) { }
            return readChar;
        }

        private char GetSerialChar()
        {
            if (ComPort.BytesToRead == 0)
            {
                return EMPTY_BUFFER;
            }

            char temp = (char)ComPort.ReadByte();
            return temp;
        }

        private bool CheckIfValid(string cardName, string cardExpansion)
        {

            return true;
        }

        #region Events
        private void btnStartReading_Click(object sender, EventArgs e)
        {
            btnStartReading.Enabled = false;
            bool COMConnection = InitializeCOMConnection();

            if (COMConnection == CLOSED)
            {
                btnStartReading.Enabled = true;
                return;
            }

            btnStopReading.Enabled = true;

            StartReading();

            ComPort.Close();
            btnStartReading.Enabled = true;
            btnStopReading.Enabled = false;
        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            btnStopReading.Enabled = false;
            btnStartReading.Enabled = true;

            if(ComPort.BytesToRead > 0)
            {
                UpdateStatus(ComPort.ReadExisting());
            }

            ComPort.Close();
        }
        #endregion

        void UpdateStatus(string status)
        {
            tbStatus.Text = status;
            tbStatus.Refresh();
        }
        void UpdateStatus(string status, char mode)
        {
            switch (mode)
            {
                case APPEND:
                    tbStatus.Text += status;
                    break;
                default:
                    tbStatus.Text = status;
                    break;
            }
            tbStatus.Refresh();
        }
        void UpdateStatus(char status, char mode)
        {
            switch (mode)
            {
                case APPEND:
                    tbStatus.Text += status;
                    break;
                default:
                    break;
            }
            tbStatus.Refresh();
        }

        private void btnViewDB_Click(object sender, EventArgs e)
        {
            if (FormDB == null)
                FormDB = new FormDBViewer();

            FormDB.Show();
        }
    }
}
