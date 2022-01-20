using Microsoft.Win32;

namespace ECardsLibFramework.Entities
{
    public class ImageDialog
    {
        public string SearchImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if ((openFileDialog.ShowDialog() == true) || (openFileDialog.ShowDialog() == null))
            {
                if (openFileDialog.FileName.EndsWith(".jpg") || openFileDialog.FileName.EndsWith(".png"))
                {
                    return openFileDialog.FileName;
                }
            }

            return string.Empty;
        }
    }
}
