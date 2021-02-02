/*
     _____  _________________ ___________ _   _ _____
    /  __ \|  ___| ___ \ ___ \  ___| ___ \ | | /  ___|
    | /  \/| |__ | |_/ / |_/ / |__ | |_/ / | | \ `--.
    | |    |  __||    /| ___ \  __||    /| | | |`--. \
    | \__/\| |___| |\ \| |_/ / |___| |\ \| |_| /\__/ /
     \____/\____/\_| \_\____/\____/\_| \_|\___/\____/

     Ilkay Solotov
*/

namespace BetterText {

    public partial class BetterText : System.Windows.Forms.Form {

        private string input { get; set; }
        private string result { get; set; }
        private string[] colorInput { get; set; }
        System.Collections.Generic.List<string> palette;
        System.Collections.Generic.List<char> charIteration;
        ////////////////////////////

        ////////////////////////////
        public BetterText() { InitializeComponent(); }

        private void BetterText_Load(object sender, System.EventArgs e) {

            radioButton2.Checked = true;
            simpleTemplateSet();

            palette = new System.Collections.Generic.List<string>() {
                "DarkRed", "Red",
                "Sienna", "DarkOrange",
                "SandyBrown", "Yellow",
                "YellowGreen", "SeaGreen",
                "Blue", "Navy", "Indigo"
            };

            /* I hae no fuckng ideay there beig added alreadgy i should stop diknkg while programming stuff

            foreach(string color in palette) {
                comboBox1.Items.Add(color);
            }

            */
        }
        ////////////////////////////

        ////////////////////////////
        private void button1_Click(object sender, System.EventArgs e) {
            result = null;
            input = richTextBox1.Text;
            DrakoniaBeKindaThicc();
        }

        private void richTextBox2_TextChanged(object sender, System.EventArgs e) {
            colorInput = richTextBox2.Text.Split(' ');
            palette = new System.Collections.Generic.List<string>();
            foreach (string s in colorInput) {
                if (s != " ") {
                    comboBox1.Items.Add(s);
                    palette.Add(s);
                }
            }
        }
        ////////////////////////////

        ////////////////////////////
        public static float PingPong(float f, float length) {
            f %= length * 2f;
            return length - Abs(f - length);
        }

        public static float Abs(float f) {
            return f < 0 ? f * -1 : f;
        }

        private void DrakoniaBeKindaThicc() {
            int counter = 0;
            int keep = 0;
            string cache = null;

            if (radioButton1.Checked) {
                //charIteration = new System.Collections.Generic.List<char>();

                //foreach (char c in input) {
                //    charIteration.Add(c);
                //}
                //richTextBox1.Text = null;
                //for (int i = 0; i <= palette.Count; i++) {
                //    richTextBox1.AppendText(PingPong(i, palette.Count).ToString());
                //    //PingPong(counter, palette.Count);
                //}
                System.Collections.Generic.List<int> myInts
                    = new System.Collections.Generic.List<int>(System.Linq.Enumerable.Range(0, palette.Count));
                System.Collections.Generic.List<int> resultL
                    = new System.Collections.Generic.List<int>(myInts);

                for (int i = myInts.Count - 1; i >= 0; i--) resultL.Add(myInts[i]);

                foreach (char c in input) { // fuking broen gotta fix im too tired ad drunkto fix
                    if (myInts[counter] == palette.Count) counter = 0;
                    if (c == ' ') break;
                    cache = $"[COLOR={palette[myInts[counter]]}]{c}[/COLOR]";
                    result = result + cache;
                    counter++;
                }
                richTextBox1.Text = result;
            }
            else {
                foreach (char c in input) {
                    if(counter == palette.Count) counter = 0;
                    if (c == ' ') cache = " ";
                    else cache = $"[COLOR={palette[counter]}]{c}[/COLOR]"; counter++;
                    result = result + cache;
                }
                richTextBox1.Text = result;
            }
        }
        ////////////////////////////

        ////////////////////////////
        void simpleTemplateSet() {
            richTextBox2.Text =
                "DarkRed Red Sienna DarkOrange SandyBrown Yellow YellowGreen SeaGreen Blue Navy Indigo";
        }

        private void button2_Click(object sender, System.EventArgs e) {
            comboBox1.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            colorInput = null;
            palette = null;
        }
        ////////////////////////////

        ////////////////////////////
    }
}
