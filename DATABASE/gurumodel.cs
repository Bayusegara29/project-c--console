using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASE
{
    class gurumodel
    {
        private string _nip;
        private string _namaguru;
        private string _jabatan;

        public string nip
        {
            get
            {
                return _nip;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Nis tidak boleh kosong");
                }
                _nip = value;
            }
        }
        public string namaguru
        {
            get
            {
                return _namaguru;
            }
            set
            {
                _namaguru = value;
            }
        }
        public string jabatan
        {
            get
            {
                return _jabatan;
            }
            set
            {
                _jabatan = value;
            }
        }
    }
}
