using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Model
{
    public class WorkManager
    {
        #region singleton
        private static readonly WorkManager instance = new WorkManager();
        static WorkManager()
        { }//dla poprawne załadowanie obiektu
        private WorkManager()
        {
            LoadMonthWork();
        }
        public static WorkManager Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        private MonthWork monthWork;
        private string fileLocation;
        public void LoadMonthWork()
        {
            fileLocation = Path.Combine(Model.Properties.Resources.storageDirectory, ThisMonthFormated);
            if (!File.Exists(fileLocation))
            {
                monthWork = new MonthWork();
            }
            else
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MonthWork));
                using(Stream s = new FileStream(fileLocation, FileMode.Open))
                {
                    monthWork = (MonthWork)serializer.Deserialize(s);
                }
            }
            
        }
        private void Save()
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MonthWork));
                using(Stream s = new FileStream(fileLocation, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(s, monthWork);
                }
        }


        public string ThisMonthFormated
        {
            get
            {
                return string.Format("{0}_{1}", DateTime.Now.Year, DateTime.Now.Month);
            }
        }

        public bool IsStartTimeForCurrentDay
        {
            get
            {
                return monthWork.DayWorkCollection.Exists(day =>
                    {
                        return day.DayShortName == DateTime.Now.ToShortDateString();
                    });
            }
        }
        public void AddTime()
        {
            if (IsStartTimeForCurrentDay)
            {
                monthWork.DayWorkCollection.Find(day =>
                    {
                        return day.DayShortName == DateTime.Now.ToShortDateString();
                    }).EndWorkTime = DateTime.Now;
                this.Save();
            }
            else
            {
                monthWork.DayWorkCollection.Add(new DayWork(DateTime.Now));
                this.Save();
            }
        }



    }
}
