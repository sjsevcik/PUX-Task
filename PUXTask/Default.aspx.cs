using Hanssens.Net;
using PUXTask.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace PUXTask
{
    public partial class Default : Page
    {
        private const string _FOLDER = "MyFolder";
        private FolderScan _folderScan;

        public Default()
        {
            _folderScan = new FolderScan();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyFolder folder = myFolderStorage;
                if (folder != null)
                {
                    TextBox1.Text = folder.Path;
                    LbMsg.Text = "Adresář byl načten, pokračuj v detekování změn.";
                }
                else
                    LbMsg.Text = "Naskenuj adresář";
            }
        }

        private MyFolder myFolderStorage
        {
            get
            {
                using (var storage = new LocalStorage())
                {
                    if (storage.Exists(_FOLDER))
                        return storage.Get<MyFolder>(_FOLDER);
                }

                return null;
            }
            set
            {
                using (var storage = new LocalStorage())
                {
                    storage.Store<MyFolder>(_FOLDER, value);
                }
            }
        }

        protected void SkenujAdresar()
        {
            string path = TextBox1.Text;
            if (string.IsNullOrEmpty(path))
            {
                LbMsg.Text = "Nejdříve zadej cestu k adresáři!";
                return;
            }

            myFolderStorage = _folderScan.InicialFolderScan(path);
            LbMsg.Text = $"Adresář {myFolderStorage.Path} naskenován, nyní můžeš detekovat změny.";
        }

        protected void DetekujZmenyAdresare()
        {
            myFolderStorage = _folderScan.ChangesFolderScan(myFolderStorage, out List<MyFileInfo> newFiles, out List<MyFileInfo> changeFiles, out List<MyFileInfo> deletedFiles);

            if (myFolderStorage == null)
            {
                LbMsg.Text = "Nejdříve naskenuj adresář!";
                return;
            }

            if (newFiles.Count() <= 0 && changeFiles.Count() <= 0 && deletedFiles.Count() <= 0)
            {
                LbMsg.Text = "Zádná změna nebyla detekována.";
                return;
            }

            BlNewFiles.DataSource = from x in newFiles select new { Soubor = $"{x.Name} [{x.FullName}]" };
            BlNewFiles.DataBind();

            BlChangedFiles.DataSource = from x in changeFiles select new { Soubor = $"{x.Name} [{x.FullName}]" };
            BlChangedFiles.DataBind();

            BlDeletedFiles.DataSource = from x in deletedFiles select new { Soubor = $"{x.Name} [{x.FullName}]" };
            BlDeletedFiles.DataBind();

            LbMsg.Text = "Změny detekovány.";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SkenujAdresar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DetekujZmenyAdresare();
        }
    }
}