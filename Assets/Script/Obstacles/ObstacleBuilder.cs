public class ObstacleBuilder {

    public void BuildObstacle(IObstacleBuilder builder)
    {
        builder.SetDestructionSound();
        builder.SetCollisionSound();
        builder.SetObstacleType();
        builder.SetObstacleSprite();
        builder.SetObstacleCollisionEffect();
    }
}
