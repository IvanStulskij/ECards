using Microsoft.Win32;

namespace ECardsLibFramework.Files
{
    public class OpenDialogPath : IPath
    {
        private string _path;

        public string Path 
        {
            get
            {
                if (_path == null)
                {
                    GetPath();
                }

                return _path;
            }
            set
            {
                _path = value;
            } 
        }

        public void GetPath()
        {
            var openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            Path = openDialog.FileName;
        }
    }
}
