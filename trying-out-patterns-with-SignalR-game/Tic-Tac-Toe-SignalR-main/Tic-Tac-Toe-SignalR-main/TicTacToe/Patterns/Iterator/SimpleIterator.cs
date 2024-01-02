namespace TicTacToe.Patterns.Iterator
{
    public class SimpleIterator : Iterator
    {
        private MessagesCollection _collection;

        private int _position = -1;

        public SimpleIterator(MessagesCollection collection)
        {
            this._collection = collection;
            this._position = 0;
        }

        public override object Current()
        {
            return this._collection.getItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + 1;

            if(updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count) 
            {
                this._position = updatedPosition;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            this._position = 0;
        }
    }
}
