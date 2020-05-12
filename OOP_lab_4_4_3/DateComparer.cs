using System.Collections.Generic;

namespace OOP_lab_4_4_3
{
    class DateComparer : IComparer<Collection>
    {
        public int Compare(Collection a, Collection b)
        {
            if (a.DateOfRecording > b.DateOfRecording)
            {
                return 1;
            }

            else if (a.DateOfRecording < b.DateOfRecording)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
