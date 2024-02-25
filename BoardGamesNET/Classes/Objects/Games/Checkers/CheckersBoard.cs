﻿using BoardGamesNET.Classes.Utils;
using BoardGamesNET.Enums;
using System.CodeDom;
using System.Reflection;

namespace BoardGamesNET.Classes.Objects.Games.Checkers
{
    public class CheckersBoard
    {

        #region ===== VARIABLES =====

        #region ==== FIELDS FOR VARIABLES =====
        private List<Pawn> _Pawns;
        private Game _ParentGame;
        #endregion

        public List<Pawn> Pawns
        {
            get
            {
                return _Pawns;
            }
            set
            {
                if (value != _Pawns)
                {
                    _Pawns = value;
                }
            }
        }

        public Game ParentGame
        {
            get
            {
                return _ParentGame;
            }
            set
            {
                if (value != _ParentGame)
                {
                    _ParentGame = value;
                }
            }
        }

        #endregion

        #region ===== EVENTS =====
        public event EventHandler<PawnMovedEventArgs> PawnMovedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        public CheckersBoard(Game parentGame)
        {
            ParentGame = parentGame;

            InitializePawns();
        }
        #endregion

        #region ===== METHODS =====
        public Pawn? GetPawnByPosition(GridPosition position)
        {
            return Pawns.FirstOrDefault(p => p.GridPosition.Equals(position));
        }

        public static bool IsInCheckersBoard(GridPosition position)
        {
            return
                UMath.Beetween(position.Row, 0, 7) &&
                UMath.Beetween(position.Column, 0, 7);
        }

        public static bool IsInCheckersBoard(int row, int column)
        {
            return IsInCheckersBoard(new GridPosition(row, column));
        }

        public static bool IsInCheckersBoard(int rowOrColumn)
        {
            return UMath.Beetween(rowOrColumn, 0, 7);
        }

        private void InitializePawns()
        {
            Pawns = new List<Pawn>(0);

            Pawns.AddRange(GetStartingPawns(PlayerColorWBEnum.White));
            Pawns.AddRange(GetStartingPawns(PlayerColorWBEnum.Black));

            foreach (Pawn p in Pawns)
            {
                p.PositionChanged += OnPawnPositionChangedEvent;
            }
        }

        private IEnumerable<Pawn> GetStartingPawns(PlayerColorWBEnum color)
        {
            int startingRow = color == PlayerColorWBEnum.White ? 7 : 0;
            int endingRow = color == PlayerColorWBEnum.White ? 5 : 2;
            int incrementor = color == PlayerColorWBEnum.White ? -1 : 1;

            for (int r = startingRow; UMath.Beetween(r, startingRow, endingRow); r += incrementor)
            {
                for (int c = (r + 1) % 2; c < 8; c += 2)
                {
                    yield return new Pawn(this, color, new GridPosition(r, c));
                }
            }
        }

        private void OnPawnPositionChangedEvent(object? sender, GridPosition e)
        {
            if (sender != null && sender is Pawn)
            {
                PawnMovedEvent?.Invoke(this, new PawnMovedEventArgs((Pawn)sender, e)); 
            }
            else
            {
                throw new ArgumentNullException("Sender is null.");
            }
        }
        #endregion

        #region ===== NESTED CLASSES =====
        public class PawnMovedEventArgs
        {
            #region ===== VARIABLES =====

            #region ===== FIELDS FOR VARIABLES
            private Pawn _Pawn;
            private GridPosition _GridPosition;
            #endregion

            public Pawn Pawn => _Pawn;
            public GridPosition GridPosition => _GridPosition;
            #endregion

            #region ===== CONSTRUCTORS =====
            public PawnMovedEventArgs(Pawn pawn, GridPosition gridPosition)
            {
                _Pawn = pawn;
                _GridPosition = gridPosition;
            }
            #endregion
        }
        #endregion
    }
}
