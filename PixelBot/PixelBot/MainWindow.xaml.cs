using System;
using System.Windows; // WPF
using System.Drawing; // Color, Bitmap, Graphics
using System.Runtime.InteropServices; // User32.dll (and dll import)
using System.Windows.Forms; // Screen height and width
using MessageBox = System.Windows.MessageBox; // Use message box of wpf (not forms)
using System.Threading;
using System.IO;

namespace PixelBot
{
    // usecases: clicker bot for game - tell 
    public partial class MainWindow : Window
    {
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonSearchPixelClick(object sender, RoutedEventArgs e)
        {
 
            string min = textbox.Text;
            int minutes = Convert.ToInt32(min);
            int milli = minutes * 60000 ;
            int finalmilli = milli + 30000;
            System.Threading.Thread.Sleep(finalmilli);

            string endmin = textbox2.Text;
            int endminutes = Convert.ToInt32(min);
            int endmilli = endminutes * 60000;
            int endmillifinal = endmilli + 30000;

            string inputHexColorCode = "#C2C3DD";
            SearchPixel(inputHexColorCode);
            bool finalised = true;
            if (finalised == true)
            {
                System.Threading.Thread.Sleep(1000);
                string inputhexcolorcode2 = "#62C4F1";
                SearchPixel(inputhexcolorcode2);
                bool secondstep = true;
                System.Threading.Thread.Sleep(endmillifinal);
                if (secondstep == true)
                {
                    string inputhexcolorcode3 = "#C4314B";
                    SearchPixel(inputhexcolorcode3);

                } 
                
            }
            
        }   
        
       

        private bool SearchPixel(string hexcode)
        {
            

            Bitmap bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); // Create an empty bitmap with the size of all connected screen 

            Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen

            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object

            Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);

            // Go one to the right and then check from top to bottom every pixel (next round -> go one to right and go down again)
            for (int x = 0; x < SystemInformation.VirtualScreen.Width; x++)
            {
                for (int y = 0; y < SystemInformation.VirtualScreen.Height; y++)
                {
                    // Get the current pixels color
                    Color currentPixelColor = bitmap.GetPixel(x, y);

                    // Finally compare the pixels hex color and the desired hex color (if they match we found a pixel)
                    if (desiredPixelColor == currentPixelColor)
                    {
                        DoubleClickAtPosition(x, y);
                        return true;
                    }

                }
            }

            string message = "Join button not found... Whoops....";
            MessageBox.Show(message);
            return false;
        }

        private void DoubleClickAtPosition(int posX, int posY)
        {
            SetCursorPos(posX, posY);

            Click();
            System.Threading.Thread.Sleep(250);
        }

        private void Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message4 = "" +
                "\nContact Toby-#9580 on discord or @umtoby on instagram for help" +
                "" +
                "";
            MessageBox.Show(message4);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string message5 = "1. Open teams" +
                "\n2. open the chat where the join button will be posted" +
                "\n3. enter the minutes till class starts and ends" +
                "\n4. click start automating, make sure you are in the right chat so it can click the join button!";
            MessageBox.Show(message5);





        }
    }
}
