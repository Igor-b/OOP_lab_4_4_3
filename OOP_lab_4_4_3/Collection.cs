using System;
using System.IO;

namespace OOP_lab_4_4_3
{
    class Collection : IComparable<Collection>
    {
        private string _number;
        private string _nameOfAlbum;
        private double _sizeOfDisk;
        private string _typeOfDisk;
        private DateTime _dateOfRecording;
        public Collection()
        {
            _number = "0000000";
            _nameOfAlbum = "Не вказано";
            _sizeOfDisk = 0;
            _typeOfDisk = "Не вказано";
            _dateOfRecording = new DateTime(0001, 01, 01);
        }
        public Collection(string s)
        {
            string[] str = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            _nameOfAlbum = str[1];

            _number = str[0];

            _sizeOfDisk = double.Parse(str[2]);

            TypeOfDisk = str[3];

            string[] data = str[4].Split('.');

            DateOfRecording = new DateTime(int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[0]));

        }
        public int CompareTo(Collection p)
        {
            return this._dateOfRecording.CompareTo(p._dateOfRecording);
        }
        public static void AddInFile(string s)
        {
            string[] str = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StreamWriter file = new StreamWriter("base.txt", true);

            file.WriteLine("{0, -10} {1, 15} {2, 15} {3, 15} {4, 15}",str[0], str[1], str[2], str[3], str[4]);

            file.Close();
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string NameOfAlbum
        {
            get { return _nameOfAlbum; }
            set { _nameOfAlbum = value; }
        }
        public double SizeOfDisk
        {
            get { return _sizeOfDisk; }
            set { _sizeOfDisk = value; }
        }
        public string TypeOfDisk
        {
            get { return _typeOfDisk; }
            set { _typeOfDisk = value; }
        }
        public DateTime DateOfRecording
        {
            get { return _dateOfRecording; }
            set { _dateOfRecording = value; }
        }

    }

}
