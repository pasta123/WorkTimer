using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    
    public class DayWork
    {
        private DateTime startWork;
        private DateTime endWork;
        private DayWork() { }
        /// <summary>
        /// Initialize new instace of DayWork
        /// set startWork
        /// </summary>
        /// <param name="date"></param>
        public DayWork(DateTime date)
        {
            this.startWork = date;
        }
        /// <summary>
        /// Time of start work
        /// </summary>
        public DateTime StartWork
        {
            get
            {
                return this.startWork;
            }
            set
            {
                this.startWork = value;
            }

        }
        /// <summary>
        /// Time of EndWork
        /// </summary>
        public DateTime EndWorkTime
        {
            get
            {
                return this.endWork;
            }
            set
            {
                this.endWork = value;
            }
        }

        public string DayShortName
        {
            get
            {
                return this.startWork.ToShortDateString();
            }
        }

    }
}
