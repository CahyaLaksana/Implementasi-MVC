using Implementasi_MVC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementasi_MVC.Controller
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattery = new Accubattery(12);
        }
        
        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callbackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        }

        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callbackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");
        }

        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }
    }
    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
