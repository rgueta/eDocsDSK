


using System.Diagnostics;

namespace eDocsDSK
{
    public partial class Form1 : Form
    {

        ProcessStartInfo startInfo = new ProcessStartInfo();
        string path = @"\\win2022srv\wwwroot\eDocs1\wwwroot\Files\";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            DirectoryInfo dir = new DirectoryInfo(this.path);

            var filesString = $"List of Files {Environment.NewLine}";
            int num = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(file.FullName);
                item.ImageIndex = num;
                listViewDocs.HotTracking = true;
                listViewDocs.Items.Add(item);

                num++;
            }
        }

        private void listViewDocs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewDocs_MouseClick(object sender, MouseEventArgs e)
        {
            var info = listViewDocs.HitTest(e.X, e.Y);
            var row = info.Item.Index;
            var col = info.Item.SubItems.IndexOf(info.SubItem);
            var value = info.Item.SubItems[col].Text;
  
            Process p = new()
            {
                StartInfo = new(path + value)
                { UseShellExecute = true }
            };
            p.Start();
        }
    }
}
