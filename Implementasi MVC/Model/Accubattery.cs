using System;
using System.Collections.Generic;
using System.Text;

namespace Implementasi_MVC.Model
{
    class Accubattery
    {
        private int voltage;
        private bool stateOn = false;

        public Accubattery(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.stateOn = true;
        }
        public void turnOff()
        {
            this.stateOn = false;
        }
        public bool isOn()
        {
            return this.stateOn;
        }
    }
}
