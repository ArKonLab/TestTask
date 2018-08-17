public class Line : Figure
{
    public Line()
    {
        xCord = 2;
        yCord = 1;
        figSize = new int[4, 4];
        figForm = new int[,]
        {
            {1, 1, 1, 1 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 }
        };
    }
}
