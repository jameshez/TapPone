﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapPone
{
    public abstract class item
    {
        private string _name;
        public virtual string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private Uri _imageUri;
        public Uri imageUri
        {
            get
            {
                return _imageUri;
            }
            set
            {
                _imageUri = value;
            }
        }
    }
}
