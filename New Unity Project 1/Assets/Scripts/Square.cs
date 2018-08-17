public class Square : Figure
{
    public Square()
    {
        xCord = 3;
        yCord = 1;
        figSize = new int[2, 2];
        figForm = new int[,]
        {
            {1, 1 },
            {1, 1 }
        };
    }
}
