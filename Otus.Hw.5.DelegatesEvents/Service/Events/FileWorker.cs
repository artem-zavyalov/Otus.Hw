namespace Otus.Hw._5.DelegatesEvents.Service.Events;

public class FileWorker
{
    public event EventHandler<FileArgs> FileFound;

    public void Search(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            var args = RaiseFileFound(file);

            if (args.CancelRequested)
            {
                break;
            }
        }

        FileArgs RaiseFileFound(string file)
        {
            var args = new FileArgs(file);
            FileFound.Invoke(this, args);

            return args;
        }
    }

    public class FileArgs : EventArgs
    {
        public string FileName { get; }
        public bool CancelRequested { get; set; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}