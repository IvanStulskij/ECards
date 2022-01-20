using Microsoft.Win32;

namespace ECardsLibFramework.Entities
{
    public class ImageDialog
    {
        public string SearchImage(string directory)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if ((openFileDialog.ShowDialog() == true) || (openFileDialog.ShowDialog() == null))
            {
                if (openFileDialog.FileName.EndsWith(".jpg") || openFileDialog.FileName.EndsWith(".png"))
                {
                    return openFileDialog.FileName.Replace(directory, "").Replace(@"\", "/");
                }
            }

            return string.Empty;
        }
    }
}
