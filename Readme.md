# MVC
 Konsep pembangunan aplikasi menjadi 3 bagian (model, view, controller)

1. model (Accubattery, Door) dimana hanya mendeklarasikan perintah yang dimiliki dari data itu yang nantinya diarakahkan oleh controller
2. Controller (AccubatteryController, DoorController, Car) mengarahkan model saat melakukan proses, dan memilah bagian yang ditujukan pada view
3. View adalah informasi atau bagian yang diperlihatkan kepada user.



###  Door
```cs
class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.closed = false;
        }

        public void activateLock()
        {
            this.locked = true;
        }

        public void ulock()
        {
            this.locked = false;
        }

        public bool isLocked()
        {
            return this.locked;
        }

        public bool isClosed()
        {
            return this.closed;
        }
    }
```
disini dijelaskan pada class door adanya variabel yang berfungsi menutup, membuka, mengunci, membuka kunci pintu


### DoorController
```cs
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
```
memberikan informasi apa saja yang dilakukan model, informasi dedeklarasikan dan diperuntukkan oleh user

### OnDoorChanged
```cs
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

        
```
memberikan status nilai dan pesan dari perintah yang dilakukan model Door

