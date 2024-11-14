public class SpeedContainer
{
    private float _speed;

    public float Speed 
    {
        get => _speed; 
        
        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _speed = value;
        }
    }

    public SpeedContainer(float speed)
    {
        _speed = speed;
    }
}