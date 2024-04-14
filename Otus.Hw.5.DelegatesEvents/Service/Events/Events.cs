namespace Otus.Hw._5.DelegatesEvents.Service.Events;

public static class Events
{
    public static void Process()
    {
        var worker = new FileWorker();
        var filesFoundCount = 0;

        EventHandler<FileWorker.FileArgs> onFileFound = (sender, eventArgs) =>
        {
            Console.WriteLine($"Founded file with name: {eventArgs.FileName}");
            filesFoundCount++;

            //imitation of cancel request
            if (filesFoundCount < 5)
            {
                return;
            }

            eventArgs.CancelRequested = true;
            Console.WriteLine("File search limit reached. Search cancelled");
        };

        worker.FileFound += onFileFound;

        worker.Search("D:", "*");

        worker.FileFound -= onFileFound;
    }
}