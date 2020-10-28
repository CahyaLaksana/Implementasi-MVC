using Implementasi_MVC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementasi_MVC.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackDoorChanged;

        public DoorController(OnDoorChanged callbackDoorChanged)
        {
            this.callbackDoorChanged = callbackDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackDoorChanged.onDoorOpenStateChanged("CLOSED","door closed");
        }

        public void open()
        {
            this.door.open();
            this.callbackDoorChanged.onDoorOpenStateChanged("OPENED", "door open");
        }

        public void activateLock()
        {
            this.door.activateLock();
            this.callbackDoorChanged.onDoorOpenStateChanged("LOCKED", "door locked");
        }

        public void unlock()
        {
            this.callbackDoorChanged.onDoorOpenStateChanged("UNLOCKED", "door unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    
    interface OnDoorChanged
    {
        void onlockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
}
