using Implementasi_MVC.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Implementasi_MVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, OnPowerChanged, OnDoorChanged, OnCarEngineStateChanged
    {
        private Car nextCar;
        public MainWindow()
        {
            InitializeComponent();

            AccubatteryController accubatteryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car(doorController, accubatteryController, this);
        }

        private void onStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.startingEngine();
        }

        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheOpenDoorButton();
        }

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheLockDoorButton();
        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleThePowerButton();
        }

        public void onPowerChangedStatus(string value, string message)
        {
            AccuState.Content = message;
            AccuButton.Content = value;
        }

        public void onlockDoorStateChanged(string value, string message)
        {
            LockDoorState.Content = message;
            LockDoorButton.Content = value;
        }

        public void onDoorOpenStateChanged(string value, string message)
        {
            DoorOpenState.Content = message;
            DoorOpenButton.Content = value;
        }

        public void onCarEngineStateChanged(string value, string message)
        {
            status.Content = message;
            startButton.Content = value;
        }
    }
}
