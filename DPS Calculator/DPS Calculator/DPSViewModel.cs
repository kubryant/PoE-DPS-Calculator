using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS_Calculator
{
    class DPSViewModel : INotifyPropertyChanged
    {
        private double lowPDPS;
        private double highPDPS;
        private double lowFDPS;
        private double highFDPS;
        private double lowLDPS;
        private double highLDPS;
        private double lowCDPS;
        private double highCDPS;
        private double ASPD;
        private double Quality;
        private double IPD;
        private double highFlatDamage;
        private double lowFlatDamage;
        private double DPS;
        private double DPSQ;
        private double PDPS;
        private double PDPSQ;

        public DPSViewModel()
        {
            lowPDPS = 0;
            highPDPS = 0;
            lowFDPS = 0;
            highFDPS = 0;
            lowLDPS = 0;
            highLDPS = 0;
            lowCDPS = 0;
            highCDPS = 0;
            ASPD = 0;
            Quality = 0;
            IPD = 0;
            highFlatDamage = 0;
            lowFlatDamage = 0;
            DPS = 0;
            DPSQ = 0;
            PDPS = 0;
            PDPSQ = 0;
        }

        public double LPDPS
        {
            get { return lowPDPS; }
            set { lowPDPS = value; }
        }
        public double HPDPS
        {
            get { return highPDPS; }
            set { highPDPS = value; }
        }
        public double LFDPS
        {
            get { return lowFDPS; }
            set { lowFDPS = value; }
        }
        public double HFDPS
        {
            get { return highFDPS; }
            set { highFDPS = value; }
        }
        public double LLDPS
        {
            get { return lowLDPS; }
            set { lowLDPS = value; }
        }
        public double HLDPS
        {
            get { return highLDPS; }
            set { highLDPS = value; }
        }
        public double LCDPS
        {
            get { return lowCDPS; }
            set { lowCDPS = value; }
        }
        public double HCDPS
        {
            get { return highCDPS; }
            set { highCDPS = value; }
        }
        public double ATSPD
        {
            get { return ASPD; }
            set { ASPD = value; }
        }
        public double Qual
        {
            get { return Quality; }
            set { Quality = value; }
        }
        public double IPDM
        {
            get { return IPD; }
            set { IPD = value; }
        }
        public double HFPD
        {
            get { return highFlatDamage; }
            set { highFlatDamage = value; }
        }
        public double LFPD
        {
            get { return lowFlatDamage; }
            set { lowFlatDamage = value; }
        }
        public double DPSEC
        {
            get { DPS = ((lowPDPS + highPDPS + lowFDPS + highFDPS + lowLDPS + highLDPS + lowCDPS + highCDPS) / 2) * ASPD; return DPS; }
            set { DPS = value; OnPropertyChanged("DPSEC"); }
        }
        public double PDPSEC
        {
            get { PDPS = ((lowPDPS + highPDPS) / 2) * ASPD; return PDPS; }
            set { PDPS = value; OnPropertyChanged("PDPSEC"); }
        }
        public double DPSECQ
        {
            get
            {
                double baseMinDamage = (lowPDPS / (((IPD + Quality) / 100) + 1)) - lowFlatDamage;
                double baseMaxDamage = (highPDPS / (((IPD + Quality) / 100) + 1)) - highFlatDamage;
                baseMinDamage = Math.Round(baseMinDamage);
                baseMaxDamage = Math.Round(baseMaxDamage);
                double lowPDPSQ = (baseMinDamage + lowFlatDamage) * (1 + ((IPD + 20) / 100));
                double highPDPSQ = (baseMaxDamage + highFlatDamage) * (1 + ((IPD + 20) / 100));
                lowPDPSQ = Math.Round(lowPDPSQ);
                highPDPSQ = Math.Round(highPDPSQ);
                DPSQ = ((lowPDPSQ + highPDPSQ + lowFDPS + highFDPS + lowLDPS + highLDPS + lowCDPS + highCDPS) / 2) * ASPD;
                return DPSQ;
            }
            set { DPSQ = value; OnPropertyChanged("DPSECQ"); }
        }
        public double PDPSECQ
        {
            get
            {
                double baseMinDamage = (lowPDPS / (((IPD + Quality) / 100) + 1)) - lowFlatDamage;
                double baseMaxDamage = (highPDPS / (((IPD + Quality) / 100) + 1)) - highFlatDamage;
                baseMinDamage = Math.Round(baseMinDamage);
                baseMaxDamage = Math.Round(baseMaxDamage);
                double lowPDPSQ = (baseMinDamage + lowFlatDamage) * (1 + ((IPD + 20) / 100));
                double highPDPSQ = (baseMaxDamage + highFlatDamage) * (1 + ((IPD + 20) / 100));
                lowPDPSQ = Math.Round(lowPDPSQ);
                highPDPSQ = Math.Round(highPDPSQ);
                PDPSQ = ((lowPDPSQ + highPDPSQ) / 2) * ASPD;
                return PDPSQ;
            }
            set { PDPSQ = value; OnPropertyChanged("PDPSECQ"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
