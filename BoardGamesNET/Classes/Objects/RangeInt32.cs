using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    /// <summary>
    /// Class that represents a range with <see cref="int"/> values.
    /// </summary>
    public class RangeInt32
    {
        #region ===== FIELDS =====
        private int _Min;
        private int _Max;
        #endregion

        #region ===== VARIABLES =====
        /// <summary>
        /// Smaller value of the range (minimum).<br/>
        /// If setting the value, the value is greater than <see cref="Max"/>, the values will be swapped.
        /// </summary>
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

        /// <summary>
        /// Greater value of the range (maximum).<br/>
        /// If setting the value, the value is lower than <see cref="Min"/>, the values will be swapped.
        /// </summary>
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

        /// <summary>
        /// Mid value of the range.
        /// </summary>
        public float Mid
        {
            get
            {
                return (_Max + _Min) / 2f;
            }
        }
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Create the class.<br/>
        /// The greater value will be set on <see cref="Max"/> while the lower value will be set on <see cref="Min"/>.
        /// </summary>
        /// <param name="value1">First value of the range.</param>
        /// <param name="value2">Second value of the range.</param>
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
