using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class represents one item in the list of items that will be 
// displayed in the timeout time combo box in the MainWindow

namespace PortScanner
{
    class TimeoutListItem
    {
        // DisplayMember: the string that will be displayed in the timeout combo box
        // ValueMember: the actual ms value attached to that string
        public string DisplayMember { get; set; }
        public int ValueMember { get; set; }

        // The array of different values present in the combo box
        // Add new values right here ......
        private static int[] _times =
        {
            500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000
        };

        // Returns a list of objects of this class intended to be used
        // as a datasource for a combo box
        public static List<TimeoutListItem> CreateTimeoutListItems()
        {
            var returnList = new List<TimeoutListItem>();

            for (int i = 0; i < _times.Length; i++)
            {
                returnList.Add(new TimeoutListItem
                {
                    DisplayMember = String.Format("{0} ms", _times[i]),
                    ValueMember = _times[i]
                });
            }

            return returnList;
        }
    }
}
