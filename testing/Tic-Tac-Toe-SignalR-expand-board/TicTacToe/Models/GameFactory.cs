using TicTacToe.GameObjects;

public abstract class GameFactory
{
    public abstract Piece CreatePiece(Player player);
    public abstract Obstacle CreateObstacle();
}