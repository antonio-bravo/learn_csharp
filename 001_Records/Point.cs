public struct Point
{
  public int x;
  public int y;

  public Point(int value1, int value2)
  {
    this.x = value1;
    this.y = value2;
  }
  public void PrintPoint()
  {
    Console.WriteLine($"Point Values: {this.x}, {this.y}");
  }
}