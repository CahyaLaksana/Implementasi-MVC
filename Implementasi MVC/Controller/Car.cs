using Implementasi_MVC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementasi_MVC.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccubatteryController accubatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callback = callback;
        }
        
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        private bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }

        public void startingEngine()
        {
            if(!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }

            if (!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power available");
                return;
            }

            this.callback.onCarEngineStateChanged("STARTED", "Engine Started");
        }

        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toggleTheOpenDoorButton()
        {
            if(!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }
    }
    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string messatge);
    }
}
