using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    /// <summary>
    /// Class containing informations of a grid position.
    /// </summary>
    public class GridPosition : IEquatable<GridPosition>, ICloneable
    {

        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private int _Row;
        private int _Column;
        #endregion

        /// <summary>
        /// Row position
        /// </summary>
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

        /// <summary>
        /// Column position
        /// </summary>
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
        /// <summary>
        /// Event triggered when row value is changed.
        /// </summary>
        public event EventHandler<int> RowChangedValueEvent;

        /// <summary>
        /// Event triggered when column value is changed.
        /// </summary>
        public event EventHandler<int> ColumnChangedValueEvent;

        /// <summary>
        /// Event triggered when row or column value is changed.
        /// </summary>
        public event EventHandler<GridPosition> PositionChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the class.
        /// </summary>
        public GridPosition()
        {
            _Row = 0;
            _Column = 0;
        }

        /// <summary>
        /// Intialize the class.
        /// </summary>
        /// <param name="row">Starting row position.</param>
        /// <param name="column">Starting column position.</param>
        public GridPosition(int row, int column)
        {
            _Row = row;
            _Column = column;
        }

        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="gridPosition">Grid position containing row and column informations for initializing this class.</param>
        public GridPosition(GridPosition gridPosition)
        {
            _Row = gridPosition.Row;
            _Column = gridPosition.Column;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Change the position with specific row and column value.
        /// </summary>
        /// <param name="row">New row positon.</param>
        /// <param name="column">New column position.</param>
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

        /// <summary>
        /// Change the position copying the position of another grid position.
        /// </summary>
        /// <param name="position">GridPosition containing the new position.</param>
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
