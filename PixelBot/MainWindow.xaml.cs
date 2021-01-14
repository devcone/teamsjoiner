using System;
using System.Windows; 
using System.Drawing; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using MessageBox = System.Windows.MessageBox; 
using System.Threading;
using System.IO;


namespace PixelBot
{
    
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
            int milli = minutes * 30000;
            int finalmilli = milli + 30000;


            string endmin = textbox2.Text;
            int endminutes = Convert.ToInt32(endmin);
            int endmilli = endminutes * 60000;
            int endmillifinal = endmilli + 30000;
            new System.Threading.ManualResetEvent(false).WaitOne(finalmilli);


            new System.Threading.ManualResetEvent(false).WaitOne(6000);

            string inputHexColorCode = "#C2C3DD";
            SearchPixel(inputHexColorCode);
            Thread.Sleep(6000);
            bool finalised = true;
            if (finalised == true)
            {
                new System.Threading.ManualResetEvent(false).WaitOne(1000);
                string inputhexcolorcode2 = "#62C4F1";
                SearchPixel(inputhexcolorcode2);
                bool secondstep = true;
                new System.Threading.ManualResetEvent(false).WaitOne(endmillifinal);
                if (secondstep == true)
                {
                    string inputhexcolorcode3 = "#CF586D";
                    SearchPixel(inputhexcolorcode3);

                    var window3 = new finished();
                    window3.Show();
                } 
                
            }
            
        }   
        private bool SearchPixel(string hexcode)
        {
            Bitmap bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); 

            Graphics graphics = Graphics.FromImage(bitmap as Image); 
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); 

            Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);

            for (int x = 0; x < SystemInformation.VirtualScreen.Width; x++)
            {
                for (int y = 0; y < SystemInformation.VirtualScreen.Height; y++)
                {
                    
                    Color currentPixelColor = bitmap.GetPixel(x, y);
                    if (desiredPixelColor == currentPixelColor)
                    {
                        DoubleClickAtPosition(x, y);
                        return true;
                    }

                }
            }

            string endmin1 = textbox2.Text;
            int endminutes1 = Convert.ToInt32(endmin1);
            int endmilli1 = endminutes1 * 60000;
            int endmillifinal = endmilli1 + 30000;

            new System.Threading.ManualResetEvent(false).WaitOne(120000);

            string joinbutton = "#C2C3DD";
            method(joinbutton);
            bool finalised1 = true;
            if (finalised1 == true)
            {
                new System.Threading.ManualResetEvent(false).WaitOne(1000);
                string secondjoin = "#62C4F1";
                method(secondjoin);
                bool secondstep = true;
                new System.Threading.ManualResetEvent(false).WaitOne(1);

                if (secondstep == true)
                {
                    string inputhexcolorcode5 = "#CF586D";
                    method(inputhexcolorcode5);
                    var window3 = new finished();
                    window3.Show();

                }
            }

            void method (string codehex)
            {
                Bitmap bitmap1 = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
                Graphics graphics1 = Graphics.FromImage(bitmap as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                Color desiredPixelColor1 = ColorTranslator.FromHtml(codehex);

                for (int x = 0; x < SystemInformation.VirtualScreen.Width; x++)
                {
                    for (int y = 0; y < SystemInformation.VirtualScreen.Height; y++)
                    {
                        Color currentPixelColor = bitmap.GetPixel(x, y);

                        if (desiredPixelColor == currentPixelColor)
                        {
                            DoubleClickAtPosition(x, y);
                        }
                    }



                }
                string message45 = "join button not found, tried 2 times";
                MessageBox.Show(message45);
                // IF you want to try 3 times, write the code again here
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
            var window2 = new Settings();
            window2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window4 = new howtouse();
            window4.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window3 = new finished();
            window3.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://forms.gle/3AECq1f3M7nYvjWh7");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://forms.gle/kn9LZZbSbK3akmto6");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/devcone");
        }

    }
}
