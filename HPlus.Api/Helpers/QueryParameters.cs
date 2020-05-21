using System;

namespace HPlus.Api.Helpers
{
    public class QueryParameters
    {
        private const int MAXSIZE = 100;
        private int _size;
        public int Size
        {
            get { return _size; }
            set { _size = Math.Min(_size, MAXSIZE); }
        }

        public int Page { get; set; }


    }
}
