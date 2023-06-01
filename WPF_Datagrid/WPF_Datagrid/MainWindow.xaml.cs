using AutoFixture;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Datagrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ModelGrid> ObservableItems { get; set; } = new();
        //public ModelGrid[] ObservableItems { get; set; } = ArrayPool<ModelGrid>.Shared.Rent(1000000);
        private List<ModelGrid> AllItems { get; set; } = new();
        public ConcurrentQueue<ModelGrid> updateQueue = new();
        public ManualResetEvent resetEvent = new(false);
        public ManualResetEvent waitLoop = new(false);
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            StartUpdates();
            LoopUpdates();
        }

        public void StartUpdates()
        {
            _ = Task.Run(async () =>
            {
                var fixture = new AutoFixture.Fixture();
                while (true)
                {
                    await Task.Delay(200);
                    var items = fixture.CreateMany<ModelGrid>(100);
                    foreach (var item in items)
                    {
                        updateQueue.Enqueue(item);
                        resetEvent.Set();
                    }
                }
            });
        }

        public void LoopUpdates()
        {
            _ = Task.Run(() =>
            {
                while (true)
                {
                    resetEvent.WaitOne();
                    resetEvent.Reset();
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var count = 0;
                        while (updateQueue.TryDequeue(out var result))
                        {
                            ObservableItems.Insert(0, result);
                        }
                        waitLoop.Set();
                    }));
                    waitLoop.WaitOne();
                    waitLoop.Reset();
                }
            });
        }
    }

    public partial class ModelGrid : ObservableObject
    {
        public void Update(ModelGrid? modelGrid)
        {
            if (modelGrid is null) return;

            String1 = modelGrid.string1;
            String2 = modelGrid.string2;
            String3 = modelGrid.string3;
            String4 = modelGrid.string4;
            String5 = modelGrid.string5;
            String6 = modelGrid.string6;
            String7 = modelGrid.string7;
            String8 = modelGrid.string8;
            String9 = modelGrid.string9;
            String10 = modelGrid.string10;
        }

        public void Clear()
        {
            String1 = null;
            String2 = null;
            String3 = null;
            String4 = null;
            String5 = null;
            String6 = null;
            String7 = null;
            String8 = null;
            String9 = null;
            String10 = null;
        }

        [ObservableProperty]
        private string string1;
        [ObservableProperty]
        private string string2;
        [ObservableProperty]
        private string string3;
        [ObservableProperty]
        private string string4;
        [ObservableProperty]
        private string string5;
        [ObservableProperty]
        private string string6;
        [ObservableProperty]
        private string string7;
        [ObservableProperty]
        private string string8;
        [ObservableProperty]
        private string string9;
        [ObservableProperty]
        private string string10;
    }
}
