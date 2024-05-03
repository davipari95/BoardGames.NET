using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    public class RangeInt32
    {
        #region ===== FIELDS =====
        private int _Min;
        private int _Max;
        #endregion

        #region ===== VARIABLES =====
        public int Min
        {
            get
            {
                return _Min;
            }
            set
            {
                if (value != _Min)
                {
                    if (value <= _Max)
                    {
                        _Min = value;
                    }
                    else
                    {
                        int t = _Max;
                        _Max = value;
                        _Min = t;
                    }
                }
            }
        }

        public int Max
        {
            get
            {
                return _Max;
            }
            set
            {
                if (value >= _Max)
                {
                    _Max = value;
                }
                else
                {
                    int t = _Min;
                    _Min = value;
                    _Max = t;
                }
            }
        }

        public float Mid
        {
            get
            {
                return (_Max + _Min) / 2f;
            }
        }
        #endregion

        #region ===== CONSTRUCTORS =====
        public RangeInt32(int value1, int value2)
        {
            if (value1 < value2)
            {
                _Min = value1;
                _Max = value2;
            }
            else
            {
                _Min = value2;
                _Max = value1;
            }
        }
        #endregion
    }
}
