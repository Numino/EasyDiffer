using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace JsonDiffer.Services;

public class FileWatcherService
{
    private readonly List<string> _list;
    private FileSystemWatcher _watcher;

    public FileWatcherService(List<string> list)
    {
        _list = list;
    }
    
    public void Watch()
    {
        _watcher = new FileSystemWatcher();
        _watcher.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        _watcher.NotifyFilter = NotifyFilters.Attributes |
                               NotifyFilters.CreationTime |
                               NotifyFilters.FileName |
                               NotifyFilters.LastAccess |
                               NotifyFilters.LastWrite |
                               NotifyFilters.Size |
                               NotifyFilters.Security;
        _watcher.Filter = "*.*";
        _watcher.Created += OnFilesChanges;
        _watcher.Changed += OnFilesChanges;
        _watcher.EnableRaisingEvents = true;
    }

    private void OnFilesChanges(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine(e.FullPath);
       _list.Add(e.FullPath);
    }
}