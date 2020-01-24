

public class BallBuilder {

	public void BuildBallBall(IBallBuilder ballBuilder)
	{
		ballBuilder.SetInitialVelocity();
		ballBuilder.SetMaxVelocity();
		ballBuilder.SetBallType();
        ballBuilder.SetBallBehaviour();
	}
}
