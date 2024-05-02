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

                }
            }
        }

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
