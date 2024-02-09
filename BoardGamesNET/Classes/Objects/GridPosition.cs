using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    public class GridPosition : IEquatable<GridPosition>, ICloneable
    {
        #region ===== FIELDS FOR VARIABLES =====
        private int _Row;
        private int _Column;
        #endregion

        #region ===== VARIABLES =====
        public int Row
        {
            get
            {
                return _Row;
            }
            set
            {
                if (value != _Row)
                {
                    _Row = value;

                    RowChangedValueEvent?.Invoke(this, value);
                    PositionChangedEvent?.Invoke(this, new GridPosition(value, Column));
                }
            }
        }

        public int Column
        {
            get
            {
                return _Column;
            }
            set
            {
                if (value != _Column)
                {
                    _Column = value;

                    ColumnChangedValueEvent?.Invoke(this, value);
                    PositionChangedEvent?.Invoke(this, new GridPosition(Row, value));
                }
            }
        }
        #endregion

        #region ===== EVENTS =====
        public event EventHandler<int> RowChangedValueEvent;
        public event EventHandler<int> ColumnChangedValueEvent;
        public event EventHandler<GridPosition> PositionChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        public GridPosition()
        {
            _Row = 0;
            _Column = 0;
        }

        public GridPosition(int row, int column)
        {
            _Row = row;
            _Column = column;
        }

        public GridPosition(GridPosition gridPosition)
        {
            _Row = gridPosition.Row;
            _Column = gridPosition.Column;
        }
        #endregion

        #region ===== METHODS =====
        public void SetPosition(int row, int column)
        {
            bool somethingChanged = false;

            if (_Row != row)
            {
                _Row = row;
                RowChangedValueEvent?.Invoke(this, row);

                somethingChanged = true;
            }

            if (_Column != column)
            {
                _Column = column;
                ColumnChangedValueEvent?.Invoke(this, column);
            }

            if (somethingChanged)
            {
                PositionChangedEvent?.Invoke(this, new GridPosition(this));
            }
        }

        public void SetPosition(GridPosition position)
        {
            SetPosition(position.Row, position.Column);
        }

        public object Clone()
        {
            return new GridPosition(Row, Column);
        }

        public bool Equals(GridPosition? other)
        {
            return
                other != null &&
                other.Row.Equals(Row) &&
                other.Column.Equals(Column);
        }

        public override string ToString()
        {
            return $"[ Row = {Row} ; Column = {Column} ]";
        }
        #endregion
    }
}
