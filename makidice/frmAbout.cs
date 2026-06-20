using System.Windows.Forms;
using System.Reflection;

namespace makidice {
    public partial class frmAbout : Form {
        public frmAbout() {
            InitializeComponent();
            this.lblApplication.Text = AssemblyTitle;
            this.lblVersion.Text = "Version " + AssemblyVersion;
            this.lblURL.Text = "github.com/andrewmichaelpowell";
        }

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0.0";
            }
        }
    }
}